using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class ExpanderPageViewModel : BaseToolkitPageControlViewModel
{
    #region [ Fields ]

    private readonly IControlsService MauiControlsService;
    #endregion

    #region [ CTor ]
    public ExpanderPageViewModel(IAppNavigator appNavigator,
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
    ObservableCollection<IGalleryCardInfo> controlGroupList;

    [ObservableProperty]
    bool isExpanding;

    [ObservableProperty]
    string expanderStatus;

    [ObservableProperty]
    string setupDescription =
    "In order to use the toolkit in XAML the following xmlns needs to be added into your page or view:";

    [ObservableProperty]
    string xamlNamespace =
        "xmlns:toolkit=\"http://schemas.microsoft.com/dotnet/2022/maui/toolkit\"";

    [ObservableProperty]
    string fullNamepaceExampleBefore =
        "<ContentPage\r\n" +
        "    x:Class=\"MAUIsland.ExpanderPage\"\r\n" +
        "    xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
        "    xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string fullNamepaceExampleAfter =
        "<ContentPage\r\n" +
        "    x:Class=\"MAUIsland.ExpanderPage\"\r\n" +
        "    xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
        "    xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
        "    xmlns:toolkit=\"http://schemas.microsoft.com/dotnet/2022/maui/toolkit\">\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlSimpleExpander =
        "<toolkit:Expander>\r\n" +
        "   <toolkit:Expander.Header>\r\n" +
        "       <Label Text=\"Click me\" \r\n" +
        "              FontAttributes=\"Bold\"\r\n" +
        "              FontSize=\"Medium\" />\r\n" +
        "   </toolkit:Expander.Header>\r\n" +
        "   <Grid ColumnDefinitions=\"120, *\"\r\n" +
        "         ColumnSpacing=\"10\">\r\n" +
        "       <Image Grid.Column=\"0\"\r\n" +
        "              Aspect=\"AspectFill\"\r\n" +
        "              Source=\"https://aka.ms/campus.jpg\"\r\n" +
        "              HeightRequest=\"120\"\r\n" +
        "              WidthRequest=\"120\"/>\r\n" +
        "       <Label Grid.Column=\"1\"\r\n" +
        "              Text=\"The Microsoft headquarters, also known as the Microsoft Redmond campus, is a sprawling complex located in Redmond, Washington." +
        " It’s home to numerous buildings and facilities where Microsoft’s various teams and departments work." +
        " The campus is known for its modern architecture, lush landscaping, and amenities designed to foster collaboration and creativity among employees." +
        " It’s truly a landmark in the world of tech company campuses.\"\r\n" +
        "              FontAttributes=\"Italic\" />\r\n" +
        "   </Grid>\r\n" +
        "</toolkit:Expander";

    [ObservableProperty]
    string xamlSimpleExpanderOppositeDirection =
        "<toolkit:Expander Direction=\"Up\" \r\n" +
        "                  FlowDirection=\"RightToLeft\">\r\n" +
        "   <toolkit:Expander.Header>\r\n" +
        "       <Label Text=\"Click me\" \r\n" +
        "              FontAttributes=\"Bold\"\r\n" +
        "              FontSize=\"Medium\" />\r\n" +
        "   </toolkit:Expander.Header>\r\n" +
        "   <Grid ColumnDefinitions=\"120, *\"\r\n" +
        "         ColumnSpacing=\"10\">\r\n" +
        "       <Image Grid.Column=\"0\"\r\n" +
        "              Aspect=\"AspectFill\"\r\n" +
        "              Source=\"https://aka.ms/campus.jpg\"\r\n" +
        "              HeightRequest=\"120\"\r\n" +
        "              WidthRequest=\"120\"/>\r\n" +
        "       <Label Grid.Column=\"1\"\r\n" +
        "              Text=\"The Microsoft headquarters, also known as the Microsoft Redmond campus, is a sprawling complex located in Redmond, Washington." +
        " It’s home to numerous buildings and facilities where Microsoft’s various teams and departments work." +
        " The campus is known for its modern architecture, lush landscaping, and amenities designed to foster collaboration and creativity among employees." +
        " It’s truly a landmark in the world of tech company campuses.\"\r\n" +
        "              FontAttributes=\"Italic\" />\r\n" +
        "   </Grid>\r\n" +
        "</toolkit:Expander>";

    [ObservableProperty]
    string xamlSimpleExpanderCheckingExpand =
        "<Label>\r\n" +
        "   <Label.FormattedText>\r\n" +
        "       <FormattedString>\r\n" +
        "           <Span Text=\"Your Expander is: \" />\r\n" +
        "           <Span BackgroundColor=\"Yellow\"\r\n" +
        "                 Text=\"{x:Binding ExpanderStatus}\"/>\r\n" +
        "       </FormattedString>\r\n" +
        "   </Label.FormattedText>\r\n" +
        "</Label>\r\n" +
        "<toolkit:Expander IsExpanded=\"{x:Binding IsExpanding}\">\r\n" +
        "   <toolkit:Expander.Header>\r\n" +
        "       <Label Text=\"Click me\" \r\n" +
        "              FontAttributes=\"Bold\"\r\n" +
        "              FontSize=\"Medium\" />\r\n" +
        "   </toolkit:Expander.Header>\r\n" +
        "   <Grid ColumnDefinitions=\"120, *\"\r\n" +
        "         ColumnSpacing=\"10\">\r\n" +
        "       <Image Grid.Column=\"0\"\r\n" +
        "              Aspect=\"AspectFill\"\r\n" +
        "              Source=\"https://aka.ms/campus.jpg\"\r\n" +
        "              HeightRequest=\"120\"\r\n" +
        "              WidthRequest=\"120\"/>\r\n" +
        "       <Label Grid.Column=\"1\"\r\n" +
        "              Text=\"The Microsoft headquarters, also known as the Microsoft Redmond campus, is a sprawling complex located in Redmond, Washington." +
        " It’s home to numerous buildings and facilities where Microsoft’s various teams and departments work." +
        " The campus is known for its modern architecture, lush landscaping, and amenities designed to foster collaboration and creativity among employees." +
        " It’s truly a landmark in the world of tech company campuses.\"\r\n" +
        "              FontAttributes=\"Italic\" />\r\n" +
        "   </Grid>\r\n" +
        "</toolkit:Expander>";

    [ObservableProperty]
    string cSharpViewModelSimpleExpanderCheckingExpand =
        "[ObservableProperty]\r\n" +
        "bool isExpanding;\r\n\r\n" +
        "[ObservableProperty]\r\n" +
        "string expanderStatus = \"Is Close\";\r\n\r\n" +
        "//This OnIsExpandingChanged this path of ObservableProperty annotation generate you can create your own version check the ObservableProperty in our App\r\n" +
        "partial void OnIsExpandingChanged(bool value)\r\n" +
        "{\r\n" +
        "    if (value is true)\r\n" +
        "    {\r\n" +
        "        this.ExpanderStatus = \"Is Expanded\";\r\n" +
        "    }\r\n" +
        "    else \r\n" +
        "    {\r\n" +
        "        this.ExpanderStatus = \"Is Close\";\r\n" +
        "    }\r\n" +
        "}";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
        ExpanderStatus = "Is Close";
        ControlGroupList = new ObservableCollection<IGalleryCardInfo>();
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

    #region [ Data ]
    private async Task LoadDataAsync()
    {
        ControlGroupList.Clear();

        var items = await MauiControlsService.GetControlsAsync(ControlInformation.GroupName);

        foreach (var item in items)
        {
            ControlGroupList.Add(item);
        }
        return;
    }
    #endregion

    #region [ Methods ]
    partial void OnIsExpandingChanged(bool value)
    {
        if (value is true)
        {
            this.ExpanderStatus = "Is Expanded";
        }
        else
        {
            this.ExpanderStatus = "Is Close";
        }
    }
    #endregion
}
