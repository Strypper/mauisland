using MAUIsland.GitHubFeatures;

namespace MAUIsland;

public partial class ProgressBarPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public ProgressBarPageViewModel(IAppNavigator appNavigator,
                                    IGitHubService gitHubService)
                                        : base(appNavigator)
    {
        this.gitHubService = gitHubService;
    }
    #endregion

    #region [ Property ]

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
    string xamlStandardProgressBar =
        "<ProgressBar Progress=\"0\"/>\r\n" +
        "<ProgressBar Progress=\"0.5\"/>\r\n" +
        "<ProgressBar Progress=\"1\"/>\r\n";

    [ObservableProperty]
    string xamlColorProgressBar =
        "<Grid ColumnDefinitions=\"0.1*, 0.6*, 0.1*, 0.2*\">\r\n" +
        "   <Label Grid.Column=\"0\"\r\n" +
        "          Text=\"0%\" \r\n" +
        "          VerticalOptions=\"Center\" \r\n" +
        "          HorizontalOptions=\"Center\"/>\r\n" +
        "   <ProgressBar x:Name=\"ProgressBar1\"\r\n" +
        "                Grid.Column=\"1\"\r\n" +
        "                Progress=\"0\"/>\r\n" +
        "   <Label x:Name=\"ProgressLabel\" \r\n" +
        "          Grid.Column=\"2\"\r\n" +
        "          Text=\"0%\" \r\n" +
        "          VerticalOptions=\"Center\" \r\n" +
        "          HorizontalOptions=\"Center\"/>\r\n" +
        "   <Button x:Name=\"ProgressBarLoadButton\"\r\n" +
        "           Grid.Column=\"3\"\r\n" +
        "           Clicked=\"ProgressBarLoadButtonClicked\"\r\n" +
        "           Text=\"Load\"/>\r\n" +
        "</Grid>";

    [ObservableProperty]
    string cSharpCcolorProgressBarCodeBehind =
        "private async void ProgressBarLoadButtonClicked(object sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    Progress = 0;\r\n\r\n" +
        "    while (Progress < 1)\r\n" +
        "    {\r\n" +
        "        if(Progress == 0)\r\n" +
        "        {\r\n" +
        "            ProgressBar1.ProgressColor = Colors.Red;\r\n" +
        "        }\r\n" +
        "        Progress += 0.01;\r\n" +
        "        await Task.Delay(1);\r\n" +
        "        var progressIntValue = Progress * 100;\r\n" +
        "        ProgressLabel.Text = $\"{progressIntValue:N1}%\";\r\n" +
        "        switch ((int)progressIntValue)\r\n" +
        "        {\r\n" +
        "            case 30:\r\n" +
        "                ProgressBar1.ProgressColor = Colors.OrangeRed;\r\n" +
        "                break;\r\n" +
        "            case 50:\r\n" +
        "                ProgressBar1.ProgressColor = Colors.Orange;\r\n" +
        "                break;\r\n" +
        "            case 80:\r\n" +
        "                ProgressBar1.ProgressColor = Colors.Yellow;\r\n" +
        "                break;\r\n" +
        "            case 90:\r\n" +
        "                ProgressBar1.ProgressColor = Colors.YellowGreen;\r\n" +
        "                break;\r\n" +
        "            case 100:\r\n" +
        "                ProgressBar1.ProgressColor = Colors.Green;\r\n" +
        "                break;\r\n" +
        "        }\r\n" +
        "        ProgressBar1.Progress = Progress;\r\n" +
        "    }\r\n" +
        "}";

    [ObservableProperty]
    string xamlAnimateProgressBar =
    "<ProgressBar\r\n" +
    "    x:Name=\"ProgressBar2\"\r\n" +
    "    Grid.Column=\"1\"\r\n" +
    "    Margin=\"10\"\r\n" +
    "    Progress=\"0\"\r\n" +
    "    ProgressColor=\"Red\" />";

    [ObservableProperty]
    string cSharpAnimateProgressBarCodeBehind =
        "private async void ProgressBarRunButtonClicked(object sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    ProgressBar2.Progress = 0;\r\n" +
        "    ProgressBarRunButton.IsEnabled= false;\r\n" +
        "    await ProgressBar2.ProgressTo(0.999, 5000, Easing.BounceIn);\r\n" +
        "    ProgressBarRunButton.IsEnabled= true;\r\n" +
        "}";

    [ObservableProperty]
    string cSharpAnimateProgressBarConverter =
        "public class ProgressBarPercentageConverter : IValueConverter\r\n" +
        "{\r\n" +
        "    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)\r\n" +
        "    {\r\n" +
        "        double temp = (double)value * 100;\r\n" +
        "        return $\"{temp:N1}%\";\r\n" +
        "    }\r\n\r\n" +
        "    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)\r\n" +
        "    {\r\n" +
        "        double temp = (double)value / 100;\r\n" +
        "        return $\"{temp:N1}%\";\r\n" +
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
