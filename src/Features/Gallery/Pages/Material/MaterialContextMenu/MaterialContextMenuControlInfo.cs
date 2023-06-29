using Material.Components.Maui;

namespace MAUIsland;
class MaterialContextMenuControlInfo : IControlInfo
{
    public string ControlName => nameof(ContextMenu);
    public string ControlRoute => typeof(MaterialContextMenuPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_list_24_regular
    };
    public string ControlDetail => "ContextMenu display a list of choices on a temporary surface, It can be included in the component that has the touch event.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Material/{ControlName}";
    public string DocumentUrl => $"https://mdc-maui.github.io/context-menu";
    public string GroupName => ControlGroupInfo.MaterialComponent;
}