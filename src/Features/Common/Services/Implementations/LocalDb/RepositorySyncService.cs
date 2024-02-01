using Octokit;

namespace MAUIsland;

public class RepositorySyncService : SQLitePCLRawService<RepositoryModel>, IRepositorySyncService
{
    #region [ Private Fields ]
    private readonly ICardInfoSyncService _cardInfoSyncService;
    #endregion

    #region [ CTor ]
    public RepositorySyncService(ICardInfoSyncService cardInfoSyncService) {
        _cardInfoSyncService = cardInfoSyncService;
    }
    #endregion

    #region [ Public Methods - Get Single ]
    public async Task<Repository> GetRepositoryAsync(string ownerName, string repoName, string headerValue = "") {
        try {
            // Test
            //await _cardInfoSyncService.AddAsync(new() { ApplicationLastUpdate = DateTime.UtcNow });
            var all = await _cardInfoSyncService.GetAllAsync();
            var lastUpdateTime = all.OrderBy(x => x.ApplicationLastUpdate).LastOrDefault();
            var now = DateTime.UtcNow;
            var repository = new Repository();

            if (lastUpdateTime != null) {
                // In case the time elapsed less than 1 hour => no need to call GitHub api.
                if((now - lastUpdateTime.ApplicationLastUpdate).TotalHours < 1) {
                    var syncedRepo = (await base.GetAllAsync()).FirstOrDefault(x => x.Name.Equals(repoName, StringComparison.InvariantCultureIgnoreCase));
                    repository = syncedRepo.ToRepository();
                    return repository;
                }
            }

            // Reach this means lastUpdateTime = null or now - lastUpdateTime > 1 hour
            var allRepos = await SyncRepositoriesAsync();
            repository = allRepos.FirstOrDefault(x => x.Name.Equals(repoName, StringComparison.InvariantCultureIgnoreCase));

            return repository;
        }
        catch (Exception ex) {
            // This has been added with the purpose of handling errors during syncing process.
            // Currently, it does nothing :)
            return default;
        }
    }
    #endregion

    #region [ Methods - Sync ]
    public async Task<List<Repository>> SyncRepositoriesAsync() {
        var now = DateTime.UtcNow;
        var lastUpdateTime = (await _cardInfoSyncService.GetAllAsync()).OrderBy(x => x.ApplicationLastUpdate).LastOrDefault();
        if (lastUpdateTime == null) {
            lastUpdateTime = new() {
                ApplicationLastUpdate = now
            };

            await _cardInfoSyncService.AddAsync(lastUpdateTime);
        }
        else {
            lastUpdateTime.ApplicationLastUpdate = now;
            await _cardInfoSyncService.UpdateAsync(lastUpdateTime);
        }

        var tasks = new List<Task<Repository>>() {
            SyncAcrylicViewRepoAsync(),
            SyncLiveCharts2RepoAsync(),
            SyncOverFlowerRepoAsync(),
            SyncSQLitePCLRawRepoAsync(),
            SyncZXingNetMauiRepoAsync()
        };

        await Task.WhenAll(tasks);

        return tasks.Select(x => x.Result).ToList();
    }

    private Task<Repository> SyncAcrylicViewRepoAsync() {
        var owner = "sswi";
        var repo = "AcrylicView.MAUI";
        var headerValue = "AcrylicView.MAUI";

        return SyncRepoAsync(owner, repo, headerValue);
    }

    private Task<Repository> SyncLiveCharts2RepoAsync() {
        var owner = "beto-rodriguez";
        var repo = "LiveCharts2";
        var headerValue = "LiveCharts2";

        return SyncRepoAsync(owner, repo, headerValue);
    }

    private Task<Repository> SyncOverFlowerRepoAsync() {
        var owner = "nor0x";
        var repo = "OverFlower";
        var headerValue = "OverFlower";

        return SyncRepoAsync(owner, repo, headerValue);
    }

    private Task<Repository> SyncSQLitePCLRawRepoAsync() {
        var owner = "ericsink";
        var repo = "SQLitePCL.raw";
        var headerValue = "SQLitePCLRaw";

        return SyncRepoAsync(owner, repo, headerValue);
    }

    private Task<Repository> SyncZXingNetMauiRepoAsync() {
        var owner = "Redth";
        var repo = "ZXing.Net.Maui";
        var headerValue = "ZXing.Net.Maui";

        return SyncRepoAsync(owner, repo, headerValue);
    }


    /// <summary>
    /// Get repository, update localdb and return.
    /// </summary>
    /// <param name="ownerName"> Owner's name.</param>
    /// <param name="repoName">Repository's name.</param>
    /// <param name="headerValue">Value of <see cref="ProductHeaderValue"></see>.</param>
    /// <returns></returns>
    private async Task<Repository> SyncRepoAsync(string ownerName, string repoName, string headerValue = ""){
        if (string.IsNullOrEmpty(ownerName) || string.IsNullOrEmpty(repoName)) {
            return default;
        }

        var now = DateTime.UtcNow;
        var value = string.IsNullOrEmpty(repoName) ? repoName : headerValue;
        var github = new GitHubClient(new ProductHeaderValue(value));

        var repository = await github.Repository.Get(ownerName, repoName);

        var newModel = repository.ToRepositoryModel();
        var oldModel = (await base.GetAllAsync()).FirstOrDefault(x => x.Name.Equals(repoName, StringComparison.InvariantCultureIgnoreCase));
        if (oldModel != null) {
            await base.DeleteAsync(oldModel);
        }
        await base.AddAsync(newModel);

        return repository;
    }
    #endregion
}
