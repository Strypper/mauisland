using Microsoft.Maui.Controls;
using System.Reflection;

namespace MAUIsland;

public partial class ColorConverterPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    #endregion

    #region [ CTor ]
    public ColorConverterPageViewModel(IAppNavigator appNavigator)
        : base(appNavigator)
    { } 
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    ObservableCollection<IGalleryCardInfo> controlGroupList;

    [ObservableProperty]
    double blueByte;

    [ObservableProperty]
    double redByte;

    [ObservableProperty]
    double greenByte;

    [ObservableProperty]
    double alphaByte;

    [ObservableProperty]
    Color exampleColor = Color.FromRgba(1, 1, 1, 1);

    [ObservableProperty]
    Color exampleColorNotIncludeAlpha = Colors.White;

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
    string cSharpColorConverterTestingViewModel =
        "[ObservableProperty]\r\n" +
        "Color exampleColor = Color.FromRgba(1, 1, 1, 1); \r\n" +
        "//You can add any color you want, you can pass int from 0 to 255 to FromRgba, or you can use Microsoft.Maui.Graphics.Colors";

    [ObservableProperty]
    string cSharpColorNoAlphaConverterTestingViewModel =
        "[ObservableProperty]\r\n" +
        "Color exampleColor = Color.FromRgba(1, 1, 1, 1); \r\n" +
        "[ObservableProperty]\r\n" +
        "Color exampleColorNotIncludeAlpha = Colors.White;\r\n" +
        "//You can add any color you want, you can pass int from 0 to 255 to FromRgb";

    [ObservableProperty]
    string xamlColorToBlackOrWhiteConverterTextTesting =
        "<Label Text=\"Text Color\"\r\n" +
        "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToBlackOrWhiteConverter}}\"\r\n" +
        "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToBlackOrWhiteConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "        <toolkit:ColorToBlackOrWhiteConverter x:Key=\"ColorToBlackOrWhiteConverter\" />\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToByteAlphaConverterTextTesting =
    "<Label Text=\"Text Color\"\r\n" +
    "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToByteAlphaConverter}}\"\r\n" +
    "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToByteAlphaConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "        <toolkit:ColorToByteAlphaConverter x:Key=\"ColorToByteAlphaConverter\" />\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToByteBlueConverterTextTesting =
    "<Label Text=\"Text Color\"\r\n" +
    "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToByteBlueConverter}}\"\r\n" +
    "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToByteBlueConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "        <toolkit:ColorToByteBlueConverter x:Key=\"ColorToByteBlueConverter\" />\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToByteGreenConverterTextTesting =
    "<Label Text=\"Text Color\"\r\n" +
    "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToByteGreenConverter}}\"\r\n" +
    "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToByteGreenConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "        <toolkit:ColorToByteGreenConverter x:Key=\"ColorToByteGreenConverter\" />\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToByteRedConverterTextTesting =
        "<Label Text=\"Text Color\"\r\n" +
        "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToByteRedConverter}}\"\r\n" +
        "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToByteRedConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "        <toolkit:ColorToByteRedConverter x:Key=\"ColorToByteRedConverter\" />\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToCmykaStringConverterTextTesting =
        "<Label Text=\"Text Color\"\r\n" +
        "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToCmykaStringConverter}}\"\r\n" +
        "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToCmykaStringConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "        <toolkit:ColorToCmykaStringConverter x:Key=\"ColorToCmykaStringConverter\"/>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToCmykStringConverterTextTesting =
        "<Label Text=\"Text Color\"\r\n" +
        "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToCmykStringConverter}}\"\r\n" +
        "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToCmykStringConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "        <toolkit:ColorToCmykStringConverter x:Key=\"ColorToCmykStringConverter\"/>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToColorForTextConverterTextTesting =
    "<Label Text=\"Text Color\"\r\n" +
    "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToColorForTextConverter}}\"\r\n" +
    "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToColorForTextConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <toolkit:ColorToColorForTextConverter x:Key=\"ColorToColorForTextConverter\"/>\r\n\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToDegreeHueConverterTextTesting =
        "<Label Text=\"Text Color\"\r\n" +
        "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToDegreeHueConverter}}\"\r\n" +
        "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToDegreeHueConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <toolkit:ColorToDegreeHueConverter x:Key=\"ColorToDegreeHueConverter\"/>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToGrayScaleColorConverterTextTesting =
    "<Label Text=\"Text Color\"\r\n" +
    "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToGrayScaleColorConverter}}\"\r\n" +
    "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToGrayScaleColorConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <toolkit:ColorToGrayScaleColorConverter x:Key=\"ColorToGrayScaleColorConverter\"/>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToHexRgbStringConverterTextTesting =
        "<Label Text=\"Text Color\"\r\n" +
        "       TextColor=\"{x:Binding ExampleColorNotIncludeAlpha, Converter={x:StaticResource ColorToHexRgbStringConverter}}\"\r\n" +
        "       FontAttributes=\"Bold\"/>\r\n" +
        "<Label Text=\"Text Color\"\r\n" +
        "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToHexRgbStringConverter}}\"\r\n" +
        "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToHexRgbStringConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <toolkit:ColorToHexRgbStringConverter x:Key=\"ColorToHexRgbStringConverter\"/>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToHexRgbaStringConverterTextTesting =
        "<Label Text=\"Text Color\"\r\n" +
        "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToHexRgbaStringConverter}}\"\r\n" +
        "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToHexRgbaStringConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <toolkit:ColorToHexRgbaStringConverter x:Key=\"ColorToHexRgbaStringConverter\"/>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToHslStringConverterTextTesting =
    "<Label Text=\"Text Color\"\r\n" +
    "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToHslStringConverter}}\"\r\n" +
    "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToHslStringConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <toolkit:ColorToHslStringConverter x:Key=\"ColorToHslStringConverter\"/>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToHslaStringConverterTextTesting =
        "<Label Text=\"Text Color\"\r\n" +
        "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToHslaStringConverter}}\"\r\n" +
        "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToHslaStringConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <toolkit:ColorToHslaStringConverter x:Key=\"ColorToHslaStringConverter\"/>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToInverseColorConverterTextTesting =
    "<Label Text=\"Text Color\"\r\n" +
    "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToInverseColorConverter}}\"\r\n" +
    "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToInverseColorConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <toolkit:ColorToInverseColorConverter x:Key=\"ColorToInverseColorConverter\"/>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToPercentBlackKeyConverterTextTesting =
        "<Label Text=\"Text Color\"\r\n" +
        "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToPercentBlackKeyConverter}}\"\r\n" +
        "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToPercentBlackKeyConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <toolkit:ColorToPercentBlackKeyConverter x:Key=\"ColorToPercentBlackKeyConverter\"/>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToPercentCyanConverterTextTesting =
    "<Label Text=\"Text Color\"\r\n" +
    "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToPercentCyanConverter}}\"\r\n" +
    "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToPercentCyanConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <toolkit:ColorToPercentCyanConverter x:Key=\"ColorToPercentCyanConverter\"/>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToPercentMagentaConverterTextTesting =
        "<Label Text=\"Text Color\"\r\n" +
        "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToPercentMagentaConverter}}\"\r\n" +
        "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToPercentMagentaConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <toolkit:ColorToPercentMagentaConverter x:Key=\"ColorToPercentMagentaConverter\"/>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToPercentYellowConverterTextTesting =
        "<Label Text=\"Text Color\"\r\n" +
        "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToPercentYellowConverter}}\"\r\n" +
        "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToPercentYellowConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <toolkit:ColorToPercentYellowConverter x:Key=\"ColorToPercentYellowConverter\"/>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToRgbStringConverterTextTesting =
    "<Label Text=\"Text Color\"\r\n" +
    "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToRgbStringConverter}}\"\r\n" +
    "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToRgbStringConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <toolkit:ColorToRgbStringConverter x:Key=\"ColorToRgbStringConverter\"/>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlColorToRgbaStringConverterTextTesting =
        "<Label Text=\"Text Color\"\r\n" +
        "       TextColor=\"{x:Binding ExampleColor, Converter={x:StaticResource ColorToRgbaStringConverter}}\"\r\n" +
        "       FontAttributes=\"Bold\"/>";

    [ObservableProperty]
    string xamlColorToRgbaStringConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <toolkit:ColorToRgbaStringConverter x:Key=\"ColorToRgbaStringConverter\"/>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";
    #endregion

    #region[ Relay Command ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    Task OpenColorToBlackOrWhiteConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-black-or-white-converter");

    [RelayCommand]
    Task OpenColorToByteAlphaConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-byte-alpha-converter");

    [RelayCommand]
    Task OpenColorToByteBlueConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-byte-blue-converter");

    [RelayCommand]
    Task OpenColorToByteRedConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-byte-red-converter");

    [RelayCommand]
    Task OpenColorToByteGreenConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-byte-green-converter");
    
    [RelayCommand]
    Task OpenColorToCmykaStringConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-cmyka-string-converter");
    
    [RelayCommand]
    Task OpenColorToCmykStringConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-cmyk-string-converter");

    [RelayCommand]
    Task OpenColorToColorForTextConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-color-for-text-converter");

    [RelayCommand]
    Task OpenColorToDegreeHueConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-degree-hue-converter");

    [RelayCommand]
    Task OpenColorToGrayScaleColorConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-gray-scale-color-converter");

    [RelayCommand]
    Task OpenColorToHexRgbStringConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-gray-scale-color-converter");

    [RelayCommand]
    Task OpenColorToHexRgbaStringConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-hex-rgba-string-converter");

    [RelayCommand]
    Task OpenColorToHslStringConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-hsl-string-converter");

    [RelayCommand]
    Task OpenColorToHslaStringConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-hsla-string-converter");

    [RelayCommand]
    Task OpenColorToInverseColorConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-inverse-color-converter");

    [RelayCommand]
    Task OpenColorToPercentBlackKeyConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-percent-black-key-converter");

    [RelayCommand]
    Task OpenColorToPercentCyanConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-percent-cyan-converter");

    [RelayCommand]
    Task OpenColorToPercentMagentaConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-percent-magenta-converter");

    [RelayCommand]
    Task OpenColorToPercentYellowConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-percent-yellow-converter");

    [RelayCommand]
    Task OpenColorToRgbStringConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-rgb-string-converter");

    [RelayCommand]
    Task OpenColorToRgbaStringConverterUrlAsync()
        => AppNavigator.OpenUrlAsync("https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/converters/color-to-rgba-string-converter");

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
    partial void OnRedByteChanged(double value)
    {
        ExampleColor = Color.FromRgba(value, ExampleColor.Green, ExampleColor.Blue, ExampleColor.Alpha);
        ExampleColorNotIncludeAlpha = Color.FromRgb(value, ExampleColor.Green, ExampleColor.Blue);
    }

    partial void OnGreenByteChanged(double value)
    {
        ExampleColor = Color.FromRgba(ExampleColor.Red, value, ExampleColor.Blue, ExampleColor.Alpha);
        ExampleColorNotIncludeAlpha = Color.FromRgb(ExampleColor.Red, value, ExampleColor.Blue);
    }

    partial void OnBlueByteChanged(double value)
    {
        ExampleColor = Color.FromRgba(ExampleColor.Red, ExampleColor.Green, value, ExampleColor.Alpha);
        ExampleColorNotIncludeAlpha = Color.FromRgb(ExampleColor.Red, ExampleColor.Green, value);
    }

    partial void OnAlphaByteChanged(double value)
    {
        ExampleColor = Color.FromRgba(ExampleColor.Red, ExampleColor.Green, ExampleColor.Blue, value);
    }
    #endregion
}
