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
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string standardCreateFrameXamlCode =
        "<Frame>\r\n" +
        "   <Label Text=\"Frame wrapped around a Label\" \r\n" +
        "          TextColor=\"White\"/>\r\n" +
        "</Frame>";

    [ObservableProperty]
    string createTheSecondFrameXamlCode =
        "<Frame BackgroundColor=\"DimGrey\"\r\n" +
        "       BorderColor=\"Grey\"\r\n" +
        "       CornerRadius=\"10\">\r\n" +
        "   <Label Text=\"Frame wrapped around a Label\" />\r\n" +
        "</Frame>";

    [ObservableProperty]
    string createACardWithAFrameXamlCode =
        "<Frame Padding=\"10\"\r\n" +
        "       BorderColor=\"Gray\"\r\n" +
        "       BackgroundColor=\"White\"\r\n" +
        "       CornerRadius=\"8\">\r\n" +
        "   <StackLayout>\r\n" +
        "       <Label FontAttributes=\"Bold\"\r\n" +
        "              FontSize=\"14\"\r\n" +
        "              Text=\"Card Example\" />\r\n" +
        "       <BoxView HeightRequest=\"2\"\r\n" +
        "                HorizontalOptions=\"Fill\"\r\n" +
        "                Color=\"Gray\" />\r\n" +
        "       <Label Text=\"Frames can wrap more complex layouts to create more complex UI components, such as this card!\" />\r\n" +
        "   </StackLayout>\r\n" +
        "</Frame>";

    [ObservableProperty]
    string roundElementsXamlCode =
        "<Frame BorderColor=\"Black\"\r\n" +
        "       Padding=\"20\"\r\n" +
        "       CornerRadius=\"60\"\r\n" +
        "       HeightRequest=\"120\"\r\n" +
        "       WidthRequest=\"120\"\r\n" +
        "       HorizontalOptions=\"Center\"\r\n" +
        "       VerticalOptions=\"Center\"\r\n" +
        "       IsClippedToBounds=\"True\">\r\n" +
        "   <Image VerticalOptions=\"Center\"\r\n" +
        "          HorizontalOptions=\"Center\"\r\n" +
        "          HeightRequest=\"80\"\r\n" +
        "          WidthRequest=\"80\"\r\n" +
        "          Source=\"{x:Binding ControlInformation.ControlIcon}\" />\r\n" +
        "</Frame>";
    
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}