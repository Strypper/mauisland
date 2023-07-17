namespace MAUIsland.Gallery.Community;
class ZXingNetMauiControlInfo : IGithubControlInfo
{
    public string ControlName => "ZXing.Net.Maui";
    public string ControlRoute => typeof(ZXingNetMauiPage).FullName;
    public string RepositoryUrl => "https://github.com/Redth/ZXing.Net.Maui";
    public string AuthorUrl => "https://github.com/Redth";
    public string AuthorAvatar => "https://avatars.githubusercontent.com/u/271950?v=4";
    public int Stars => 341;
    public int Forks => 104;
    public int Issues => 69;
    public string License => "MIT license";

    public List<PlatformInfo> SupportedPlatformsInfo => new() { new() { Id = "1", Name = "Android", Logo = "androidlogo.png" },
                                                                new() { Id = "2", Name = "IOS", Logo = "ioslogo.png" },
                                                                new() { Id = "3", Name = "Windows", Logo = "windowslogo.png"} };
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_barcode_scanner_24_regular
    };
    public string ControlDetail => "The successor to ZXing.Net.Mobile is a C#/.NET library based on the open source Barcode Library: ZXing (Zebra Crossing), using the ZXing.Net Port. It works with Xamarin.iOS, Xamarin.Android, Tizen, and UWP. The goal of ZXing.Net.Mobile is to make scanning barcodes as effortless and painless as possible in your own applications.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Community/{ControlName}";
    public string DocumentUrl => $"https://github.com/Redth/ZXing.Net.Maui";
    public string GroupName => ControlGroupInfo.GitHubCommunity;
}