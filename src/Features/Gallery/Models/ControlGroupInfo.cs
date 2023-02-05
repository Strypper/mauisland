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
    string lottieUrl;

    public const string BuiltInControls = nameof(BuiltInControls);
    public const string SyncfusionControls = nameof(SyncfusionControls);
}
