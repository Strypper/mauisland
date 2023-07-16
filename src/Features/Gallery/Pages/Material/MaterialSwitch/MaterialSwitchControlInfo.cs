namespace MAUIsland;
class MaterialSwitchControlInfo : IControlInfo
{
    public string ControlName => nameof(Material.Components.Maui.Switch);
    public string ControlRoute => typeof(MaterialSwitchPage).FullName;
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