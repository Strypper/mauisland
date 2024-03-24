using MAUIsland.GitHubFeatures;

namespace MAUIsland;


public partial class RefreshViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public RefreshViewPageViewModel(IAppNavigator appNavigator,
                                    IGitHubService gitHubService)
                                        : base(appNavigator)
    {
        this.gitHubService = gitHubService;
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string emptyViewText = "No issues found for this control";

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
    ObservableCollection<DemoItem> items;

    [ObservableProperty]
    string refreshViewXamlCode =
    "<RefreshView\r\n" +
    "    Command=\"{Binding RefreshCommand}\"\r\n" +
    "    HorizontalOptions=\"Start\"\r\n" +
    "    IsRefreshing=\"{x:Binding IsBusy}\"\r\n" +
    "    MaximumWidthRequest=\"300\">\r\n" +
    "    <CollectionView ItemTemplate=\"{x:StaticResource DemoItemTemplate}\" ItemsSource=\"{x:Binding Items}\" />\r\n" +
    "</RefreshView>";

    [ObservableProperty]
    string refreshCommandCSharpCode =
    "[RelayCommand]\n" +
    "async Task RefreshAsync()\n" +
    "{\n" +
    "    IsBusy = true;\n" +
    "    Items.Add(new DemoItem(\"new Item\", DateTime.Now));\n" +
    "    await AppNavigator.ShowSnackbarAsync(\"You triggered refresh\", null, \"Ok\");\n" +
    "    IsBusy = false;\n" +
    "}";

    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        Items = new();
        ControlInformation = query.GetData<IBuiltInGalleryCardInfo>();
    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
        await RefreshPageAsync();

        Items.Add(new DemoItem("Item1", DateTime.Now));
    }
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    async Task RefreshAsync()
    {
        IsBusy = true;
        Items.Add(new DemoItem("new Item", DateTime.Now));
        await AppNavigator.ShowSnackbarAsync("You triggered refresh", null, "Ok");
        IsBusy = false;
    }

    [RelayCommand]
    async Task RefreshPageAsync()
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

public record DemoItem(string name, DateTime time);