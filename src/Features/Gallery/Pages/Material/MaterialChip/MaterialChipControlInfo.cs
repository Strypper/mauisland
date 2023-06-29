using Material.Components.Maui;

namespace MAUIsland;
class MaterialChipControlInfo : IControlInfo
{
    public string ControlName => nameof(Chip);
    public string ControlRoute => typeof(MaterialChipPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_oval_24_regular
    };
    public string ControlDetail => "Chips are compact elements that represent an input, attribute, or action.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Material/{ControlName}";
    public string DocumentUrl => $"https://mdc-maui.github.io/chip";
    public string GroupName => ControlGroupInfo.MaterialComponent;
}