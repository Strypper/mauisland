namespace MAUIsland.Features.LocalDbFeatures.GitHub;

public interface IGitHubIssueLocalDbService : ILocalDbService<GitHubIssueLocalDbModel>
{
    /// <summary>
    /// Get list of issues related to a control.
    /// </summary>
    /// <param name="controlName"></param>
    /// <returns></returns>
    Task<IEnumerable<GitHubIssueLocalDbModel>?> GetByControlNameAsync(string controlName);

    /// <summary>
    /// Get single issue by its url.
    /// </summary>
    /// <param name="issueUrl"></param>
    /// <returns></returns>
    Task<GitHubIssueLocalDbModel?> GetByIssueUrlAsync(string issueUrl);
}
