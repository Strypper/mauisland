namespace MAUIsland.Core;

public partial class BaseMockup : BaseModel
{
    [ObservableProperty]
    string appName;

    [ObservableProperty]
    string authorGitHubUserName;

    [ObservableProperty]
    string authorAvatar;

    [ObservableProperty]
    string authorLinkUrl;

    [ObservableProperty]
    string gitHubRepoName;

    [ObservableProperty]
    int repoStarsCount;

    [ObservableProperty]
    string repoUrl;

    [ObservableProperty]
    ObservableCollection<string> mockups = new();

    [ObservableProperty]
    bool canMockupFrameChangeState = true;

    [ObservableProperty]
    string currentMockupFrameState;
}
