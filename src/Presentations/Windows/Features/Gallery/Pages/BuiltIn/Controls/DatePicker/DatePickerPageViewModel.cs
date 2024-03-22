using MAUIsland.GitHubFeatures;

namespace MAUIsland;

public partial class DatePickerPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public DatePickerPageViewModel(IAppNavigator appNavigator,
                                   IGitHubService gitHubService)
                                        : base(appNavigator)
    {
        this.gitHubService = gitHubService;
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IBuiltInGalleryCardInfo controlInformation;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<ControlIssueModel> controlIssues;

    [ObservableProperty]
    ControlIssueModel selectedControlIssue;

    [ObservableProperty]
    string simpleDatePickerXamlCode = "<DatePicker />";

    [ObservableProperty]
    string datePickerUseDateOnlyConverterXamlCode =
        "<DatePicker x:Name=\"DateOnlyDatePicker\" />\r\n" +
        "<Label Text=\"{x:Binding Source={x:Reference DateOnlyDatePicker}, Path=Date, Converter={x:StaticResource FulldateToDateOnlyConverter}}\" />";

    [ObservableProperty]
    string fulldateToDateOnlyConverterCsharpCode = "public class FulldateToDateOnlyConverter : IValueConverter\r\n{\r\n    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)\r\n    {\r\n        var birthDay = (DateTime?)value;\r\n        return birthDay?.Date.ToString(\"MM/dd/yyyy\");\r\n    }\r\n\r\n    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)\r\n    {\r\n        throw new NotImplementedException();\r\n    }\r\n}";
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

        var items = await gitHubService.GetGitHubIssuesByLabels(ControlInformation.GitHubAuthorIssueName,
                                                                ControlInformation.GitHubRepositoryIssueName,
                                                                ControlInformation.GitHubIssueLabels);


        IsBusy = false;

        if (ControlIssues is null || forced)
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
    #endregion
}
