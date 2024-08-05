namespace MAUIsland.Mockup;

public partial class MockupItemModel : BaseModel
{
    [ObservableProperty]
    string deviceModel;

    [ObservableProperty]
    ObservableCollection<PreviewImageModel> previewImages;
}
