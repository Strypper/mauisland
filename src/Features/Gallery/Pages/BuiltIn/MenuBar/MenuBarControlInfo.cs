namespace MAUIsland.Gallery.BuiltIn;

class MenuBarControlInfo : IControlInfo
{
    public string ControlName => nameof(MenuBar);
    public string ControlRoute => typeof(MenuBarPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_web_asset_24_regular
    };
    public string ControlDetail => "A .NET Multi-platform App UI (.NET MAUI) menu bar is a container that presents a set of menus in a horizontal row, at the top of an app on Mac Catalyst and Windows.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/menu-bar?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}
