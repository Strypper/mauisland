namespace MAUIsland;

public partial class ControlGroupInfo : BaseModel
{
    [ObservableProperty]
    string name;

    [ObservableProperty]
    string author;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    string title;

    [ObservableProperty]
    string version;

    [ObservableProperty]
    string providerUrl;

    [ObservableProperty]
    ImageSource iconUrl;

    [ObservableProperty]
    ImageSource banner;

    [ObservableProperty]
    string lottieUrl;

    [ObservableProperty]
    bool isVisibile = true;

    [ObservableProperty]
    Color brandColor;

    [ObservableProperty]
    Color buttonTextColor;

    [ObservableProperty]
    ControlGroupInfoImportant? important;

    [ObservableProperty]
    string microsoftStoreLink;

    public const string BuiltInControls = nameof(BuiltInControls);
    public const string SyncfusionControls = nameof(SyncfusionControls);
    public const string DevExpressControls = nameof(DevExpressControls);
    public const string CommunityToolkit = nameof(CommunityToolkit);
    public const string GitHubCommunity = nameof(GitHubCommunity);
    public const string MaterialComponent = nameof(MaterialComponent);
}
