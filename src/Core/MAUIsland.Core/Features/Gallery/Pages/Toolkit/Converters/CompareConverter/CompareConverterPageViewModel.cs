using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class CompareConverterPageViewModel : BaseToolkitPageControlViewModel
{
    #region [ CTor ]

    public CompareConverterPageViewModel(IAppNavigator appNavigator,
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
    double slideValue = 0;

    [ObservableProperty]
    int testValue1;

    [ObservableProperty]
    double testValue2;

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
        "<Label Text=\"The background of this label will be green if the value entered is less than 50, and red otherwise.\" \r\n" +
        "       BackgroundColor=\"{x:Binding TestValue1, Converter={StaticResource CompareConverter1}}\"\r\n" +
        "       VerticalOptions=\"Center\"\r\n" +
        "       FontAttributes=\"Bold\"\r\n" +
        "       FontSize=\"14\"\r\n" +
        "       HorizontalOptions=\"CenterAndExpand\"/>\r\n" +
        "<Label Text=\"The background of this label will be green if the value entered is less than 50, and red otherwise.\" \r\n" +
        "       BackgroundColor=\"{x:Binding TestValue2, Converter={StaticResource CompareConverter2}}\"\r\n" +
        "       VerticalOptions=\"Center\"\r\n" +
        "       FontAttributes=\"Bold\"\r\n" +
        "       FontSize=\"14\"\r\n" +
        "       HorizontalOptions=\"CenterAndExpand\"/>";

    [ObservableProperty]
    string xamlConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "        <x:Int32 x:Key=\"ComparingValue1\">30</x:Int32>\r\n\r\n" +
        "        <x:Double x:Key=\"ComparingValue2\">40</x:Double>\r\n\r\n" +
        "        <toolkit:CompareConverter x:Key=\"CompareConverter1\"\r\n" +
        "                                  ComparisonOperator=\"GreaterOrEqual\"\r\n" +
        "                                  ComparingValue=\"{x:StaticResource ComparingValue1}\"\r\n" +
        "                                  TrueObject=\"LightGreen\"\r\n" +
        "                                  FalseObject=\"OrangeRed\"/>\r\n\r\n" +
        "        <toolkit:CompareConverter x:Key=\"CompareConverter2\"\r\n" +
        "                                  ComparisonOperator=\"SmallerOrEqual\"\r\n" +
        "                                  ComparingValue=\"{x:StaticResource ComparingValue2}\"\r\n" +
        "                                  TrueObject=\"LightGreen\"\r\n" +
        "                                  FalseObject=\"OrangeRed\"/>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string cSharpxamlConverterTestingViewModel =
        "[ObservableProperty]\r\n" +
        "int testValue1;\r\n\r\n" +
        "[ObservableProperty]\r\n" +
        "double testValue2;";
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
    partial void OnSlideValueChanged(double value)
    {
        TestValue1 = (int)Math.Round(value);
        TestValue2 = value;
    }
    #endregion
}
