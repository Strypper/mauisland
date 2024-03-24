using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland;

public partial class ActivityIndicatorPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    private readonly IGitHubIssueLocalDbService gitHubIssueLocalDbService;
    #endregion

    #region [ CTor ]
    public ActivityIndicatorPageViewModel(IAppNavigator appNavigator,
                                          IGitHubService gitHubService,
                                          IGitHubIssueLocalDbService gitHubIssueLocalDbService)
                                                : base(appNavigator)
    {
        this.gitHubService = gitHubService;
        this.gitHubIssueLocalDbService = gitHubIssueLocalDbService;
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
    string groupOfActivityIndicators =
    "<HorizontalStackLayout HorizontalOptions=\"Start\" Spacing=\"10\">\r\n" +
    "    <ActivityIndicator IsRunning=\"True\" />\r\n" +
    "\r\n" +
    "    <ActivityIndicator IsRunning=\"True\" Color=\"Green\" />\r\n" +
    "\r\n" +
    "    <ActivityIndicator IsRunning=\"True\" Color=\"Red\" />\r\n" +
    "\r\n" +
    "    <ActivityIndicator IsRunning=\"true\" Color=\"Aqua\" />\r\n" +
    "</HorizontalStackLayout>";


    [ObservableProperty]
    string bindingActivityIndicators =
    "<VerticalStackLayout Spacing=\"5\">\r\n" +
    "    <HorizontalStackLayout Spacing=\"10\">\r\n" +
    "        <Picker\r\n" +
    "            x:Name=\"ActivityIndicatorColorPicker\"\r\n" +
    "            Title=\"Choose Color\"\r\n" +
    "            BackgroundColor=\"#512bd4\"\r\n" +
    "            ItemsSource=\"{x:StaticResource ActivityIndicatorColorResource}\"\r\n" +
    "            VerticalOptions=\"Center\" />\r\n" +
    "        <Switch\r\n" +
    "            x:Name=\"ActivityIndicatorSwitch\"\r\n" +
    "            IsToggled=\"True\"\r\n" +
    "            VerticalOptions=\"End\" />\r\n" +
    "    </HorizontalStackLayout>\r\n" +
    "    <ActivityIndicator\r\n" +
    "        HorizontalOptions=\"Start\"\r\n" +
    "        IsRunning=\"{x:Binding Source={x:Reference ActivityIndicatorSwitch},\r\n" +
    "                              Path=IsToggled}\"\r\n" +
    "        Color=\"{x:Binding Source={x:Reference ActivityIndicatorColorPicker},\r\n" +
    "                          Path=SelectedItem,\r\n" +
    "                          Converter={x:StaticResource StringToColorConverter}}\" />\r\n" +
    "    <core:SourceCodeExpander Code=\"{x:Binding BindingActivityIndicators}\" />\r\n" +
    "</VerticalStackLayout>";

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

        var now = DateTime.UtcNow;

        // First: sync from local db.
        // TODO: how to get control name?
        var allLocalDbIssues = await GetIssueByControlNameFromLocalDb(ControlInformation.ControlName);

        // If localdb version is not null & not outdated => use local version.
        if (allLocalDbIssues != null && allLocalDbIssues.Any() && !allLocalDbIssues.Any(x => (now - x.LastUpdated).TotalHours > 1))
        {
            if (ControlIssues is null || forced)
            {
                ControlIssues = new(allLocalDbIssues.Select(x => new ControlIssueModel()
                {
                    IssueId = x.IssueId,
                    Title = x.Title,
                    IssueLinkUrl = x.IssueLinkUrl,
                    MileStone = x.MileStone,
                    OwnerName = x.OwnerName,
                    AvatarUrl = x.UserAvatarUrl,
                    CreatedDate = x.CreatedDate,
                    LastUpdated = x.LastUpdated
                }));
            }
            IsBusy = false;

            // Done.
            return;
        }

        // If localdb does not have issue info, or info outdated => sync from GitHub & save.
        var result = await gitHubService.GetGitHubIssuesByLabels(ControlInformation.GitHubAuthorIssueName,
                                                                 ControlInformation.GitHubRepositoryIssueName,
                                                                 ControlInformation.GitHubIssueLabels);


        if (result.IsT0) // Check if result is ServiceSuccess
        {
            var issues = result.AsT0.AttachedData as IEnumerable<GitHubIssueModel>;

            // Save to localdb.
            foreach (var issue in issues)
            {
                await UpdateLocalIssue(issue);
            }

            IsBusy = false;

            if (ControlIssues is null || forced)
            {
                ControlIssues = new(issues.Select(x => new ControlIssueModel()
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
            IsBusy = false;

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

    #region [ Methods - GitHub Issues - LocalDb ]
    private async Task<IEnumerable<GitHubIssueLocalDbModel>> GetIssueByControlNameFromLocalDb(string controlName)
    {
        try
        {
            var now = DateTime.UtcNow;

            return await gitHubIssueLocalDbService.GetByControlNameAsync(controlName);
        }
        catch (Exception)
        {
            // Treat as nothing found.
            return default;
        }
    }

    private async Task UpdateLocalIssue(GitHubIssueModel issue)
    {
        try
        {
            var now = DateTime.UtcNow;

            var localIssue = await gitHubIssueLocalDbService.GetByIssueUrlAsync(issue.Url);

            if (localIssue is null)
            {
                await gitHubIssueLocalDbService.AddAsync(new()
                {
                    IssueId = issue.Id,
                    Title = issue.Title,
                    IssueLinkUrl = issue.Url,
                    ControlName = ControlInformation.ControlName,
                    MileStone = issue.Milestone?.Title,
                    OwnerName = issue.User?.Login,
                    UserAvatarUrl = issue.User?.AvatarUrl,
                    CreatedDate = issue.CreatedAt.DateTime,
                    LastUpdated = now
                });
                return;
            }

            // Update fields: milestone (TODO: what else?).
            localIssue.MileStone = issue.Milestone?.Title;
            localIssue.LastUpdated = now;

            await gitHubIssueLocalDbService.UpdateAsync(localIssue);
        }
        catch (Exception)
        {
            // TODO: should do something.
            return;
        }
    }
    #endregion
}
