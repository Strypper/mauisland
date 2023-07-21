using Xe.AcrylicView;

namespace MAUIsland;
class AcrylicViewControlInfo : IGithubGalleryCardInfo
{
    public string ControlName => nameof(AcrylicView);
    public string ControlRoute => typeof(AcrylicViewPage).FullName;
    public string RepositoryUrl => "https://github.com/sswi/AcrylicView.MAUI";
    public string AuthorUrl => "https://github.com/sswi";
    public string AuthorAvatar => "https://avatars.githubusercontent.com/u/39110708?v=4";
    public int Stars => 40;
    public int Forks => 2;
    public int Issues => 1;
    public string License => "MIT license";
    public List<PlatformInfo> SupportedPlatformsInfo => new() { new() { Id = "1", Name = "Android", Logo = "androidlogo.png" },
                                                                new() { Id = "2", Name = "IOS", Logo = "ioslogo.png" },
                                                                new() { Id = "3", Name = "Windows", Logo = "windowslogo.png"} };
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_tab_in_private_24_regular
    };
    public string ControlDetail => "Acrylic is a type of Brush that creates a translucent texture. It can be applied to app surfaces to add depth and help establish a visual hierarchy. It is based on a Fluent Design System component that adds physical texture (material) and depth to your app. Acrylic’s most noticeable characteristic is its transparency. There are two acrylic blend types that change what’s visible through the material: Background acrylic reveals the desktop wallpaper and other windows that are behind the currently active app, adding depth between application windows while celebrating the user’s personalization preferences. In-app acrylic adds a sense of depth within the app frame, providing both focus and hierarchy.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Community/{ControlName}";
    public string DocumentUrl => $"https://github.com/sswi/AcrylicView.MAUI";
    public string GroupName => ControlGroupInfo.GitHubCommunity;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => GalleryCardStatus.NotCompleted;
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}