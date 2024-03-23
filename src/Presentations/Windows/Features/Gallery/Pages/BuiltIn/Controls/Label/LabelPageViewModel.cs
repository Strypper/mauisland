using MAUIsland.GitHubFeatures;

namespace MAUIsland;

public partial class LabelPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public LabelPageViewModel(IAppNavigator appNavigator,
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
    string labelSpanBinding = "as well as binding the label to a state";

    [ObservableProperty]
    string labelXamlCodeExample =
    "<Label>\r\n" +
    "    <Label.FormattedText>\r\n" +
    "        <FormattedString>\r\n" +
    "            <Span Text=\"Sometimes we only want to use one label to display a complex line of text rather than using multiples labels and arrange them inside a layout ex: \" />\r\n" +
    "            <Span BackgroundColor=\"Gray\" Text=\"HorizontalStackLayout\" TextColor=\"Blue\" />\r\n" +
    "            <Span Text=\", You can also apply color to Span \" TextColor=\"Violet\" />\r\n" +
    "            <Span Text=\"{x:Binding LabelSpanBinding}\" TextColor=\"#e89e4e\" />\r\n" +
    "        </FormattedString>\r\n" +
    "    </Label.FormattedText>\r\n" +
    "</Label>";

    [ObservableProperty]
    FormattedString formatedStringByCsharpCode;

    [ObservableProperty]
    int selectedLineBreakModeIndex;

    [ObservableProperty]
    List<string> lineBreakModes = Enum.GetNames(typeof(LineBreakMode)).ToList();
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IBuiltInGalleryCardInfo>();

        LoadDataAsync(true).FireAndForget();
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
    private async Task LoadDataAsync(bool forced)
    {
        FormatedStringByCsharpCode = GenerateCodeMarkUp();
    }

    FormattedString GenerateCodeMarkUp()
    {
        var formattedString = new FormattedString();


        var span = new Span { Text = "<Label ", TextColor = Color.FromHex("#5598d0") };
        var span1 = new Span { Text = "LineBreakMode=\"WordWrap\">", TextColor = Color.FromHex("#9cdcfe") };
        var span2 = new Span { Text = "\n" };
        var span3 = new Span { Text = " <Label.FormattedText>", TextColor = Color.FromHex("#5598d0") };
        var span4 = new Span { Text = "\n" };
        var span5 = new Span { Text = "  <FormattedString>", TextColor = Color.FromHex("#5598d0") };
        var span6 = new Span { Text = "\n" };
        var span7 = new Span { Text = "   <Span ", TextColor = Color.FromHex("#5598d0") };
        var span8 = new Span { Text = "Text =", TextColor = Color.FromHex("#8cc2df") };
        var span9 = new Span { Text = "\"Red Bold, \" ", TextColor = Color.FromHex("#c08872") };
        var span10 = new Span { Text = "TextColor =", TextColor = Color.FromHex("#8cc2df") };
        var span11 = new Span { Text = "\"Red \" ", TextColor = Color.FromHex("#c08872") };
        var span12 = new Span { Text = "FontAttributes =", TextColor = Color.FromHex("#8cc2df") };
        var span13 = new Span { Text = "\"Bold \" ", TextColor = Color.FromHex("#c08872") };
        var span14 = new Span { Text = "/> ", TextColor = Color.FromHex("#5598d0") };
        var span15 = new Span { Text = "\n" };
        var span16 = new Span { Text = "   <Span ", TextColor = Color.FromHex("#5598d0") };
        var span17 = new Span { Text = "Text =", TextColor = Color.FromHex("#8cc2df") };
        var span18 = new Span { Text = "\"default, \"", TextColor = Color.FromHex("#c08872") };
        var span19 = new Span { Text = "FontSize =", TextColor = Color.FromHex("#8cc2df") };
        var span20 = new Span { Text = "\"14 \"", TextColor = Color.FromHex("#c08872") };
        var span21 = new Span { Text = "> ", TextColor = Color.FromHex("#5598d0") };
        var span22 = new Span { Text = "\n" };
        var span23 = new Span { Text = "    <Span.GestureRecognizers>", TextColor = Color.FromHex("#5598d0") };
        var span24 = new Span { Text = "\n" };
        var span25 = new Span { Text = "     <TapGestureRecognizer ", TextColor = Color.FromHex("#5598d0") };
        var span26 = new Span { Text = "Command =", TextColor = Color.FromHex("#8cc2df") };
        var span27 = new Span { Text = "\"{Binding TapCommand}\"", TextColor = Color.FromHex("#c08872") };
        var span28 = new Span { Text = "/> ", TextColor = Color.FromHex("#5598d0") };
        var span29 = new Span { Text = "\n" };
        var span30 = new Span { Text = "    </Span.GestureRecognizers>", TextColor = Color.FromHex("#5598d0") };
        var span31 = new Span { Text = "\n" };
        var span32 = new Span { Text = "   </Span> ", TextColor = Color.FromHex("#5598d0") };
        var span33 = new Span { Text = "\n" };
        var span34 = new Span { Text = "  </FormattedString>", TextColor = Color.FromHex("#5598d0") };
        var span35 = new Span { Text = "\n" };
        var span36 = new Span { Text = " </Label.FormattedText>", TextColor = Color.FromHex("#5598d0") };
        var span37 = new Span { Text = "\n" };
        var span38 = new Span { Text = "</Label> ", TextColor = Color.FromHex("#5598d0") };


        //span14.SetBinding(Span.TextProperty, new Binding("DumbassText", BindingMode.OneWay));


        formattedString.Spans.Add(span);
        formattedString.Spans.Add(span1);
        formattedString.Spans.Add(span2);
        formattedString.Spans.Add(span3);
        formattedString.Spans.Add(span4);
        formattedString.Spans.Add(span5);
        formattedString.Spans.Add(span6);
        formattedString.Spans.Add(span7);
        formattedString.Spans.Add(span8);
        formattedString.Spans.Add(span9);
        formattedString.Spans.Add(span10);
        formattedString.Spans.Add(span11);
        formattedString.Spans.Add(span12);
        formattedString.Spans.Add(span13);
        formattedString.Spans.Add(span14);

        formattedString.Spans.Add(span15);
        formattedString.Spans.Add(span16);
        formattedString.Spans.Add(span17);
        formattedString.Spans.Add(span18);
        formattedString.Spans.Add(span19);
        formattedString.Spans.Add(span20);
        formattedString.Spans.Add(span21);
        formattedString.Spans.Add(span22);
        formattedString.Spans.Add(span23);
        formattedString.Spans.Add(span24);
        formattedString.Spans.Add(span25);
        formattedString.Spans.Add(span26);
        formattedString.Spans.Add(span27);
        formattedString.Spans.Add(span28);
        formattedString.Spans.Add(span29);
        formattedString.Spans.Add(span30);
        formattedString.Spans.Add(span31);
        formattedString.Spans.Add(span32);
        formattedString.Spans.Add(span33);
        formattedString.Spans.Add(span34);
        formattedString.Spans.Add(span35);
        formattedString.Spans.Add(span36);
        formattedString.Spans.Add(span37);
        formattedString.Spans.Add(span38);
        return formattedString;
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
}
