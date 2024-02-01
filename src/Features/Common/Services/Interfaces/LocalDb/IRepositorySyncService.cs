using Octokit;

namespace MAUIsland;

public interface IRepositorySyncService : ILocalDbService<RepositoryModel>
{
    #region [ Public Methods - Get Single ]
    Task<Repository> GetRepositoryAsync(string ownerUrl, string repoName);
    #endregion

    #region [ Private Methods - Sync ]
    Task<List<Repository>> SyncRepositoriesAsync();
    #endregion
}
