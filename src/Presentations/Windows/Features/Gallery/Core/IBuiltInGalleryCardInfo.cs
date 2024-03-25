namespace MAUIsland;

public interface IBuiltInGalleryCardInfo : IGalleryCardInfo
{
    string GitHubAuthorIssueName { get; }

    string GitHubRepositoryIssueName { get; }

    List<string> GitHubIssueLabels { get; }

    BuiltInGalleryCardStatus Status { get; }
}
