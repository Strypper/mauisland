namespace MAUIsland.Mockup;


public partial class DroppedImage : BaseModel
{
    [ObservableProperty]
    string id;
    [ObservableProperty]
    string imageSource;
    [ObservableProperty]
    string collectionViewId;
}