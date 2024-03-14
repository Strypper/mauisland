namespace MAUIsland.Gallery.Community;
class OverFlowerControlInfo : IGithubGalleryCardInfo
{
    public string RepositoryName => "OverFlower";
    public string AuthorName => "nor0x";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_24_regular
    };
    public string ControlName => "OverFlower";
    public string ControlDetail => "Simple control to display scrolling overflow content!";
    public string ControlRoute => typeof(OverFlowerPage).FullName;
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/Community/Controls/{ControlName}";
    public string DocumentUrl => "https://github.com/nor0x/OverFlower";  //SvnUrl
    public string GroupName => ControlGroupInfo.GitHubCommunity;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => default;
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}