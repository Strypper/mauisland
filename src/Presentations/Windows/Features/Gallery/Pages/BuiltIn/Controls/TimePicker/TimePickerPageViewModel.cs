using MAUIsland.GitHubFeatures;

namespace MAUIsland;


public partial class TimePickerPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public TimePickerPageViewModel(IAppNavigator appNavigator,
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
    string simpleTimePickerXamlCode =
    "<TimePicker Time=\"4:15:26\" />";

    [ObservableProperty]
    string simpleTimePickerCSharpCode =
        "TimePicker timePicker = new TimePicker\r\n" +
        "{\r\n" +
        "    Time = new TimeSpan(4, 15, 26) // Time set to \"04:15:26\"\r\n" +
        "};";

    [ObservableProperty]
    string timeOnlyContrutorsExampleCSharpCode =
        "public TimeOnly(int hour, int minute)\r\n" +
        "public TimeOnly(int hour, int minute, int second)\r\n" +
        "public TimeOnly(int hour, int minute, int second, int millisecond)";

    [ObservableProperty]
    string timeOnlyExampleCSharpCode =
        "var startTime = new TimeOnly(10, 30);";

    [ObservableProperty]
    string timeOnyToTimeSpanConverterCSharpCode =
        "public class TimeOnyToTimeSpanConverter : IValueConverter\r\n" +
        "{\r\n" +
        "    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)\r\n" +
        "    {\r\n" +
        "        var timeOnly = (TimeOnly)value;\r\n" +
        "        return timeOnly.ToTimeSpan();\r\n" +
        "    }\r\n\r\n" +
        "    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)\r\n" +
        "    {\r\n" +
        "        var timeSpan = (TimeSpan)value;\r\n" +
        "        return TimeOnly.FromTimeSpan(timeSpan);\r\n" +
        "    }\r\n}";

    [ObservableProperty]
    TimeOnly timeOnlyTime = new(10, 30);


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
