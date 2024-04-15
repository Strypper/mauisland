using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class DoubleToIntConverterPageViewModel : BaseToolkitPageControlViewModel
{
    #region [ CTor ]
    public DoubleToIntConverterPageViewModel(IAppNavigator appNavigator,
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
    double testValue;

    [ObservableProperty]
    string setupDescription =
    "In order to use the toolkit in XAML the following xmlns needs to be added into your page or view:";

    [ObservableProperty]
    string xamlNamespace =
        "xmlns:toolkit=\"http://schemas.microsoft.com/dotnet/2022/maui/toolkit\"";

    [ObservableProperty]
    string fullNamepaceExampleBefore =
        "<ContentPage\r\n" +
        "    x:Class=\"MAUIsland.MediaElementPage\"\r\n" +
        "    xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
        "    xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string fullNamepaceExampleAfter =
        "<ContentPage\r\n" +
        "    x:Class=\"MAUIsland.MediaElementPage\"\r\n" +
        "    xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
        "    xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
        "    xmlns:toolkit=\"http://schemas.microsoft.com/dotnet/2022/maui/toolkit\">\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlConverterTesting =
        "<Label Text=\"{x:Binding TestValue, Converter={StaticResource DoubleToIntConverter}}\" />";

    [ObservableProperty]
    string xamlConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "        <toolkit:DoubleToIntConverter x:Key=\"DoubleToIntConverter\" />\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string cSharpxamlConverterTestingViewModel =
        "[ObservableProperty]\r\n" +
        "double testValue;";
    #endregion

    #region[ Relay Command ]
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

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
        ControlInformation = query.GetData<ICommunityToolkitGalleryCardInfo>();
        LoadDataAsync().FireAndForget();
    }
    #endregion

    #region [ Data ]
    private async Task LoadDataAsync()
    {
    }
    #endregion

    #region [ Method ]
    #endregion
}
