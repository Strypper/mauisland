using Microsoft.Maui.Controls;
using System.Reflection;

namespace MAUIsland;

public partial class ColorToBlackOrWhiteConverterPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    #endregion

    #region [ CTor ]
    public ColorToBlackOrWhiteConverterPageViewModel(IAppNavigator appNavigator)
        : base(appNavigator)
    { } 
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    ObservableCollection<IGalleryCardInfo> controlGroupList;

    [ObservableProperty]
    Color textColor = Colors.BlueViolet;

    [ObservableProperty]
    Color iconColor = Colors.Brown;

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
    string xamlConverterTextTesting =
        "<Label Text=\"The Text is showing in monochrome\"\r\n" +
        "       TextColor=\"{x:Binding TextColor, Converter={x:StaticResource ColorToBlackOrWhiteConverter}}\"\r\n" +
        "       FontAttributes=\"Bold\"\r\n" +
        "       BackgroundColor=\"Gray\"/>";

    [ObservableProperty]
    string xamlConverterIconTesting =
        "<Image HeightRequest=\"40\" WidthRequest=\"40\" BackgroundColor=\"Gray\">\r\n" +
        "   <Image.Source>\r\n" +
        "       <FontImageSource Glyph=\"{x:Static app:FluentUIIcon.Ic_fluent_person_circle_24_regular}\" \r\n" +
        "                        Color=\"{x:Binding IconColor, Converter={x:StaticResource ColorToBlackOrWhiteConverter}}\"/>\r\n" +
        "   </Image.Source>\r\n" +
        "</Image>";

    [ObservableProperty]
    string xamlConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "        <toolkit:ColorToBlackOrWhiteConverter x:Key=\"ColorToBlackOrWhiteConverter\" />\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string cSharpxamlConverterTestingViewModel =
        "[ObservableProperty]\r\n" +
        "Color textColor = Colors.BlueViolet;\r\n\r\n" +
        "[ObservableProperty]\r\n" +
        "Color iconColor = Colors.Brown;";
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
    }
    #endregion

    #region [ Method ]
    #endregion
}
