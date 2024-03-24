using MAUIsland.GitHubFeatures;

namespace MAUIsland;
public partial class SwitchPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public SwitchPageViewModel(IAppNavigator appNavigator,
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
    string standardSwitchXamlCode =
        "<Switch IsToggled=\"True\"\r\n" +
        "        OnColor=\"Pink\"\r\n" +
        "        ThumbColor=\"ForestGreen\"/>";

    [ObservableProperty]
    string advanceSwitchXamlCode =
        "Data bind\r\n\r\n" +
        "<Label Margin=\"0,10,0,5\"\r\n" +
        "       FontSize=\"15\">\r\n" +
        "    <Label.Triggers>\r\n" +
        "        <DataTrigger TargetType=\"Label\"\r\n" +
        "                     Binding=\"{Binding Source={x:Reference switch2}, Path=IsToggled}\"\r\n" +
        "                     Value=\"True\">\r\n" +
        "            <Setter Property=\"Text\"\r\n" +
        "                    Value=\"The light is on 😊\"/>\r\n" +
        "            <Setter Property=\"TextColor\"\r\n" +
        "                    Value=\"Yellow\"/>\r\n" +
        "        </DataTrigger>\r\n" +
        "        <DataTrigger TargetType=\"Label\"\r\n" +
        "                     Binding=\"{Binding Source={x:Reference switch2}, Path=IsToggled}\"\r\n" +
        "                     Value=\"False\">\r\n" +
        "            <Setter Property=\"Text\"\r\n" +
        "                    Value=\"The light is off 😭\"/>\r\n" +
        "            <Setter Property=\"TextColor\"\r\n" +
        "                    Value=\"Gray\"/>\r\n" +
        "        </DataTrigger>\r\n" +
        "    </Label.Triggers>\r\n" +
        "</Label>\r\n\r\n" +
        "Visual States\r\n\r\n" +
        "<Switch x:Name=\"switch2\"\r\n" +
        "        OnColor=\"CadetBlue\">\r\n" +
        "    <VisualStateManager.VisualStateGroups>\r\n" +
        "        <VisualStateGroupList>\r\n" +
        "            <VisualStateGroup x:Name=\"SwitchCommonStates\">\r\n" +
        "                <VisualState x:Name=\"On\">\r\n" +
        "                    <VisualState.Setters>\r\n" +
        "                        <Setter Property=\"ThumbColor\"\r\n" +
        "                                Value=\"MediumSpringGreen\" />\r\n" +
        "                    </VisualState.Setters>\r\n" +
        "                </VisualState>\r\n" +
        "                <VisualState x:Name=\"Off\">\r\n" +
        "                    <VisualState.Setters>\r\n" +
        "                        <Setter Property=\"ThumbColor\"\r\n" +
        "                                Value=\"Red\" />\r\n" +
        "                    </VisualState.Setters>\r\n" +
        "                </VisualState>\r\n" +
        "            </VisualStateGroup>\r\n" +
        "        </VisualStateGroupList>\r\n" +
        "    </VisualStateManager.VisualStateGroups>\r\n" +
        "</Switch>";
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
