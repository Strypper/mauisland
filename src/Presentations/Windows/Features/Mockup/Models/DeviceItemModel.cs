namespace MAUIsland.Mockup;

public partial class DeviceItemModel : BaseModel
{
    [ObservableProperty]
    string deviceModel;

    [ObservableProperty]
    ObservableCollection<ScreenshotModel> screenshots;
}
