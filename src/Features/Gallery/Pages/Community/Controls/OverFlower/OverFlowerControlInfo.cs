namespace MAUIsland.Gallery.Community;
class OverFlowerControlInfo : IGithubGalleryCardInfo
{
    public string ControlName => nameof(OverFlower);
    public string ControlRoute => typeof(OverFlowerPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "Simple control to display scrolling overflow content!";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Community/{ControlName}";
    public string DocumentUrl => $"https://github.com/nor0x/OverFlower";
    public string GroupName => ControlGroupInfo.GitHubCommunity;

    public GalleryCardType CardType => GalleryCardType.Control;

    public GalleryCardStatus CardStatus => throw new NotImplementedException();

    public DateTime LastUpdate => throw new NotImplementedException();

    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();

    public string RepositoryUrl => "https://github.com/nor0x/OverFlower";

    public string AuthorUrl => "https://github.com/nor0x";

    public string AuthorAvatar => "https://avatars.githubusercontent.com/u/3210391?v=4";

    public int Stars => 21;

    public int Forks => 0;

    public int Issues => 0;

    public string License => "MIT";

    public List<PlatformInfo> SupportedPlatformsInfo => new() { new() { Id = "1", Name = "Android", Logo = "androidlogo.png" },
                                                                new() { Id = "2", Name = "IOS", Logo = "ioslogo.png" },
                                                                new() { Id = "3", Name = "Windows", Logo = "windowslogo.png"} };
}