using Octokit;

namespace MAUIsland;

public interface IRepositorySyncService : ILocalDbService<RepositoryModel>
{
    #region [ Public Methods - Get Single ]
    Task<Repository> GetRepositoryAsync(string ownerUrl, string repoName, string headerValue = "");
    #endregion
}
