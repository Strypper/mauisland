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

    [ObservableProperty]
    string standardIndicatorViewXamlCode = "<StackLayout HorizontalOptions=\"Start\">\r\n    <CarouselView ItemsSource=\"{Binding Cats}\"\r\n                  WidthRequest=\"120\"\r\n                  HorizontalScrollBarVisibility=\"Never\"\r\n                  IndicatorView=\"indicatorView1\"\r\n                  Loop=\"False\"\r\n                  ItemTemplate=\"{x:StaticResource CarouseViewTemplate1}\"/>\r\n    <IndicatorView x:Name=\"indicatorView1\"\r\n                   IndicatorColor=\"LightGray\"\r\n                   SelectedIndicatorColor=\"DarkGray\"/>\r\n</StackLayout>";
}

