using Octokit;

namespace MAUIsland.Core;

public interface IGitHubRepositorySyncService : ILocalDbService<GitHubRepositoryLocalDbModel>
{
    #region [ Public Methods - Get Single ]
    Task<Repository> GetRepositoryAsync(string ownerUrl, string repoName, string headerValue = "");
    #endregion
}