using MAUIsland.GitHubFeatures;

namespace MAUIsland;

public partial class ActivityIndicatorPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public ActivityIndicatorPageViewModel(IAppNavigator appNavigator,
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
            await AppNavigator.ShowSnackbarAsync(error.ErrorMessage, null, null);
        }
    }
    #endregion
}
