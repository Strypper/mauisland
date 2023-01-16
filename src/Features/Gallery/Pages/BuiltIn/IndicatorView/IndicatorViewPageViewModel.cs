namespace MAUIsland;


public partial class IndicatorViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public IndicatorViewPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion

    [ObservableProperty]
    List<Cats> cats = new List<Cats>()
    {
        new Cats()
        {
            Name = "Polydactyl",
            Description = "Cat1"
        },
        new Cats()
        {
            Name = "Snowshoe",
            Description = "Cat2"
        },new Cats()
        {
            Name = "British Shorthair",
            Description = "Cat3"
        },new Cats()
        {
            Name = "Gray Tabby",
            Description = "Cat4"
        }
    };
}

