namespace MAUIsland.Mockup;

public partial class MockupPreviewItemModel : BaseModel
{
    [ObservableProperty]
    string? imageSource;

    [ObservableProperty]
    bool isAddButton;
}
