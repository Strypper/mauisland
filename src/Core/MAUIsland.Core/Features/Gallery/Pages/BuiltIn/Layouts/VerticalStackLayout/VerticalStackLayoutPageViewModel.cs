using DiscordRPC;
using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;
public partial class VerticalStackLayoutPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public VerticalStackLayoutPageViewModel(IAppNavigator appNavigator,
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
    string verticalStackLayoutLabelRectangleXamlCode = "<VerticalStackLayout Margin=\"20\">\r\n                        <Label Text=\"Primary colors\" TextColor=\"Blue\" />\r\n                        <Rectangle\r\n                            Fill=\"Red\"\r\n                            HeightRequest=\"30\"\r\n                            WidthRequest=\"300\" />\r\n                        <Rectangle\r\n                            Fill=\"Yellow\"\r\n                            HeightRequest=\"30\"\r\n                            WidthRequest=\"300\" />\r\n                        <Rectangle\r\n                            Fill=\"Blue\"\r\n                            HeightRequest=\"30\"\r\n                            WidthRequest=\"300\" />\r\n                        <Label Text=\"Secondary colors\" TextColor=\"Blue\" />\r\n                        <Rectangle\r\n                            Fill=\"Green\"\r\n                            HeightRequest=\"30\"\r\n                            WidthRequest=\"300\" />\r\n                        <Rectangle\r\n                            Fill=\"Orange\"\r\n                            HeightRequest=\"30\"\r\n                            WidthRequest=\"300\" />\r\n                        <Rectangle\r\n                            Fill=\"Purple\"\r\n                            HeightRequest=\"30\"\r\n                            WidthRequest=\"300\" />\r\n                    </VerticalStackLayout>";

    [ObservableProperty]
    string spaceBetweenChildViewsXamlCode = "<VerticalStackLayout Margin=\"20\" Spacing=\"8\">\r\n                        <Label Text=\"Primary colors\" TextColor=\"Blue\" />\r\n                        <Rectangle\r\n                            Fill=\"Red\"\r\n                            HeightRequest=\"30\"\r\n                            WidthRequest=\"300\" />\r\n                        <Rectangle\r\n                            Fill=\"Yellow\"\r\n                            HeightRequest=\"30\"\r\n                            WidthRequest=\"300\" />\r\n                        <Rectangle\r\n                            Fill=\"Blue\"\r\n                            HeightRequest=\"30\"\r\n                            WidthRequest=\"300\" />\r\n                        <Label Text=\"Secondary colors\" TextColor=\"Blue\" />\r\n                        <Rectangle\r\n                            Fill=\"Green\"\r\n                            HeightRequest=\"30\"\r\n                            WidthRequest=\"300\" />\r\n                        <Rectangle\r\n                            Fill=\"Orange\"\r\n                            HeightRequest=\"30\"\r\n                            WidthRequest=\"300\" />\r\n                        <Rectangle\r\n                            Fill=\"Purple\"\r\n                            HeightRequest=\"30\"\r\n                            WidthRequest=\"300\" />\r\n                    </VerticalStackLayout>";

    [ObservableProperty]
    string positionAndSizeChildViewsXamlCode = "<VerticalStackLayout Margin=\"20\" Spacing=\"6\">\r\n                        <Label\r\n                            BackgroundColor=\"Gray\"\r\n                            HorizontalOptions=\"Start\"\r\n                            Text=\"Start\"\r\n                            TextColor=\"blue\" />\r\n                        <Label\r\n                            BackgroundColor=\"Gray\"\r\n                            HorizontalOptions=\"Center\"\r\n                            Text=\"Center\"\r\n                            TextColor=\"blue\" />\r\n                        <Label\r\n                            BackgroundColor=\"Gray\"\r\n                            HorizontalOptions=\"End\"\r\n                            Text=\"End\"\r\n                            TextColor=\"blue\" />\r\n                        <Label\r\n                            BackgroundColor=\"Gray\"\r\n                            HorizontalOptions=\"Fill\"\r\n                            Text=\"Fill\"\r\n                            TextColor=\"blue\" />\r\n                    </VerticalStackLayout>";

    [ObservableProperty]
    string nestVerticalStackLayoutObjectsXamlCode = "<VerticalStackLayout Margin=\"20\" Spacing=\"8\">\r\n                    <Label Text=\"Primary colors\" TextColor=\"Blue\" />\r\n                    <Frame Padding=\"8\" BorderColor=\"white\">\r\n                        <HorizontalStackLayout Spacing=\"15\">\r\n                            <Rectangle\r\n                                Fill=\"Red\"\r\n                                HeightRequest=\"30\"\r\n                                WidthRequest=\"30\" />\r\n                            <Label FontSize=\"18\" Text=\"Red\" />\r\n                        </HorizontalStackLayout>\r\n                    </Frame>\r\n                    <Frame Padding=\"8\" BorderColor=\"white\">\r\n                        <HorizontalStackLayout Spacing=\"15\">\r\n                            <Rectangle\r\n                                Fill=\"Yellow\"\r\n                                HeightRequest=\"30\"\r\n                                WidthRequest=\"30\" />\r\n                            <Label FontSize=\"18\" Text=\"Yellow\" />\r\n                        </HorizontalStackLayout>\r\n                    </Frame>\r\n                    <Frame Padding=\"8\" BorderColor=\"white\">\r\n                        <HorizontalStackLayout Spacing=\"15\">\r\n                            <Rectangle\r\n                                Fill=\"Blue\"\r\n                                HeightRequest=\"30\"\r\n                                WidthRequest=\"30\" />\r\n                            <Label FontSize=\"18\" Text=\"Blue\" />\r\n                        </HorizontalStackLayout>\r\n                    </Frame>\r\n                </VerticalStackLayout>";
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