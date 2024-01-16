using Microsoft.Maui.Controls;
using System.Reflection;

namespace MAUIsland;

public partial class ColorToByteAlphaConverterPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    #endregion

    #region [ CTor ]
    public ColorToByteAlphaConverterPageViewModel(IAppNavigator appNavigator)
        : base(appNavigator)
    { } 
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    ObservableCollection<IGalleryCardInfo> controlGroupList;

    [ObservableProperty]
    Color textColor1 = Color.FromRgba(138, 43, 226, 128);

    [ObservableProperty]
    Color textColor2 = Color.FromRgba(150, 75, 0, 179);

    [ObservableProperty]
    Color textColor3 = Color.FromRgba(154, 205, 50, 200);

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
        "<Label VerticalOptions=\"Center\">\r\n" +
        "   <Label.FormattedText>\r\n" +
        "       <FormattedString>\r\n" +
        "           <Span Text=\"The converter will turn this text color \"/>\r\n" +
        "           <Span Text=\"Text Color\"\r\n" +
        "                 TextColor=\"{x:Binding TextColor3}\"\r\n" +
        "                 FontAttributes=\"Bold\"/>\r\n" +
        "           <Span Text=\" into this Byte Alpha (Transparency) \"/>\r\n" +
        "           <Span Text=\"{x:Binding TextColor3, Converter={x:StaticResource ColorToByteAlphaConverter}}\"\r\n" +
        "                 FontAttributes=\"Bold\"/>\r\n" +
        "       </FormattedString>\r\n" +
        "   </Label.FormattedText>\r\n" +
        "</Label>";

    [ObservableProperty]
    string xamlConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "        <toolkit:ColorToByteAlphaConverter x:Key=\"ColorToByteAlphaConverter\" />\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string cSharpxamlConverterTestingViewModel =
        "[ObservableProperty]\r\n" +
        "Color textColor3 = Color.FromRgba(154, 205, 50, 200);";
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
