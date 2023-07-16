namespace MAUIsland;
class MaterialButtonControlInfo : IControlInfo
{
    public string ControlName => nameof(Material.Components.Maui.Button);
    public string ControlRoute => typeof(MaterialButtonPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_add_circle_24_regular
    };
    public string ControlDetail => "Buttons allow users to take actions, and make choices, with a single tap.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Material/MaterialButton";
    public string DocumentUrl => $"https://mdc-maui.github.io/button";
    public string GroupName => ControlGroupInfo.MaterialComponent;
}