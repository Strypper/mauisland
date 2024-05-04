using OneOf;

namespace MAUIsland.GitHubFeatures;

public interface IGitHubService
{
    Task<OneOf<ServiceSuccess, SerivceError>> GetRepository(string owner, string repository);

    Task<OneOf<ServiceSuccess, SerivceError>> GetLatestRelease(string owner, string repository);

    Task<OneOf<ServiceSuccess, SerivceError>> GetAuthor(string owner);

    Task<OneOf<ServiceSuccess, SerivceError>> GetGitHubIssues(string owner, string repository);

    Task<OneOf<ServiceSuccess, SerivceError>> GetGitHubIssuesByLabels(string owner, string repository, IEnumerable<string> labels);

    Task<OneOf<ServiceSuccess, SerivceError>> GetGitHubIssueByNo(string owner, string repository, int issueNumber);
}
