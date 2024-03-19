namespace MAUIsland.GitHubFeatures;

public interface IGitHubService
{
    Task<GitHubRepositoryModel> GetRepository(string owner, string repository);

    Task<GitHubAuthorModel> GetAuthor(string owner);

    Task<IEnumerable<GitHubIssueModel>> GetGitHubIssues(string owner, string repository);

    Task<IEnumerable<GitHubIssueModel>> GetGitHubIssuesByLabels(string owner, string repository, IEnumerable<string> labels);

    Task<GitHubIssueModel> GetGitHubIssueByNo(string owner, string repository, int issueNumber);
}
