namespace MAUIsland;

public partial class MaterialComponentProperty : BaseModel
{
    [ObservableProperty]
    string name;

    [ObservableProperty]
    string dataType;

    [ObservableProperty]
    string defaultValue;
}
