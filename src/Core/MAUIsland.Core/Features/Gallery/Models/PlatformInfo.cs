namespace MAUIsland.Core;

public partial class PlatformInfo : BaseModel
{
    [ObservableProperty]
    string name;
    [ObservableProperty]
    string logo;
    [ObservableProperty]
    string tooltip;
}
