using MAUIsland.GitHubFeatures;

namespace MAUIsland;


public partial class SwipeViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public SwipeViewPageViewModel(IAppNavigator appNavigator,
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
    string standardSwipeViewXamlCode =
    "<SwipeView>\r\n" +
    "    <SwipeView.LeftItems>\r\n" +
    "        <SwipeItems>\r\n" +
    "            <SwipeItem\r\n" +
    "                BackgroundColor=\"LightGreen\"\r\n" +
    "                Command=\"{x:Binding FavoriteCommand}\"\r\n" +
    "                IconImageSource=\"favorite.png\"\r\n" +
    "                Text=\"Favorite\" />\r\n" +
    "            <SwipeItem\r\n" +
    "                BackgroundColor=\"LightPink\"\r\n" +
    "                Command=\"{x:Binding DeleteCommand}\"\r\n" +
    "                IconImageSource=\"delete.png\"\r\n" +
    "                Text=\"Delete\" />\r\n" +
    "        </SwipeItems>\r\n" +
    "    </SwipeView.LeftItems>\r\n" +
    "    <Grid\r\n" +
    "        BackgroundColor=\"DimGray\"\r\n" +
    "        HeightRequest=\"60\"\r\n" +
    "        WidthRequest=\"300\">\r\n" +
    "        <Label\r\n" +
    "            HorizontalOptions=\"Center\"\r\n" +
    "            Text=\"Swipe right\"\r\n" +
    "            VerticalOptions=\"Center\" />\r\n" +
    "    </Grid>\r\n" +
    "</SwipeView>";

    [ObservableProperty]
    string swipeItemsXamlCode =
        "<SwipeView>\r\n" +
        "    <SwipeView.LeftItems>\r\n" +
        "        <SwipeItems>\r\n" +
        "            <SwipeItem\r\n" +
        "                BackgroundColor=\"LightGreen\"\r\n" +
        "                IconImageSource=\"favorite.png\"\r\n" +
        "                Text=\"Favorite\" />\r\n" +
        "            <SwipeItem\r\n" +
        "                BackgroundColor=\"LightPink\"\r\n" +
        "                IconImageSource=\"delete.png\"\r\n" +
        "                Text=\"Delete\" />\r\n" +
        "        </SwipeItems>\r\n" +
        "    </SwipeView.LeftItems>\r\n" +
        "    <Grid\r\n" +
        "        BackgroundColor=\"ForestGreen\"\r\n" +
        "        HeightRequest=\"60\"\r\n" +
        "        WidthRequest=\"300\">\r\n" +
        "        <Label\r\n" +
        "            HorizontalOptions=\"Center\"\r\n" +
        "            Text=\"Swipe right\"\r\n" +
        "            VerticalOptions=\"Center\" />\r\n" +
        "    </Grid>\r\n" +
        "</SwipeView>";

    [ObservableProperty]
    string swipeDirectionXamlCode =
        "<SwipeView>\r\n" +
        "    <SwipeView.LeftItems>\r\n" +
        "        <SwipeItems Mode=\"Execute\">\r\n" +
        "            <SwipeItem\r\n" +
        "                BackgroundColor=\"LightPink\"\r\n" +
        "                Command=\"{x:Binding DeleteCommand}\"\r\n" +
        "                IconImageSource=\"delete.png\"\r\n" +
        "                Text=\"Delete\" />\r\n" +
        "        </SwipeItems>\r\n" +
        "    </SwipeView.LeftItems>\r\n" +
        "    <SwipeView.RightItems>\r\n" +
        "        <SwipeItems Mode=\"Reveal\">\r\n" +
        "            <SwipeItem\r\n" +
        "                BackgroundColor=\"LightGreen\"\r\n" +
        "                Command=\"{x:Binding FavoriteCommand}\"\r\n" +
        "                IconImageSource=\"favorite.png\"\r\n" +
        "                Text=\"Favorite\" />\r\n" +
        "            <SwipeItem\r\n" +
        "                BackgroundColor=\"LightYellow\"\r\n" +
        "                Command=\"{x:Binding ShareCommand}\"\r\n" +
        "                IconImageSource=\"share.png\"\r\n" +
        "                Text=\"Share\" />\r\n" +
        "        </SwipeItems>\r\n" +
        "    </SwipeView.RightItems>\r\n" +
        "    <Grid\r\n" +
        "        BackgroundColor=\"BlueViolet\"\r\n" +
        "        HeightRequest=\"60\"\r\n" +
        "        WidthRequest=\"300\">\r\n" +
        "        <Label\r\n" +
        "            HorizontalTextAlignment=\"Center\"\r\n" +
        "            Text=\"Swipe Right Or Left\"\r\n" +
        "            VerticalOptions=\"Center\" />\r\n" +
        "    </Grid>\r\n" +
        "</SwipeView>";

    [ObservableProperty]
    string swipeThresholdXamlCode =
        "<SwipeView Threshold=\"200\">\r\n" +
        "    <SwipeView.LeftItems>\r\n" +
        "        <SwipeItems>\r\n" +
        "            <SwipeItem\r\n" +
        "                BackgroundColor=\"LightGreen\"\r\n" +
        "                IconImageSource=\"favorite.png\"\r\n" +
        "                Text=\"Favorite\" />\r\n" +
        "        </SwipeItems>\r\n" +
        "    </SwipeView.LeftItems>\r\n" +
        "    <Grid\r\n" +
        "        BackgroundColor=\"Tomato\"\r\n" +
        "        HeightRequest=\"60\"\r\n" +
        "        WidthRequest=\"300\">\r\n" +
        "        <Label\r\n" +
        "            HorizontalTextAlignment=\"Center\"\r\n" +
        "            Text=\"Swipe Right\"\r\n" +
        "            VerticalOptions=\"Center\" />\r\n" +
        "    </Grid>\r\n" +
        "</SwipeView>";

    [ObservableProperty]
    string swipeModeXamlCode =
    "<SwipeView>\r\n" +
    "    <SwipeView.LeftItems>\r\n" +
    "        <SwipeItems Mode=\"Execute\">\r\n" +
    "            <SwipeItem\r\n" +
    "                BackgroundColor=\"LightPink\"\r\n" +
    "                Command=\"{x:Binding DeleteCommand}\"\r\n" +
    "                IconImageSource=\"delete.png\"\r\n" +
    "                Text=\"Delete\" />\r\n" +
    "        </SwipeItems>\r\n" +
    "    </SwipeView.LeftItems>\r\n" +
    "    <Grid\r\n" +
    "        BackgroundColor=\"LightCoral\"\r\n" +
    "        HeightRequest=\"60\"\r\n" +
    "        WidthRequest=\"300\">\r\n" +
    "        <Label\r\n" +
    "            HorizontalTextAlignment=\"Center\"\r\n" +
    "            Text=\"Swipe Right\"\r\n" +
    "            VerticalOptions=\"Center\" />\r\n" +
    "    </Grid>\r\n" +
    "</SwipeView>";

    [ObservableProperty]
    string swipeBehaviorXamlCode =
        "<SwipeView>\r\n" +
        "    <SwipeView.LeftItems>\r\n" +
        "        <SwipeItems SwipeBehaviorOnInvoked=\"RemainOpen\">\r\n" +
        "            <SwipeItem\r\n" +
        "                BackgroundColor=\"LightGreen\"\r\n" +
        "                IconImageSource=\"favorite.png\"\r\n" +
        "                Text=\"Favorite\" />\r\n" +
        "            <SwipeItem\r\n" +
        "                BackgroundColor=\"LightPink\"\r\n" +
        "                IconImageSource=\"delete.png\"\r\n" +
        "                Text=\"Delete\" />\r\n" +
        "        </SwipeItems>\r\n" +
        "    </SwipeView.LeftItems>\r\n" +
        "    <Grid\r\n" +
        "        BackgroundColor=\"Orchid\"\r\n" +
        "        HeightRequest=\"60\"\r\n" +
        "        WidthRequest=\"300\">\r\n" +
        "        <Label\r\n" +
        "            HorizontalTextAlignment=\"Center\"\r\n" +
        "            Text=\"Swipe Right\"\r\n" +
        "            VerticalOptions=\"Center\" />\r\n" +
        "    </Grid>\r\n" +
        "</SwipeView>";


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

    [RelayCommand]
    Task DeleteAsync()
    => AppNavigator.ShowSnackbarAsync("You triggered delete", null, "Ok");

    [RelayCommand]
    Task FavoriteAsync()
    => AppNavigator.ShowSnackbarAsync("You triggered favorite", null, "Ok");

    [RelayCommand]
    Task ShareAsync()
    => AppNavigator.ShowSnackbarAsync("You triggered share", null, "Ok");

    [RelayCommand]
    Task CheckAnswerAsync()
    => AppNavigator.ShowSnackbarAsync("You triggered check anwser", null, "Ok");
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