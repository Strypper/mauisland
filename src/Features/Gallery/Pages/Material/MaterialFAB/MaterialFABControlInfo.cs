using Material.Components.Maui;

namespace MAUIsland.Gallery.Material;
class MaterialFABControlInfo : IControlInfo
{
    public string ControlName => nameof(FAB);
    public string ControlRoute => typeof(MaterialFABPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_add_square_24_regular
    };
    public string ControlDetail => "FABs(floating action button) represents the primary action of a screen.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Material/MaterialFAB";
    public string DocumentUrl => $"https://mdc-maui.github.io/FAB";
    public string GroupName => ControlGroupInfo.MaterialComponent;
}