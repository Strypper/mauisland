namespace MAUIsland;
public partial class HorizontalStackLayoutPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public HorizontalStackLayoutPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    string horizontalStackLayoutRectangleLabelXamlCode = "<HorizontalStackLayout Margin=\"20\">\r\n                        <Rectangle\r\n                            Fill=\"Red\"\r\n                            HeightRequest=\"30\"\r\n                            WidthRequest=\"30\" />\r\n                        <Label\r\n                            FontSize=\"18\"\r\n                            Text=\"Red\"\r\n                            TextColor=\"Blue\" />\r\n                    </HorizontalStackLayout>";

    [ObservableProperty]
    string spaceBetweenChildViewsXamlCode = "<HorizontalStackLayout Margin=\"20\" Spacing=\"10\">\r\n                        <Rectangle\r\n                            Fill=\"Red\"\r\n                            HeightRequest=\"30\"\r\n                            WidthRequest=\"30\" />\r\n                        <Label\r\n                            FontSize=\"18\"\r\n                            Text=\"Red\"\r\n                            TextColor=\"Blue\" />\r\n                    </HorizontalStackLayout>";

    [ObservableProperty]
    string positionAndSizeChildViewsXamlCode = "<HorizontalStackLayout Margin=\"20\" HeightRequest=\"200\">\r\n                        <Label\r\n                            BackgroundColor=\"Gray\"\r\n                            Text=\"Start\"\r\n                            TextColor=\"Blue\"\r\n                            VerticalOptions=\"Start\" />\r\n                        <Label\r\n                            BackgroundColor=\"Gray\"\r\n                            Text=\"Center\"\r\n                            TextColor=\"Blue\"\r\n                            VerticalOptions=\"Center\" />\r\n                        <Label\r\n                            BackgroundColor=\"Gray\"\r\n                            Text=\"End\"\r\n                            TextColor=\"Blue\"\r\n                            VerticalOptions=\"End\" />\r\n                        <Label\r\n                            BackgroundColor=\"Gray\"\r\n                            Text=\"Fill\"\r\n                            TextColor=\"Blue\"\r\n                            VerticalOptions=\"Fill\" />\r\n                    </HorizontalStackLayout>";

    [ObservableProperty]
    string nestHorizontalStackLayoutObjectXamlCode = "<HorizontalStackLayout Margin=\"20\" Spacing=\"6\">\r\n                        <Label Text=\"Primary colors:\" TextColor=\"Blue\" />\r\n                        <VerticalStackLayout Spacing=\"6\">\r\n                            <Rectangle\r\n                                Fill=\"Red\"\r\n                                HeightRequest=\"30\"\r\n                                WidthRequest=\"30\" />\r\n                            <Rectangle\r\n                                Fill=\"Yellow\"\r\n                                HeightRequest=\"30\"\r\n                                WidthRequest=\"30\" />\r\n                            <Rectangle\r\n                                Fill=\"Blue\"\r\n                                HeightRequest=\"30\"\r\n                                WidthRequest=\"30\" />\r\n                        </VerticalStackLayout>\r\n                        <Label Text=\"Secondary colors:\" TextColor=\"Blue\" />\r\n                        <VerticalStackLayout Spacing=\"6\">\r\n                            <Rectangle\r\n                                Fill=\"Green\"\r\n                                HeightRequest=\"30\"\r\n                                WidthRequest=\"30\" />\r\n                            <Rectangle\r\n                                Fill=\"Orange\"\r\n                                HeightRequest=\"30\"\r\n                                WidthRequest=\"30\" />\r\n                            <Rectangle\r\n                                Fill=\"Purple\"\r\n                                HeightRequest=\"30\"\r\n                                WidthRequest=\"30\" />\r\n                        </VerticalStackLayout>\r\n                    </HorizontalStackLayout>";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

    }
    #endregion
}