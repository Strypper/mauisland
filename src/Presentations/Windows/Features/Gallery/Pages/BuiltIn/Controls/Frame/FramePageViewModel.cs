using MAUIsland.GitHubFeatures;

namespace MAUIsland;
public partial class FramePageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]

    public FramePageViewModel(IAppNavigator appNavigator,
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
    string standardCreateFrameXamlCode =
        "<Frame>\r\n" +
        "   <Label Text=\"Frame wrapped around a Label\" \r\n" +
        "          TextColor=\"White\"/>\r\n" +
        "</Frame>";

    [ObservableProperty]
    string createTheSecondFrameXamlCode =
        "<Frame BackgroundColor=\"DimGrey\"\r\n" +
        "       BorderColor=\"Grey\"\r\n" +
        "       CornerRadius=\"10\">\r\n" +
        "   <Label Text=\"Frame wrapped around a Label\" />\r\n" +
        "</Frame>";

    [ObservableProperty]
    string createACardWithAFrameXamlCode =
        "<Frame Padding=\"10\"\r\n" +
        "       BackgroundColor=\"White\"\r\n" +
        "       BorderColor=\"Gray\"\r\n" +
        "       CornerRadius=\"8\"\r\n" +
        "       HeightRequest=\"150\"\r\n" +
        "       WidthRequest=\"200\">\r\n" +
        "   <StackLayout>\r\n" +
        "       <Label FontAttributes=\"Bold\"\r\n" +
        "              FontSize=\"14\"\r\n" +
        "              Text=\"Card Example\"\r\n" +
        "              TextColor=\"Black\" />\r\n" +
        "       <BoxView HeightRequest=\"2\"\r\n" +
        "                HorizontalOptions=\"Fill\"\r\n" +
        "                Color=\"Gray\" />\r\n" +
        "       <Label Text=\"Frames can wrap more complex layouts to create more complex UI components, such as this card!\"\r\n" +
        "              TextColor=\"Black\" />\r\n" +
        "   </StackLayout>\r\n" +
        "</Frame>";

    [ObservableProperty]
    string roundElementsXamlCode =
        "<Frame Padding=\"20\"\r\n" +
        "       BorderColor=\"Black\"\r\n" +
        "       CornerRadius=\"60\"\r\n" +
        "       HeightRequest=\"120\"\r\n" +
        "       WidthRequest=\"120\"\r\n" +
        "       HorizontalOptions=\"Center\"\r\n" +
        "       VerticalOptions=\"Center\"\r\n" +
        "       IsClippedToBounds=\"True\">\r\n" +
        "   <Image HeightRequest=\"80\"\r\n" +
        "          WidthRequest=\"80\" \r\n" +
        "          HorizontalOptions=\"Center\"\r\n" +
        "          VerticalOptions=\"Center\"\r\n" +
        "          Source=\"{x:Binding ControlInformation.ControlIcon}\"/>\r\n" +
        "</Frame>";

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