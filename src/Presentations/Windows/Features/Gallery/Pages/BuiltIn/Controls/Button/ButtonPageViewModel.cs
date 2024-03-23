using MAUIsland.GitHubFeatures;

namespace MAUIsland;

public partial class ButtonPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public ButtonPageViewModel(IAppNavigator appNavigator,
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
    bool isEnable = true;

    [ObservableProperty]
    IBuiltInGalleryCardInfo controlInformation;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<ControlIssueModel> controlIssues;

    [ObservableProperty]
    ControlIssueModel selectedControlIssue;

    [ObservableProperty]
    string standardButtonXamlCode =
    "<Button Text=\"Standard XAML Button\"\r\n" +
    "        VerticalOptions=\"Center\"\r\n" +
    "        HorizontalOptions=\"Start\"\r\n" +
    "        IsEnabled=\"{x:Binding IsEnable}\"/>";

    [ObservableProperty]
    string rotationButtonXamlCode =
    "<Button Text=\"MAUI Button Test\"\r\n" +
    "        VerticalOptions=\"Center\"\r\n" +
    "        HorizontalOptions=\"Center\"\r\n" +
    "        BorderColor=\"Black\"\r\n" +
    "        BorderWidth=\"2\"\r\n" +
    "        BackgroundColor=\"Red\"\r\n" +
    "        CharacterSpacing=\"4\"\r\n" +
    "        WidthRequest=\"190\"\r\n" +
    "        HeightRequest=\"70\"\r\n" +
    "        FontSize=\"18\"\r\n" +
    "        FontAttributes=\"Bold\"\r\n" +
    "        LineBreakMode=\"WordWrap\"\r\n" +
    "        TextColor=\"White\"\r\n" +
    "        CornerRadius=\"30\"\r\n" +
    "        RotationX=\"10\"\r\n" +
    "        RotationY=\"30\"/>";

    [ObservableProperty]
    string buttonsChangedBackgroundGroupXamlCode =
    "<HorizontalStackLayout Spacing=\"10\">\r\n" +
    "    <Button Text=\"Green\"\r\n" +
    "            TextColor=\"{x:StaticResource White}\"\r\n" +
    "            BackgroundColor=\"Green\"/>\r\n" +
    "\r\n" +
    "    <Button Text=\"Red\"\r\n" +
    "            TextColor=\"{x:StaticResource White}\"\r\n" +
    "            BackgroundColor=\"Red\"/>\r\n" +
    "\r\n" +
    "    <Button Text=\"Application Primary Color\"\r\n" +
    "            TextColor=\"{x:StaticResource White}\"\r\n" +
    "            BackgroundColor=\"{x:StaticResource Primary}\"/>\r\n" +
    "\r\n" +
    "    <!--This button will be Cyan when in dark mode and Blue when light mode-->\r\n" +
    "    <Button Text=\"Dark or Light mode color\"\r\n" +
    "            TextColor=\"{x:StaticResource Black}\"\r\n" +
    "            BackgroundColor=\"{x:AppThemeBinding Dark={x:StaticResource Cyan300Accent}, \r\n" +
    "                                                    Light={x:StaticResource Blue300Accent}}\"/>\r\n" +
    "</HorizontalStackLayout>";

    [ObservableProperty]
    string buttonWithImageXamlCode =
    "<Frame>\r\n" +
    "    <Frame.Resources>\r\n" +
    "        <FontImageSource x:Key=\"HomeIcon\"\r\n" +
    "                         Color=\"{x:StaticResource Primary }\"\r\n" +
    "                         FontFamily=\"{x:Static core:FontNames.FluentSystemIconsRegular}\"\r\n" +
    "                         Glyph=\"{Static core:FluentUIIcon.Ic_fluent_home_20_regular}\"/>\r\n" +
    "\r\n" +
    "        <FontImageSource x:Key=\"DownloadIcon\"\r\n" +
    "                         Color=\"{x:StaticResource Primary }\"\r\n" +
    "                         FontFamily=\"{x:Static core:FontNames.FluentSystemIconsRegular}\"\r\n" +
    "                         Glyph=\"{Static core:FluentUIIcon.Ic_fluent_arrow_download_20_regular}\"/>\r\n" +
    "    </Frame.Resources>\r\n" +
    "\r\n" +
    "    <HorizontalStackLayout Spacing=\"10\">\r\n" +
    "        <Button Text=\"Home\"\r\n" +
    "                ImageSource=\"{x:StaticResource HomeIcon}\"/>\r\n" +
    "\r\n" +
    "        <Button Text=\"Download\"\r\n" +
    "                ImageSource=\"{x:StaticResource DownloadIcon}\"/>\r\n" +
    "    </HorizontalStackLayout>\r\n" +
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
