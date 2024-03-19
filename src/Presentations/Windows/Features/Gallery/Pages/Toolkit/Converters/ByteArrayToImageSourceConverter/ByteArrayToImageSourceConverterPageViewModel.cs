using Microsoft.Maui.Controls;
using System.Reflection;

namespace MAUIsland;

public partial class ByteArrayToImageSourceConverterPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public ByteArrayToImageSourceConverterPageViewModel(IAppNavigator appNavigator)
        : base(appNavigator)
    { } 
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    byte[] imageByteArray;

    [ObservableProperty]
    string imageByteArrayToString;

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
        "<Image Source=\"{x:Binding ImageByteArray, Converter={x:StaticResource ByteArrayToImageSourceConverter}}\"/>";

    [ObservableProperty]
    string xamlConverterSetup =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "        <toolkit:ByteArrayToImageSourceConverter x:Key=\"ByteArrayToImageSourceConverter\"/>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string cSharpxamlConverterTestingViewModel =
        "[ObservableProperty]\r\n" +
        "byte[] imageByteArray;";
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
        ImageByteArray = await ImageUrlToByteArrayAsync("https://aka.ms/campus.jpg");
        ImageByteArrayToString = ByteArrayToString(ImageByteArray);
    }
    #endregion

    #region [ Method ]
    public async Task<byte[]> ImageUrlToByteArrayAsync(string imageUrl)
    {
        using var httpClient = new HttpClient();
        return await httpClient.GetByteArrayAsync(imageUrl).ConfigureAwait(false);
    }
    public string ByteArrayToString(byte[] byteArray)
    {
        return BitConverter.ToString(byteArray);
    }
    #endregion
}
