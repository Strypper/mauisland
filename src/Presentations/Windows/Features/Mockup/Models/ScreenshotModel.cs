namespace MAUIsland.Mockup;

public partial class ScreenshotModel : BaseModel
{
    [ObservableProperty]
    string? collectionViewId;

    [ObservableProperty]
    string? imageSource;

    [ObservableProperty]
    bool isAddButton;
}
