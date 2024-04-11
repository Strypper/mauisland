namespace MAUIsland.Core;
class ZXingNetMauIGalleryCardInfo : IGithubGalleryCardInfo
{
    public string RepositoryName => "ZXing.Net.Maui";
    public string AuthorName => "Redth";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_barcode_scanner_24_regular
    };
    public string ControlName => "ZXing.Net.Maui";
    public string ControlDetail => "The successor to ZXing.Net.Mobile is a C#/.NET library based on the open source Barcode Library: ZXing (Zebra Crossing), using the ZXing.Net Port. It works with Xamarin.iOS, Xamarin.Android, Tizen, and UWP. The goal of ZXing.Net.Mobile is to make scanning barcodes as effortless and painless as possible in your own applications.";
    public string ControlRoute => "MAUIsland.ZXingNetMauiPage";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/Community/Helpers/ZXingNetMaui";
    public string DocumentUrl => "https://github.com/Redth/ZXing.Net.Maui";  //SvnUrl
    public string GroupName => ControlGroupInfo.GitHubCommunity;
    public GalleryCardType CardType => GalleryCardType.Helper;
    public GalleryCardStatus CardStatus => GalleryCardStatus.Completed;
    public DateTime LastUpdate => default;
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}