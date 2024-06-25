namespace MAUIsland.Home;

public partial class UIItem : Item
{
    [ObservableProperty]
    int stars;

    [ObservableProperty]
    DateTime lastCommit;
}
