using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUIsland.NewsFeatures;

public partial class NewsBaseModel : ObservableObject
{
    [ObservableProperty]
    string id;
}
