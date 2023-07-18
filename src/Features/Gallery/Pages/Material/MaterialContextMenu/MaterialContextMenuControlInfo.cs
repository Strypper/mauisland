using IconPacks.Material;
using Material.Components.Maui;

namespace MAUIsland;
class MaterialContextMenuControlInfo : IMaterialUIControlInfo
{
    public string ControlName => nameof(ContextMenu);
    public string ControlRoute => typeof(MaterialContextMenuPage).FullName;
    public IconKind MaterialIcon => IconKind.List;
    public List<PlatformInfo> SupportedPlatformsInfo => new() { new() { Id = "1", Name = "Android", Logo = "androidlogo.png" },
                                                                new() { Id = "2", Name = "IOS", Logo = "ioslogo.png" },
                                                                new() { Id = "3", Name = "Windows", Logo = "windowslogo.png"} };
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_list_24_regular
    };
    public string ControlDetail => "ContextMenu display a list of choices on a temporary surface, It can be included in the component that has the touch event.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Material/MaterialContextMenu";
    public string DocumentUrl => $"https://mdc-maui.github.io/context-menu";
    public string GroupName => ControlGroupInfo.MaterialComponent;

}