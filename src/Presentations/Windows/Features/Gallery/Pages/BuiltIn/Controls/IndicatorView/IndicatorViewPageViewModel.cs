using MAUIsland.GitHubFeatures;

namespace MAUIsland;


public partial class IndicatorViewPageViewModel : NavigationAwareBaseViewModel
{

    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public IndicatorViewPageViewModel(IAppNavigator appNavigator,
                                      IGitHubService gitHubService)
                                            : base(appNavigator)
    {
        this.gitHubService = gitHubService;
    }
    #endregion


    #region [Properties]

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
    string standardIndicatorViewXamlCode = "<StackLayout HorizontalOptions=\"Start\">\r\n    <CarouselView ItemsSource=\"{Binding Cats}\"\r\n                  WidthRequest=\"120\"\r\n                  HorizontalScrollBarVisibility=\"Never\"\r\n                  IndicatorView=\"indicatorView1\"\r\n                  Loop=\"False\"\r\n                  ItemTemplate=\"{x:StaticResource CarouseViewTemplate1}\"/>\r\n    <IndicatorView x:Name=\"indicatorView1\"\r\n                   IndicatorColor=\"LightGray\"\r\n                   SelectedIndicatorColor=\"DarkGray\"/>\r\n</StackLayout>";

    [ObservableProperty]
    List<Cats> cats = new List<Cats>()
    {
        new Cats()
        {
            Name = "Polydactyl",
            Description = "Cat1"
        },
        new Cats()
        {
            Name = "Snowshoe",
            Description = "Cat2"
        },new Cats()
        {
            Name = "British Shorthair",
            Description = "Cat3"
        },new Cats()
        {
            Name = "Gray Tabby",
            Description = "Cat4"
        }
    };
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

