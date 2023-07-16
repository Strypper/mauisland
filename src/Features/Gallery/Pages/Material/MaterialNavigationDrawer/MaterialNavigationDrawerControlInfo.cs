using Material.Components.Maui;

namespace MAUIsland;
class MaterialNavigationDrawerControlInfo : IControlInfo
{
    public string ControlName => nameof(NavigationDrawer);
    public string ControlRoute => typeof(MaterialNavigationDrawerPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_navigation_24_regular
    };
    public string ControlDetail => "Navigation drawers provide ergonomic access to destinations in an app.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Material/MaterialNavigationDrawer";
    public string DocumentUrl => $"https://mdc-maui.github.io/navigation-drawer";
    public string GroupName => ControlGroupInfo.MaterialComponent;
}