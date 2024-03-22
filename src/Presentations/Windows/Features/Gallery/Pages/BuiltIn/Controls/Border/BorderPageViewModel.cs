using MAUIsland.GitHubFeatures;

namespace MAUIsland;

public partial class BorderPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]
    public BorderPageViewModel(IAppNavigator appNavigator,
                               IGitHubService gitHubService)
                                                : base(appNavigator)
    {
        this.gitHubService = gitHubService;
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    bool isEnable = true;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<ControlIssueModel> controlIssues;

    [ObservableProperty]
    ControlIssueModel selectedControlIssue;

    [ObservableProperty]
    IBuiltInGalleryCardInfo controlInformation;

    [ObservableProperty]
    string roundedRectangleXamlCode =
        "StrokeShape=\"RoundRectangle 40,0,0,40\"";

    [ObservableProperty]
    string roundedRectangle2XamlCode =
        "<Border.StrokeShape>\r\n" +
        "    <RoundRectangle CornerRadius=\"40,0,0,40\" />\r\n" +
        "</Border.StrokeShape>";

    [ObservableProperty]
    string createBorderXamlCode =
        "<Border Stroke=\"#C49B33\"\r\n" +
        "        StrokeThickness=\"4\"\r\n" +
        "        StrokeShape=\"RoundRectangle 40,0,0,40\"\r\n" +
        "        Background=\"#2B0B98\"\r\n" +
        "        Padding=\"16,8\"\r\n" +
        "        HorizontalOptions=\"Center\">\r\n" +
        "    <Label Text=\".NET MAUI\"\r\n" +
        "           TextColor=\"White\"\r\n" +
        "           FontSize=\"18\"\r\n" +
        "           FontAttributes=\"Bold\" />\r\n" +
        "</Border>";

    [ObservableProperty]
    string createBorder2XamlCode =
        "<Border Stroke=\"#C49B33\"\r\n" +
        "        StrokeThickness=\"4\"\r\n" +
        "        Background=\"#2B0B98\"\r\n" +
        "        Padding=\"16,8\"\r\n" +
        "        HorizontalOptions=\"Center\">\r\n" +
        "    <Border.StrokeShape>\r\n" +
        "        <RoundRectangle CornerRadius=\"40,0,0,40\" />\r\n" +
        "    </Border.StrokeShape>\r\n" +
        "    <Label Text=\".NET MAUI\"\r\n" +
        "           TextColor=\"White\"\r\n" +
        "           FontSize=\"18\"\r\n" +
        "           FontAttributes=\"Bold\" />\r\n" +
        "</Border>";

    [ObservableProperty]
    string createBorder3CSharpCode =
        "using Microsoft.Maui.Controls.Shapes;\r\n" +
        "using GradientStop = Microsoft.Maui.Controls.GradientStop;\r\n" +
        "...\r\n" +
        "\r\n" +
        "Border border = new Border\r\n" +
        "{\r\n" +
        "    Stroke = Color.FromArgb(\"#C49B33\"),\r\n" +
        "    Background = Color.FromArgb(\"#2B0B98\"),\r\n" +
        "    StrokeThickness = 4,\r\n" +
        "    Padding = new Thickness(16, 8),\r\n" +
        "    HorizontalOptions = LayoutOptions.Center,\r\n" +
        "    StrokeShape = new RoundRectangle\r\n" +
        "    {\r\n" +
        "        CornerRadius = new CornerRadius(40, 0, 0, 40)\r\n" +
        "    },\r\n" +
        "    Content = new Label\r\n" +
        "    {\r\n" +
        "        Text = \".NET MAUI\",\r\n" +
        "        TextColor = Colors.White,\r\n" +
        "        FontSize = 18,\r\n" +
        "        FontAttributes = FontAttributes.Bold\r\n" +
        "    }\r\n" +
        "};";

    [ObservableProperty]
    string createBorder4XamlCode =
        "<Border StrokeThickness=\"4\"\r\n" +
        "        StrokeShape=\"RoundRectangle 40,0,0,40\"\r\n" +
        "        Background=\"#2B0B98\"\r\n" +
        "        Padding=\"16,8\"\r\n" +
        "        HorizontalOptions=\"Center\">\r\n" +
        "    <Border.Stroke>\r\n" +
        "        <LinearGradientBrush EndPoint=\"0,1\">\r\n" +
        "            <GradientStop Color=\"Orange\"\r\n" +
        "                          Offset=\"0.1\" />\r\n" +
        "            <GradientStop Color=\"Brown\"\r\n" +
        "                          Offset=\"1.0\" />\r\n" +
        "        </LinearGradientBrush>\r\n" +
        "    </Border.Stroke>\r\n" +
        "    <Label Text=\".NET MAUI\"\r\n" +
        "           TextColor=\"White\"\r\n" +
        "           FontSize=\"18\"\r\n" +
        "           FontAttributes=\"Bold\" />\r\n" +
        "</Border>";

    [ObservableProperty]
    string createBorder4CSharpCode =
        "using Microsoft.Maui.Controls.Shapes;\r\n" +
        "using GradientStop = Microsoft.Maui.Controls.GradientStop;\r\n" +
        "...\r\n" +
        "\r\n" +
        "Border gradientBorder = new Border\r\n" +
        "{\r\n" +
        "    StrokeThickness = 4,\r\n" +
        "    Background = Color.FromArgb(\"#2B0B98\"),\r\n" +
        "    Padding = new Thickness(16, 8),\r\n" +
        "    HorizontalOptions = LayoutOptions.Center,\r\n" +
        "    StrokeShape = new RoundRectangle\r\n" +
        "    {\r\n" +
        "        CornerRadius = new CornerRadius(40, 0, 0, 40)\r\n" +
        "    },\r\n" +
        "    Stroke = new LinearGradientBrush\r\n" +
        "    {\r\n" +
        "        EndPoint = new Point(0, 1),\r\n" +
        "        GradientStops = new GradientStopCollection\r\n" +
        "        {\r\n" +
        "            new GradientStop { Color = Colors.Orange, Offset = 0.1f },\r\n" +
        "            new GradientStop { Color = Colors.Brown, Offset = 1.0f }\r\n" +
        "        },\r\n" +
        "    },\r\n" +
        "    Content = new Label\r\n" +
        "    {\r\n" +
        "        Text = \".NET MAUI\",\r\n" +
        "        TextColor = Colors.White,\r\n" +
        "        FontSize = 18,\r\n" +
        "        FontAttributes = FontAttributes.Bold\r\n" +
        "    }\r\n" +
        "};";

    [ObservableProperty]
    string buttonWithImageXamlCode =
        "<Frame>\r\n" +
        "    <Frame.Resources>\r\n" +
        "        <FontImageSource x:Key=\"HomeIcon\"\r\n" +
        "                         Color=\"{x:StaticResource Primary }\"\r\n" +
        "                         FontFamily=\"{x:Static core:FontNames.FluentSystemIconsRegular}\"\r\n" +
        "                         Glyph=\"{Static core:FluentUIIcon.Ic_fluent_home_20_regular}\"/>\r\n" +
        "\r\n" +
        "        <FontImageSource x:Key=\"DownloadIcon\"\r\n";
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

    [RelayCommand]
    async Task CopyToClipboardAsync(string text)
    {
        await Clipboard.Default.SetTextAsync(text);
        await AppNavigator.ShowSnackbarAsync("Code copied to clipboard", null, null);
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
