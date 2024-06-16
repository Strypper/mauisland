namespace MAUIsland.Showcases;

public partial class UIItem : Item
{
    [ObservableProperty]
    int stars;

    [ObservableProperty]
    DateTime lastCommit;
}
