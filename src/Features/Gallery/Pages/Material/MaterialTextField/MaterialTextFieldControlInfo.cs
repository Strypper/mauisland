using IconPacks.Material;
using Material.Components.Maui;

namespace MAUIsland.Gallery.Material;
class MaterialTextFieldControlInfo : IMaterialUIControlInfo
{
    public string ControlName => nameof(TextField);
    public string ControlRoute => typeof(MaterialTextFieldPage).FullName;
    public IconKind MaterialIcon => IconKind.TextFields;

    public List<PlatformInfo> SupportedPlatformsInfo => new() { new() { Id = "1", Name = "Android", Logo = "androidlogo.png" },
                                                                new() { Id = "2", Name = "IOS", Logo = "ioslogo.png" },
                                                                new() { Id = "3", Name = "Windows", Logo = "windowslogo.png"} };
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_text_field_24_regular
    };
    public string ControlDetail => "Text fields allow users to enter text into a UI.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Material/MaterialTextField";
    public string DocumentUrl => $"https://mdc-maui.github.io/text-field";
    public string GroupName => ControlGroupInfo.MaterialComponent;
}