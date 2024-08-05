namespace MAUIsland.Mockup;

public partial class PreviewImageModel : BaseModel
{
    [ObservableProperty]
    string? collectionViewId;

    [ObservableProperty]
    string? imageSource;

    [ObservableProperty]
    bool isAddButton;
}
