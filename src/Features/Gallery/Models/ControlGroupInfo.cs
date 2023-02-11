namespace MAUIsland;

public partial class ControlGroupInfo : BaseModel
{
    [ObservableProperty]
    string name;
    [ObservableProperty]
    string title;
    [ObservableProperty]
    string providerUrl;
    [ObservableProperty]
    ImageSource iconUrl;
    [ObservableProperty]
    ImageSource banner;
    [ObservableProperty]
    string lottieUrl;

    [ObservableProperty]
    string microsoftStoreLink;

    public const string BuiltInControls = nameof(BuiltInControls);
    public const string SyncfusionControls = nameof(SyncfusionControls);
}
