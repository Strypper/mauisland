
namespace MAUIsland.GitHubProvider;

public class OctokitGitHubClient : IGitHubService
{
    #region [ Fields ]

    private readonly string httpHeader = "Totechs Corps";
    #endregion

    #region [ CTor ]

    public OctokitGitHubClient()
    {

    }
    #endregion

    #region [ Methods ]

    public Task<GitHubAuthorModel> GetAuthor(string owner)
    {
        throw new NotImplementedException();
    }

    public Task<GitHubIssueModel> GetGitHubIssueById(string owner, string repository, string issueNumber)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GitHubIssueModel>> GetGitHubIssues(string owner, string repository)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GitHubIssueModel>> GetGitHubIssuesByLabels(string owner, string repository, IEnumerable<string> labels)
    {
        throw new NotImplementedException();
    }

    public Task<GitHubRepositoryModel> GetRepository(string owner, string repository)
    {
        throw new NotImplementedException();
    }
    #endregion
}
