namespace MAUIsland.Features.LocalDbFeatures.GitHub;

public class GitHubIssueLocalDbService : SQLitePCLRawService<GitHubIssueLocalDbModel>, IGitHubIssueLocalDbService
{
    #region [ CTor ]

    public GitHubIssueLocalDbService(DatabaseSettings settings) : base(settings)
    {

    }

    #endregion
}
