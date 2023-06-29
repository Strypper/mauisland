using Material.Components.Maui;

namespace MAUIsland.Gallery.Material;
class MaterialComboBoxControlInfo : IControlInfo
{
    public string ControlName => nameof(ComboBox);
    public string ControlRoute => typeof(MaterialComboBoxPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_caret_down_24_regular
    };
    public string ControlDetail => "ComboBox displays a short list of items, from which the user can select an item.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Material/MaterialComboBox";
    public string DocumentUrl => $"https://mdc-maui.github.io/combo-box";
    public string GroupName => ControlGroupInfo.MaterialComponent;
}