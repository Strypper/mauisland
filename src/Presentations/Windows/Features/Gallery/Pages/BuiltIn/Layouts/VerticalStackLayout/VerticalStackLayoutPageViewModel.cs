using MAUIsland.GitHubFeatures;

namespace MAUIsland;
public partial class VerticalStackLayoutPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion
    #region [ CTor ]
    public VerticalStackLayoutPageViewModel(IAppNavigator appNavigator,
                                            IGitHubService gitHubService)
                                                : base(appNavigator)
    {
        this.gitHubService = gitHubService;
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string emptyViewText = "Fetching issues";

    [ObservableProperty]
    string gitHubAPIRateLimit = "https://docs.github.com/en/rest/using-the-rest-api/rate-limits-for-the-rest-api?apiVersion=2022-11-28";

    [ObservableProperty]
    IBuiltInGalleryCardInfo controlInformation;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<ControlIssueModel> controlIssues;

    [ObservableProperty]
    ControlIssueModel selectedControlIssue;

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
        await RefreshControlIssues(true);
    }
    #endregion

    #region [ Methods ]

    async Task RefreshControlIssues(bool forced)
    {
        if (IsBusy)
            return;

        IsBusy = true;

        var result = await gitHubService.GetGitHubIssuesByLabels(ControlInformation.GitHubAuthorIssueName,
                                                                 ControlInformation.GitHubRepositoryIssueName,
                                                                 ControlInformation.GitHubIssueLabels);

        IsBusy = false;

        if (result.IsT0) // Check if result is ServiceSuccess
        {
            var items = result.AsT0.AttachedData as IEnumerable<GitHubIssueModel>;

            if (ControlIssues is null || forced)
            {
                ControlIssues = new(items.Select(x => new ControlIssueModel()
                {
                    IssueId = x.Id,
                    Title = x.Title,
                    IssueLinkUrl = x.HtmlUrl,
                    MileStone = x.Milestone is null ? "No mile stone" : x.Milestone.Title,
                    OwnerName = x.User.Login,
                    AvatarUrl = x.User.AvatarUrl,
                    CreatedDate = x.CreatedAt.DateTime,
                    LastUpdated = x.UpdatedAt is null ? x.CreatedAt.DateTime : x.UpdatedAt.Value.DateTime
                }));
            }
        }
        else
        {
            var error = result.AsT1;
            EmptyViewText = error.ErrorDetail;
            await AppNavigator.ShowSnackbarAsync(error.ErrorDetail,
                                                 async () =>
                                                 {
                                                     await AppNavigator.OpenUrlAsync(GitHubAPIRateLimit);
                                                 },
                                                 "Visit GitHub API Rate Limits Policies");
        }
    }
    #endregion
}