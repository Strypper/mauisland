namespace MAUIsland.GitHubFeatures;

public partial class GitHubRepositoryReleaseModel : GitHubBaseModel
{
    [ObservableProperty]
    string url;

    [ObservableProperty]
    string htmlUrl;

    [ObservableProperty]
    string assetsUrl;

    [ObservableProperty]
    string uploadUrl;

    [ObservableProperty]
    string nodeId;

    [ObservableProperty]
    string tagName;

    [ObservableProperty]
    string targetCommitish;

    [ObservableProperty]
    string name;

    [ObservableProperty]
    string body;

    [ObservableProperty]
    bool draft;

    [ObservableProperty]
    bool prerelease;

    [ObservableProperty]
    DateTimeOffset createdAt;

    [ObservableProperty]
    DateTimeOffset? publishedAt;

    [ObservableProperty]
    GitHubAuthorModel? author;

    [ObservableProperty]
    string tarballUrl;

    [ObservableProperty]
    string zipballUrl;

    [ObservableProperty]
    IReadOnlyList<ReleaseAsset> assets;
}
