using MAUIsland.GitHubFeatures;

namespace MAUIsland;

public partial class SearchBarPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    private readonly IControlsService mauiControlsService;
    #endregion

    #region [CTor]
    public SearchBarPageViewModel(IAppNavigator appNavigator,
                                  IGitHubService gitHubService,
                                  IControlsService mauiControlsService)
                                : base(appNavigator)
    {
        this.gitHubService = gitHubService;
        this.mauiControlsService = mauiControlsService;
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string searchText = string.Empty;

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
    ObservableCollection<IGalleryCardInfo> controlGroupListForEventCall;

    [ObservableProperty]
    ObservableCollection<IGalleryCardInfo> controlGroupListForCommandCall;

    [ObservableProperty]
    string standardSearchBarXamlCode = "<SearchBar Placeholder=\"Search items...\" />";

    [ObservableProperty]
    string performASearchWithEventHandlersXamlCode =
        "<SearchBar Placeholder=\"Search items...\"\r\n" +
        "           x:Name=\"EventHandlerSearchBar\"\r\n" +
        "           TextChanged=\"OnSearchAsync\"/>";

    [ObservableProperty]
    string performASearchWithEventHandlersCSCode =
        "private async void OnSearchAsync(object sender, TextChangedEventArgs args)\r\n" +
        "{\r\n        ViewModel.ControlGroupList.Clear();\r\n\r\n" +
        "    var items = await mauiControlsService.GetControlsAsync(ViewModel.ControlInformation.GroupName);\r\n\r\n" +
        "    var filtered = items.Where(x => x.ControlName.ToLower().Contains(EventHandlerSearchBar.Text.ToLower(), StringComparison.OrdinalIgnoreCase));\r\n\r\n" +
        "    foreach (var item in filtered)\r\n" +
        "    {\r\n" +
        "        ViewModel.ControlGroupList.Add(item);\r\n" +
        "    }\r\n" +
        "}";

    [ObservableProperty]
    string performASearchWithViewModelXamlCode =
        "<SearchBar Placeholder=\"Search items...\"\r\n" +
        "           x:Name=\"ViewModelSearchBar\"\r\n" +
        "           Text=\"{x:Binding SearchText}\"/>";

    [ObservableProperty]
    string performASearchWithViewModelCSCode =
        "[ObservableProperty]\r\n" +
        "[NotifyCanExecuteChangedFor(nameof(SearchCommand))]\r\n" +
        "string searchText = string.Empty;\r\n\r\n" +
        "partial void OnSearchTextChanged(string value)\r\n" +
        "{\r\n" +
        "    SearchCommand.ExecuteAsync(null);\r\n" +
        "}\r\n\r\n" +
        "[RelayCommand]\r\n" +
        "private async Task SearchAsync(string query)\r\n" +
        "{\r\n" +
        "    ControlGroupList.Clear();\r\n\r\n" +
        "    var items = await mauiControlsService.GetControlsAsync(ControlInformation.GroupName);\r\n\r\n" +
        "    foreach (var item in items.Where(x => x.ControlName.ToLower().Contains(SearchText.ToLower())))\r\n" +
        "    {\r\n" +
        "        ControlGroupList.Add(item);\r\n" +
        "    }\r\n" +
        "}";
    #endregion

    #region [ Overrides ]

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
        ControlGroupListForEventCall = new ObservableCollection<IGalleryCardInfo>();
        ControlGroupListForCommandCall = new ObservableCollection<IGalleryCardInfo>();
        ControlInformation = query.GetData<IBuiltInGalleryCardInfo>();

        LoadDataAsync().FireAndForget();
    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
        await RefreshAsync();
    }

    [RelayCommand]
    async Task RefreshAsync()
    {
        await RefreshControlIssues(true);
    }
    #endregion

    #region [ Methods ]
    partial void OnSearchTextChanged(string value)
    {
        SearchCommand.ExecuteAsync(null);
    }
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

    #region [ Relay Commands ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    private async Task SearchAsync()
    {
        ControlGroupListForCommandCall.Clear();

        var items = await mauiControlsService.GetControlsAsync(ControlInformation.GroupName);

        foreach (var item in items.Where(x => x.ControlName.ToLower().Contains(SearchText.ToLower())))
        {
            ControlGroupListForCommandCall.Add(item);
        }
    }
    #endregion

    #region [Data]
    private async Task LoadDataAsync()
    {
        ControlGroupListForEventCall.Clear();
        ControlGroupListForCommandCall.Clear();

        var items = await mauiControlsService.GetControlsAsync(ControlInformation.GroupName);

        foreach (var item in items)
        {
            ControlGroupListForEventCall.Add(item);
            ControlGroupListForCommandCall.Add(item);
        }
        return;
    }
    #endregion
}