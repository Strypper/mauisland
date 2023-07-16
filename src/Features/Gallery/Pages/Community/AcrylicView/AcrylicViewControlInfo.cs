using Xe.AcrylicView;

namespace MAUIsland.Gallery.Community;
class AcrylicViewControlInfo : IControlInfo
{
    public string ControlName => nameof(AcrylicView);
    public string ControlRoute => typeof(AcrylicViewPage).FullName;
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
}