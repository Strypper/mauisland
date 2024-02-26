using Octokit;

namespace MAUIsland;

public class GitHubRepositorySyncService : SQLitePCLRawService<GitHubRepositoryLocalDbModel>, IGitHubRepositorySyncService
{
    #region [ Private Fields ]
    private readonly ICardInfoSyncService _cardInfoSyncService;
    #endregion

    #region [ CTor ]
    public GitHubRepositorySyncService(ICardInfoSyncService cardInfoSyncService) {
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
                if ((now - lastUpdateTime.ApplicationLastUpdate).TotalHours < 1) {
                    var syncedRepo = (await base.GetAllAsync()).FirstOrDefault(x => x.Name.Equals(repoName, StringComparison.InvariantCultureIgnoreCase));
                    repository = syncedRepo.ToRepository();
                    return repository;
                }
            }

            // Reach this means lastUpdateTime = null or (now - lastUpdateTime) > 1 hour:
            // Sync repo from GitHub
            repository = await SyncRepoAsync(ownerName, repoName, headerValue);

            // Update last update time
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
    /// <summary>
    /// Get repository, update localdb and return.
    /// </summary>
    /// <param name="ownerName"> Owner's name.</param>
    /// <param name="repoName">Repository's name.</param>
    /// <param name="headerValue">Value of <see cref="ProductHeaderValue"></see>.</param>
    /// <returns></returns>
    private async Task<Repository> SyncRepoAsync(string ownerName, string repoName, string headerValue = "") {
        if (string.IsNullOrEmpty(ownerName) || string.IsNullOrEmpty(repoName)) {
            return default;
        }

        headerValue = string.IsNullOrEmpty(headerValue) ? headerValue : repoName;
        var github = new GitHubClient(new ProductHeaderValue(headerValue));

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