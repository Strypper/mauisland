using IconPacks.Material;

namespace MAUIsland;
class MaterialSwitchControlInfo : IMaterialUIControlInfo
{
    public string ControlName => nameof(Material.Components.Maui.Switch);
    public string ControlRoute => typeof(MaterialSwitchPage).FullName;

    public IconKind MaterialIcon => IconKind.ToggleOn;

    public List<PlatformInfo> SupportedPlatformsInfo => new() { new() { Id = "1", Name = "Android", Logo = "androidlogo.png" },
                                                                new() { Id = "2", Name = "IOS", Logo = "ioslogo.png" },
                                                                new() { Id = "3", Name = "Windows", Logo = "windowslogo.png"} };
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_toggle_left_24_regular
    };
    public string ControlDetail => "Switches toggle the state of a single setting on or off.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Material/MaterialSwitch";
    public string DocumentUrl => $"https://mdc-maui.github.io/switch";
    public string GroupName => ControlGroupInfo.MaterialComponent;
}