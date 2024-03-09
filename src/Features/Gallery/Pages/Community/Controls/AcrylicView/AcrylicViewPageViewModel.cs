namespace MAUIsland;
public partial class AcrylicViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public AcrylicViewPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string getStartedCode =
    "using Xe.AcrylicView;\r\n" +
    "\r\n" +
    "public static class MauiProgram\r\n" +
    "{\r\n" +
    "    public static MauiApp CreateMauiApp()\r\n" +
    "    {\r\n" +
    "        var builder = MauiApp.CreateBuilder();\r\n" +
    "        builder\r\n" +
    "            .UseMauiApp<App>()\r\n" +
    "            .UseAcrylicView()\r\n" +
    "            .ConfigureFonts(fonts =>\r\n" +
    "            {\r\n" +
    "                fonts.AddFont(\"OpenSans-Regular.ttf\", \"OpenSansRegular\");\r\n" +
    "                fonts.AddFont(\"OpenSans-Semibold.ttf\", \"OpenSansSemibold\");\r\n" +
    "            });\r\n" +
    "        return builder.Build();\r\n" +
    "    }\r\n" +
    "}";


    [ObservableProperty]
    string acrylicViewXamlCode =
    "<VerticalStackLayout Spacing=\"10\">\r\n" +
    "    <Label Text=\"AcrylicView\" />\r\n" +
    "    <Grid>\r\n" +
    "        <skia:SKLottieView\r\n" +
    "            HeightRequest=\"100\"\r\n" +
    "            HorizontalOptions=\"Center\"\r\n" +
    "            RepeatCount=\"-1\"\r\n" +
    "            SemanticProperties.Description=\"Cute dot net bot waving hi to you!\"\r\n" +
    "            Source=\"dotnetbot.json\"\r\n" +
    "            VerticalOptions=\"Center\"\r\n" +
    "            WidthRequest=\"100\" />\r\n" +
    "        <ui:AcrylicView\r\n" +
    "            Margin=\"10\"\r\n" +
    "            BorderColor=\"OrangeRed\"\r\n" +
    "            BorderThickness=\"1,2\"\r\n" +
    "            CornerRadius=\"50,10,30,20\"\r\n" +
    "            EffectStyle=\"Custom\"\r\n" +
    "            HeightRequest=\"100\"\r\n" +
    "            TintColor=\"OrangeRed\"\r\n" +
    "            TintOpacity=\".15 \"\r\n" +
    "            VerticalOptions=\"Center\">\r\n" +
    "            <Grid>\r\n" +
    "                <Label\r\n" +
    "                    FontSize=\"25\"\r\n" +
    "                    HorizontalOptions=\"Center\"\r\n" +
    "                    Text=\"Hello Word\"\r\n" +
    "                    TextColor=\"OrangeRed\"\r\n" +
    "                    VerticalOptions=\"Center\" />\r\n" +
    "            </Grid>\r\n" +
    "        </ui:AcrylicView>\r\n" +
    "    </Grid>\r\n" +
    "</VerticalStackLayout>";

    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion

    #region [ Relay commands ]


    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);


    [RelayCommand]
    async Task CopyToClipboardAsync(string text)
    {
        await Clipboard.Default.SetTextAsync(text);
        await AppNavigator.ShowSnackbarAsync("Code copied to clipboard", null, null);
    }
    #endregion
}