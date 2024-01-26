using Bogus.DataSets;
using Microsoft.Maui.Controls;
using System.Reflection;

namespace MAUIsland;

public partial class ImageResourceConverterPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public ImageResourceConverterPageViewModel(IAppNavigator appNavigator)
        : base(appNavigator)
    { } 
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string imageResource;

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
        "<Image Source=\"{x:Binding ImageResource, Converter={StaticResource ImageResourceConverter}}\" />";

    [ObservableProperty]
    string xamlConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "        <toolkit:ImageResourceConverter x:Key=\"ImageResourceConverter\" />\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string cSharpxamlConverterTestingViewModel =
        "[ObservableProperty]\r\n" +
        "string imageResource = $\"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.Resources.Embedded.mauibeach.jpeg\";";
    #endregion

    #region[ Relay Command ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
        ControlInformation = query.GetData<IGalleryCardInfo>();
        LoadDataAsync().FireAndForget();
    }
    #endregion

    #region [ Data ]
    private async Task LoadDataAsync()
    {
        ImageResource = BuildImageResource("mauibeach.jpeg");
    }
    #endregion

    #region [ Method ]
    private string BuildImageResource(in string resourceName) 
        => $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.Resources.Embedded.{resourceName}";
    #endregion
}
