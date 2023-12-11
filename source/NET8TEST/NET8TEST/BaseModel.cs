using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUIsland;

public partial class BaseModel : ObservableObject
{
    [ObservableProperty]
    string id;
}