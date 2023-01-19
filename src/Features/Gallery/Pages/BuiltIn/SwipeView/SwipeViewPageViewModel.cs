namespace MAUIsland;


public partial class SwipeViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public SwipeViewPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;
    [ObservableProperty]
    string standardSwipeViewXamlCode = "<SwipeView>\r\n                        <SwipeView.LeftItems>\r\n                            <SwipeItems>\r\n                                <SwipeItem \r\n                                             Text=\"Favorite\"\r\n                                             IconImageSource=\"favorite.png\"\r\n                                             BackgroundColor=\"LightGreen\"/>\r\n                                <SwipeItem \r\n                                             Text=\"Delete\"\r\n                                             IconImageSource=\"delete.png\"\r\n                                             BackgroundColor=\"LightPink\"/>\r\n                            </SwipeItems>\r\n                        </SwipeView.LeftItems>\r\n                        <!-- Content -->\r\n                        <Grid   \r\n                                HeightRequest=\"60\"\r\n                                WidthRequest=\"300\"\r\n                                BackgroundColor=\"DimGray\">\r\n                            <Label \r\n                                     Text=\"Swipe right\"\r\n                                     HorizontalOptions=\"Center\"\r\n                                     VerticalOptions=\"Center\"/>\r\n                        </Grid>\r\n                    </SwipeView>";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}
