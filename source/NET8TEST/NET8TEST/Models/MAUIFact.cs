using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUIsland;

public partial class MAUIFact : BaseModel
{
    [ObservableProperty]
    string fact;

    [ObservableProperty]
    string factUrl;
}
