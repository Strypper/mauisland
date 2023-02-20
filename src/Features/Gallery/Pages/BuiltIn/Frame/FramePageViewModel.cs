namespace MAUIsland;
public partial class FramePageViewModel : NavigationAwareBaseViewModel
{

    #region [CTor]
    public FramePageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    string standardCreateFrameXamlCode = "<Frame>\r\n                        <Label Text=\"Frame wrapped around a Label\" />\r\n                    </Frame>";

    [ObservableProperty]
    string createTheSecondFrameXamlCode = "<Frame\r\n                        BackgroundColor=\"DimGrey\"\r\n                        BorderColor=\"Grey\"\r\n                        CornerRadius=\"10\">\r\n                        <Label Text=\"Frame wrapped around a Label\" />\r\n                    </Frame>";

    [ObservableProperty]
    string createACardWithAFrameXamlCode = "<Frame\r\n                        Padding=\"10\"\r\n                        BorderColor=\"Gray\"\r\n                        CornerRadius=\"8\">\r\n                        <StackLayout>\r\n                            <Label\r\n                                FontAttributes=\"Bold\"\r\n                                FontSize=\"14\"\r\n                                Text=\"Card Example\" />\r\n                            <BoxView\r\n                                HeightRequest=\"2\"\r\n                                HorizontalOptions=\"Fill\"\r\n                                Color=\"Gray\" />\r\n                            <Label Text=\"Frames can wrap more complex layouts to create more complex UI components, such as this card!\" />\r\n                        </StackLayout>\r\n                    </Frame>";

    [ObservableProperty]
    string roundElementsXamlCode = "<Frame\r\n                        Margin=\"10\"\r\n                        BorderColor=\"Black\"\r\n                        CornerRadius=\"50\"\r\n                        HeightRequest=\"60\"\r\n                        HorizontalOptions=\"Center\"\r\n                        IsClippedToBounds=\"True\"\r\n                        VerticalOptions=\"Center\"\r\n                        WidthRequest=\"60\">\r\n                        <Image\r\n                            Margin=\"-20\"\r\n                            Aspect=\"AspectFill\"\r\n                            HeightRequest=\"100\"\r\n                            Source=\"outdoors.jpg\"\r\n                            WidthRequest=\"100\" />\r\n                    </Frame>";
    
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