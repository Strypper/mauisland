namespace MAUIsland.Gallery.Community;
class ZXingNetMauiControlInfo : IControlInfo
{
    public string ControlName => "ZXing.Net.Maui";
    public string ControlRoute => typeof(ZXingNetMauiPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_barcode_scanner_24_regular
    };
    public string ControlDetail => "The successor to ZXing.Net.Mobile is a C#/.NET library based on the open source Barcode Library: ZXing (Zebra Crossing), using the ZXing.Net Port. It works with Xamarin.iOS, Xamarin.Android, Tizen, and UWP. The goal of ZXing.Net.Mobile is to make scanning barcodes as effortless and painless as possible in your own applications.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Community/{ControlName}";
    public string DocumentUrl => $"https://github.com/Redth/ZXing.Net.Maui";
    public string GroupName => ControlGroupInfo.GitHubCommunity;
}