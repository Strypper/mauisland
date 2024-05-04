using DiscordRPC;
using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;
public partial class HorizontalStackLayoutPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public HorizontalStackLayoutPageViewModel(IAppNavigator appNavigator,
                                              IGitHubService gitHubService,
                                              DiscordRpcClient discordRpcClient,
                                              IGitHubIssueLocalDbService gitHubIssueLocalDbService)
                                                : base(appNavigator,
                                                       gitHubService,
                                                       discordRpcClient,
                                                       gitHubIssueLocalDbService)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string horizontalStackLayoutRectangleLabelXamlCode =
    "<HorizontalStackLayout Margin=\"20\">\r\n" +
    "    <Rectangle\r\n" +
    "        Fill=\"Red\"\r\n" +
    "        HeightRequest=\"30\"\r\n" +
    "        WidthRequest=\"30\" />\r\n" +
    "    <Label\r\n" +
    "        FontSize=\"18\"\r\n" +
    "        Text=\"Red\"\r\n" +
    "        TextColor=\"Blue\" />\r\n" +
    "</HorizontalStackLayout>";

    [ObservableProperty]
    string spaceBetweenChildViewsXamlCode =
        "<HorizontalStackLayout Margin=\"20\" Spacing=\"10\">\r\n" +
        "    <Rectangle\r\n" +
        "        Fill=\"Red\"\r\n" +
        "        HeightRequest=\"30\"\r\n" +
        "        WidthRequest=\"30\" />\r\n" +
        "    <Label\r\n" +
        "        FontSize=\"18\"\r\n" +
        "        Text=\"Red\"\r\n" +
        "        TextColor=\"Blue\" />\r\n" +
        "</HorizontalStackLayout>";

    [ObservableProperty]
    string positionAndSizeChildViewsXamlCode =
        "<HorizontalStackLayout Margin=\"20\" HeightRequest=\"200\">\r\n" +
        "    <Label\r\n" +
        "        BackgroundColor=\"Gray\"\r\n" +
        "        Text=\"Start\"\r\n" +
        "        TextColor=\"Blue\"\r\n" +
        "        VerticalOptions=\"Start\" />\r\n" +
        "    <Label\r\n" +
        "        BackgroundColor=\"Gray\"\r\n" +
        "        Text=\"Center\"\r\n" +
        "        TextColor=\"Blue\"\r\n" +
        "        VerticalOptions=\"Center\" />\r\n" +
        "    <Label\r\n" +
        "        BackgroundColor=\"Gray\"\r\n" +
        "        Text=\"End\"\r\n" +
        "        TextColor=\"Blue\"\r\n" +
        "        VerticalOptions=\"End\" />\r\n" +
        "    <Label\r\n" +
        "        BackgroundColor=\"Gray\"\r\n" +
        "        Text=\"Fill\"\r\n" +
        "        TextColor=\"Blue\"\r\n" +
        "        VerticalOptions=\"Fill\" />\r\n" +
        "</HorizontalStackLayout>";

    [ObservableProperty]
    string nestHorizontalStackLayoutObjectXamlCode =
        "<HorizontalStackLayout Margin=\"20\" Spacing=\"6\">\r\n" +
        "    <Label Text=\"Primary colors:\" TextColor=\"Blue\" />\r\n" +
        "    <VerticalStackLayout Spacing=\"6\">\r\n" +
        "        <Rectangle\r\n" +
        "            Fill=\"Red\"\r\n" +
        "            HeightRequest=\"30\"\r\n" +
        "            WidthRequest=\"30\" />\r\n" +
        "        <Rectangle\r\n" +
        "            Fill=\"Yellow\"\r\n" +
        "            HeightRequest=\"30\"\r\n" +
        "            WidthRequest=\"30\" />\r\n" +
        "        <Rectangle\r\n" +
        "            Fill=\"Blue\"\r\n" +
        "            HeightRequest=\"30\"\r\n" +
        "            WidthRequest=\"30\" />\r\n" +
        "    </VerticalStackLayout>\r\n" +
        "    <Label Text=\"Secondary colors:\" TextColor=\"Blue\" />\r\n" +
        "    <VerticalStackLayout Spacing=\"6\">\r\n" +
        "        <Rectangle\r\n" +
        "            Fill=\"Green\"\r\n" +
        "            HeightRequest=\"30\"\r\n" +
        "            WidthRequest=\"30\" />\r\n" +
        "        <Rectangle\r\n" +
        "            Fill=\"Orange\"\r\n" +
        "            HeightRequest=\"30\"\r\n" +
        "            WidthRequest=\"30\" />\r\n" +
        "        <Rectangle\r\n" +
        "            Fill=\"Purple\"\r\n" +
        "            HeightRequest=\"30\"\r\n" +
        "            WidthRequest=\"30\" />\r\n" +
        "    </VerticalStackLayout>\r\n" +
        "</HorizontalStackLayout>";

    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IBuiltInGalleryCardInfo>();

    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
        await RefreshAsync();
    }
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    async Task RefreshAsync()
    {
        if (ControlInformation is null)
            return;

        await RefreshControlIssues(true,
                                   ControlInformation.ControlName,
                                   ControlInformation.GitHubAuthorIssueName,
                                   ControlInformation.GitHubRepositoryIssueName,
                                   ControlInformation.GitHubIssueLabels);
    }
    #endregion
}