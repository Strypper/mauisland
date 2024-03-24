using MAUIsland.GitHubFeatures;

namespace MAUIsland;
public partial class PopupPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public PopupPageViewModel(IAppNavigator appNavigator,
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
    string standardPopupCSharpCode =
    "private async void Button_Clicked(object sender, EventArgs e)\r\n" +
    "{\r\n" +
    "    await DisplayAlert(\"Sample Popup Alert\", \"You have been alerted\", \"OK\");\r\n" +
    "}";

    [ObservableProperty]
    string captureResponsePopupCSharpCode =
        "private async void Button_Clicked_1(object sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    bool answer = await DisplayAlert(\"Question?\", \"Would you like to play a game\", \"Yes\",\"No\");\r\n" +
        "    await DisplayAlert(\"Answer\",$\"Answer is {( answer ? \"yes\" : \"no\")}\" , \"OK\");\r\n" +
        "}";

    [ObservableProperty]
    string actionSheetPopupCSharpCode =
        "private async void Button_Clicked_2(object sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    string answer = await DisplayActionSheet(\"What game do you wanna play?\", \"Cancel\", null, \"LOL\", \"Halo\", \"Dota2\");\r\n" +
        "    if (answer != \"Cancel\")\r\n" +
        "    {\r\n" +
        "        await DisplayAlert(\"Answer\", $\"{answer} is great!\", \"OK\");\r\n" +
        "    }\r\n" +
        "}";

    [ObservableProperty]
    string promptPopupCSharpCode =
        "private async void Button_Clicked_3(object sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    string answer = await DisplayPromptAsync(\"Hello\", \"What's your name?\",placeholder: \"Type your name\");\r\n" +
        "    if (answer != null) \r\n" +
        "    {\r\n" +
        "        await DisplayAlert(\"Welcome\", $\"Hello, {answer}\",\"Cancel\");\r\n" +
        "    }\r\n" +
        "}";

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