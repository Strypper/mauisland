using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class TableViewPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public TableViewPageViewModel(IAppNavigator appNavigator,
                                  IGitHubService gitHubService,
                                  IGitHubIssueLocalDbService gitHubIssueLocalDbService)
                                    : base(appNavigator,
                                           gitHubService,
                                           gitHubIssueLocalDbService)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string standardTableViewXamlCode =
    "<TableView Intent=\"Menu\">\r\n" +
    "    <TableRoot>\r\n" +
    "        <TableSection Title=\"Chapters\">\r\n" +
    "            <TextCell Text=\"1. Introduction to .NET MAUI\"\r\n" +
    "                      Detail=\"Learn about .NET MAUI and what it provides.\" />\r\n" +
    "            <TextCell Text=\"2. Anatomy of an app\"\r\n" +
    "                      Detail=\"Learn about the visual elements in .NET MAUI\" />\r\n" +
    "            <TextCell Text=\"3. Text\"\r\n" +
    "                      Detail=\"Learn about the .NET MAUI controls that display text.\" />\r\n" +
    "            <TextCell Text=\"4. Dealing with sizes\"\r\n" +
    "                      Detail=\"Learn how to size .NET MAUI controls on screen.\" />\r\n" +
    "            <TextCell Text=\"5. XAML vs code\"\r\n" +
    "                      Detail=\"Learn more about creating your UI in XAML.\" />\r\n" +
    "        </TableSection>\r\n" +
    "    </TableRoot>\r\n" +
    "</TableView>";

    [ObservableProperty]
    string textCellXamlCode =
        "<TableView Intent=\"Menu\">\r\n" +
        "    <TableRoot>\r\n" +
        "        <TableSection Title=\"Chapters\">\r\n" +
        "            <TextCell Text=\"1. Introduction to .NET MAUI\"\r\n" +
        "                      Detail=\"Learn about .NET MAUI and what it provides.\" />\r\n" +
        "            <TextCell Text=\"2. Anatomy of an app\"\r\n" +
        "                      Detail=\"Learn about the visual elements in .NET MAUI\" />\r\n" +
        "            <TextCell Text=\"3. Text\"\r\n" +
        "                      Detail=\"Learn about the .NET MAUI controls that display text.\" />\r\n" +
        "            <TextCell Text=\"4. Dealing with sizes\"\r\n" +
        "                      Detail=\"Learn how to size .NET MAUI controls on screen.\" />\r\n" +
        "            <TextCell Text=\"5. XAML vs code\"\r\n" +
        "                      Detail=\"Learn more about creating your UI in XAML.\" />\r\n" +
        "        </TableSection>\r\n" +
        "    </TableRoot>\r\n" +
        "</TableView>";

    [ObservableProperty]
    string imageCellXamlCode =
        "<TableView Intent=\"Menu\">\r\n" +
        "    <TableRoot>\r\n" +
        "        <TableSection Title=\"Learn how to use your XBox\">\r\n" +
        "            <ImageCell Text=\"1. Introduction\"\r\n" +
        "                       Detail=\"Learn about your XBox and its capabilities.\"\r\n" +
        "                       ImageSource=\"xbox.png\" />\r\n" +
        "            <ImageCell Text=\"2. Turn it on\"\r\n" +
        "                       Detail=\"Learn how to turn on your XBox.\"\r\n" +
        "                       ImageSource=\"xbox.png\" />\r\n" +
        "            <ImageCell Text=\"3. Connect your controller\"\r\n" +
        "                       Detail=\"Learn how to connect your wireless controller.\"\r\n" +
        "                       ImageSource=\"xbox.png\" />\r\n" +
        "            <ImageCell Text=\"4. Launch a game\"\r\n" +
        "                       Detail=\"Learn how to launch a game.\"\r\n" +
        "                       ImageSource=\"xbox.png\" />\r\n" +
        "        </TableSection>\r\n" +
        "    </TableRoot>\r\n" +
        "</TableView>";

    [ObservableProperty]
    string switchCellXamlCode =
        "<TableView Intent=\"Settings\">\r\n" +
        "    <TableRoot>\r\n" +
        "        <TableSection>\r\n" +
        "            <SwitchCell Text=\"Airplane Mode\"\r\n" +
        "                        On=\"False\" />\r\n" +
        "            <SwitchCell Text=\"Notifications\"\r\n" +
        "                        On=\"True\" />\r\n" +
        "        </TableSection>\r\n" +
        "    </TableRoot>\r\n" +
        "</TableView>";

    [ObservableProperty]
    string entryCellXamlCode =
        "<TableView Intent=\"Settings\">\r\n" +
        "    <TableRoot>\r\n" +
        "        <TableSection>\r\n" +
        "            <EntryCell Label=\"Login\"\r\n" +
        "                       Placeholder=\"username\" />\r\n" +
        "            <EntryCell Label=\"Password\"\r\n" +
        "                       Placeholder=\"password\" />\r\n" +
        "        </TableSection>\r\n" +
        "    </TableRoot>\r\n" +
        "</TableView>";

    [ObservableProperty]
    string viewCellXamlCode =
        "<TableView Intent=\"Settings\">\r\n" +
        "    <TableRoot>\r\n" +
        "        <TableSection Title=\"Silent\">\r\n" +
        "            <ViewCell>\r\n" +
        "                <Grid RowDefinitions=\"Auto,Auto\"\r\n" +
        "                      ColumnDefinitions=\"0.5*,0.5*\">\r\n" +
        "                    <Label Text=\"Vibrate\"\r\n" +
        "                           Margin=\"10,10,0,0\"/>\r\n" +
        "                    <Switch Grid.Column=\"1\"\r\n" +
        "                            HorizontalOptions=\"End\" />\r\n" +
        "                    <Slider Grid.Row=\"1\"\r\n" +
        "                            Grid.ColumnSpan=\"2\"\r\n" +
        "                            Margin=\"10\"\r\n" +
        "                            Minimum=\"0\"\r\n" +
        "                            Maximum=\"10\"\r\n" +
        "                            Value=\"3\" />\r\n" +
        "                </Grid>\r\n" +
        "            </ViewCell>\r\n" +
        "        </TableSection>\r\n" +
        "    </TableRoot>\r\n" +
        "</TableView>";

    [ObservableProperty]
    string rightToLeftLayoutXamlCode =
        "<ContentPage xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
        "             xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
        "             x:Class=\"TableViewDemos.RightToLeftTablePage\"\r\n" +
        "             Title=\"Right to left TableView\"\r\n" +
        "             FlowDirection=\"RightToLeft\">\r\n" +
        "    <TableView Intent=\"Settings\">\r\n" +
        "        ...\r\n" +
        "    </TableView>\r\n" +
        "</ContentPage>";

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
        await RefreshControlIssues(true,
                                   ControlInformation.ControlName,
                                   ControlInformation.GitHubAuthorIssueName,
                                   ControlInformation.GitHubRepositoryIssueName,
                                   ControlInformation.GitHubIssueLabels);
    }
    #endregion
}
