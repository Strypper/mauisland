namespace MAUIsland;

public partial class ControlInfo : BaseModel
{
    [ObservableProperty]
    ImageSource controlIcon;

    [ObservableProperty]
    string controlName;

    [ObservableProperty]
    string controlDetail;

    [ObservableProperty]
    string controlRoute;
}
