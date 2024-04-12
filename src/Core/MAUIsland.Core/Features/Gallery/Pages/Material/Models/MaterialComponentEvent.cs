namespace MAUIsland.Core;

public partial class MaterialComponentEvent : BaseModel
{
    [ObservableProperty]
    string name;

    [ObservableProperty]
    string dataType;
}
