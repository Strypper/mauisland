namespace MAUIsland.Core;
class OCRControlInfo : IGithubGalleryCardInfo
{
    public string RepositoryName => "ocr";
    public string AuthorName => "kfrancis";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_tab_in_private_24_regular
    };
    public string ControlName => "OCR";
    public string ControlDetail => "OCR provides a plugin designed to facilitate Optical Character Recognition (OCR) using only platform APIs. This plugin is available for both Xamarin and MAUI (Multi-platform App UI), making it easier for developers to integrate OCR capabilities into their applications without relying on external dependencies like Tesseract.";
    public string ControlRoute => $"MAUIsland.OCRPage";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/Community/Helpers/OCR";
    public string DocumentUrl => "https://github.com/kfrancis/ocr"; //SvnUrl
    public string GroupName => ControlGroupInfo.GitHubCommunity;
    public GalleryCardType CardType => GalleryCardType.Helper;
    public GalleryCardStatus CardStatus => GalleryCardStatus.NotCompleted;
    public DateTime LastUpdate => default;
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}