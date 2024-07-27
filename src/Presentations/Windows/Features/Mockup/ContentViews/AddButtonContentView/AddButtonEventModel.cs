namespace MAUIsland.Mockup;


public partial class AddButtonEventModel : BaseModel
{
    [ObservableProperty]
    string id;
    [ObservableProperty]
    string imageSource;
    [ObservableProperty]
    bool isAddButton;
}