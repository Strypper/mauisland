using MAUIsland.GitHubFeatures;

namespace MAUIsland;

public partial class StepperPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public StepperPageViewModel(IAppNavigator appNavigator,
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
    string xamlStandardStepper =
        "<StackLayout Margin=\"20\">\r\n" +
        "   <Label x:Name=\"RotatingLabel\"\r\n" +
        "          Text=\"ROTATING TEXT\"\r\n" +
        "          FontSize=\"18\"\r\n" +
        "          VerticalOptions=\"Center\"\r\n" +
        "          HorizontalOptions=\"Center\" />\r\n" +
        "   <Stepper HorizontalOptions=\"Center\"\r\n" +
        "            Increment=\"30\"\r\n" +
        "            Maximum=\"360\"\r\n" +
        "            ValueChanged=\"OnStepperValueChanged\" />\r\n" +
        "   <Label x:Name=\"DisplayLabel\"\r\n" +
        "          Text=\"(uninitialized)\"\r\n" +
        "          HorizontalOptions=\"Center\"\r\n" +
        "          VerticalOptions=\"Center\" />\r\n" +
        "</StackLayout>";

    [ObservableProperty]
    string csharpStandardStepper =
        "private void OnStepperValueChanged(object sender, ValueChangedEventArgs e) \r\n" +
        "{\r\n" +
        "    double value = e.NewValue;\r\n" +
        "    RotatingLabel.Rotation = value;\r\n" +
        "    DisplayLabel.Text = string.Format(\"The Stepper value is {0}\", value);\r\n" +
        "}";

    [ObservableProperty]
    string xamlDataBindAStepper =
        "<StackLayout Margin=\"20\">\r\n" +
        "   <Label Rotation=\"{Binding Source={x:Reference MyStepper}, Path=Value}\"\r\n" +
        "          Text=\"ROTATING TEXT\"\r\n" +
        "          FontSize=\"18\"\r\n" +
        "          HorizontalOptions=\"Center\"\r\n" +
        "          VerticalOptions=\"Center\" />\r\n" +
        "   <Stepper x:Name=\"MyStepper\"\r\n" +
        "            HorizontalOptions=\"Center\"\r\n" +
        "            Increment=\"30\"\r\n" +
        "            Maximum=\"360\" />\r\n" +
        "   <Label Text=\"{Binding Source={x:Reference MyStepper}, Path=Value, StringFormat='The Stepper value is {0:F0}'}\"\r\n" +
        "          HorizontalOptions=\"Center\"\r\n" +
        "          VerticalOptions=\"Center\" />\r\n" +
        "</StackLayout>";

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
