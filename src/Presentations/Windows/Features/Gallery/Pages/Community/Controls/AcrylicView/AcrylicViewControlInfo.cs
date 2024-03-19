namespace MAUIsland;
class AcrylicViewControlInfo : IGithubGalleryCardInfo
{
    public string RepositoryName => "AcrylicView.MAUI";
    public string AuthorName => "sswi";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_tab_in_private_24_regular
    };
    public string ControlName => "AcrylicView.MAUI";
    public string ControlDetail => "Acrylic is a type of Brush that creates a translucent texture. It can be applied to app surfaces to add depth and help establish a visual hierarchy. It is based on a Fluent Design System component that adds physical texture (material) and depth to your app. Acrylic’s most noticeable characteristic is its transparency. There are two acrylic blend types that change what’s visible through the material: Background acrylic reveals the desktop wallpaper and other windows that are behind the currently active app, adding depth between application windows while celebrating the user’s personalization preferences. In-app acrylic adds a sense of depth within the app frame, providing both focus and hierarchy.";
    public string ControlRoute => typeof(AcrylicViewPage).FullName;
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/Community/Controls/AcrylicView";
    public string DocumentUrl => "https://github.com/sswi/AcrylicView.MAUI"; //SvnUrl
    public string GroupName => ControlGroupInfo.GitHubCommunity;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => GalleryCardStatus.NotCompleted;
    public DateTime LastUpdate => default;
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}