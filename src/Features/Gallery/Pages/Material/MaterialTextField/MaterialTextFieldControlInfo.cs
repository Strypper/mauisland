using Material.Components.Maui;

namespace MAUIsland.Gallery.Material;
class MaterialTextFieldControlInfo : IControlInfo
{
    public string ControlName => nameof(TextField);
    public string ControlRoute => typeof(MaterialTextFieldPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_text_field_24_regular
    };
    public string ControlDetail => "Text fields allow users to enter text into a UI.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Material/MaterialTextField";
    public string DocumentUrl => $"https://mdc-maui.github.io/text-field";
    public string GroupName => ControlGroupInfo.MaterialComponent;
}