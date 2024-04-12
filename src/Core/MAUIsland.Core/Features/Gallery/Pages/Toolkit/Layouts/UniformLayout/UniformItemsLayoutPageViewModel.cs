using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class UniformItemsLayoutPageViewModel : BaseToolkitPageControlViewModel
{
    #region [ CTor ]
    public UniformItemsLayoutPageViewModel(IAppNavigator appNavigator,
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
    bool canStateChange = true;

    [ObservableProperty]
    string currentState = "Loading";

    [ObservableProperty]
    string xamlUniformItemsLayout =
        "<toolkit:UniformItemsLayout>\r\n" +
        "    <BoxView\r\n" +
        "        HeightRequest=\"25\"\r\n" +
        "        WidthRequest=\"25\"\r\n" +
        "        Color=\"Blue\" />\r\n" +
        "    <BoxView\r\n" +
        "        HeightRequest=\"25\"\r\n" +
        "        WidthRequest=\"25\"\r\n" +
        "        Color=\"Yellow\" />\r\n" +
        "    <BoxView\r\n" +
        "        HeightRequest=\"25\"\r\n" +
        "        WidthRequest=\"25\"\r\n" +
        "        Color=\"Red\" />\r\n" +
        "    <BoxView\r\n" +
        "        HeightRequest=\"25\"\r\n" +
        "        WidthRequest=\"25\"\r\n" +
        "        Color=\"Black\" />\r\n" +
        "    <BoxView\r\n" +
        "        HeightRequest=\"25\"\r\n" +
        "        WidthRequest=\"25\"\r\n" +
        "        Color=\"Blue\" />\r\n" +
        "    <BoxView\r\n" +
        "        HeightRequest=\"25\"\r\n" +
        "        WidthRequest=\"25\"\r\n" +
        "        Color=\"Yellow\" />\r\n" +
        "    <BoxView\r\n" +
        "        HeightRequest=\"25\"\r\n" +
        "        WidthRequest=\"25\"\r\n" +
        "        Color=\"Red\" />\r\n" +
        "    <BoxView\r\n" +
        "        HeightRequest=\"25\"\r\n" +
        "        WidthRequest=\"25\"\r\n" +
        "        Color=\"Black\" />\r\n" +
        "</toolkit:UniformItemsLayout>";



    [ObservableProperty]
    string csharpUniformItemsLayout =
        "using CommunityToolkit.Maui.Views;\r\n" +
        "\r\n" +
        "var page = new ContentPage\r\n" +
        "{\r\n" +
        "    Content = new UniformItemsLayout\r\n" +
        "    {\r\n" +
        "        Children = \r\n" +
        "        {\r\n" +
        "            new BoxView { HeightRequest = 25, WidthRequest = 25, BackgroundColor = Colors.Blue },\r\n" +
        "            new BoxView { HeightRequest = 25, WidthRequest = 25, BackgroundColor = Colors.Yellow },\r\n" +
        "            new BoxView { HeightRequest = 25, WidthRequest = 25, BackgroundColor = Colors.Red },\r\n" +
        "            new BoxView { HeightRequest = 25, WidthRequest = 25, BackgroundColor = Colors.Black }\r\n" +
        "        }\r\n" +
        "    }\r\n" +
        "};";

    [ObservableProperty]
    string xamlCustomizingUniformItemsLayout =
            "<toolkit:UniformItemsLayout MaxColumns=\"1\" MaxRows=\"1\">\r\n" +
    "    <BoxView\r\n" +
    "        HeightRequest=\"25\"\r\n" +
    "        WidthRequest=\"25\"\r\n" +
    "        Color=\"Blue\" />\r\n" +
    "    <BoxView\r\n" +
    "        HeightRequest=\"25\"\r\n" +
    "        WidthRequest=\"25\"\r\n" +
    "        Color=\"Yellow\" />\r\n" +
    "    <BoxView\r\n" +
    "        HeightRequest=\"25\"\r\n" +
    "        WidthRequest=\"25\"\r\n" +
    "        Color=\"Red\" />\r\n" +
    "    <BoxView\r\n" +
    "        HeightRequest=\"25\"\r\n" +
    "        WidthRequest=\"25\"\r\n" +
    "        Color=\"Black\" />\r\n" +
    "</toolkit:UniformItemsLayout>";

    [ObservableProperty]
    string csharpCustomizingUniformItemsLayout =
    "using CommunityToolkit.Maui.Views;\r\n" +
    "\r\n" +
    "var page = new ContentPage\r\n" +
    "{\r\n" +
    "    Content = new UniformItemsLayout\r\n" +
    "    {\r\n" +
    "        MaxRows = 1,\r\n" +
    "        MaxColumns = 1,\r\n" +
    "        Children = \r\n" +
    "        {\r\n" +
    "            new BoxView { HeightRequest = 25, WidthRequest = 25, BackgroundColor = Colors.Blue },\r\n" +
    "            new BoxView { HeightRequest = 25, WidthRequest = 25, BackgroundColor = Colors.Yellow },\r\n" +
    "            new BoxView { HeightRequest = 25, WidthRequest = 25, BackgroundColor = Colors.Red },\r\n" +
    "            new BoxView { HeightRequest = 25, WidthRequest = 25, BackgroundColor = Colors.Black }\r\n" +
    "        }\r\n" +
    "    }\r\n" +
    "};";

    [ObservableProperty]
    int noOfColumns = 4;

    [ObservableProperty]
    int noOfRows = 4;

    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
        ControlInformation = query.GetData<ICommunityToolkitGalleryCardInfo>();
    }
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    async Task RefreshAsync()
    {
        if (ControlInformation is null)
            return;
    }
    #endregion
}
