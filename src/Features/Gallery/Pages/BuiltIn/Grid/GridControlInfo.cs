namespace MAUIsland.Gallery.BuiltIn;
class GridControlInfo : IControlInfo 
{
    public string ControlName => nameof(Grid);
    public string ControlRoute => typeof(GridPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_glance_default_12_regular
    };
    public string ControlDetail => "The .NET Multi-platform App UI (.NET MAUI) Grid, is a layout that organizes its children into rows and columns, which can have proportional or absolute sizes. By default, a Grid contains one row and one column. In addition, a Grid can be used as a parent layout that contains other child layouts.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/grid?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;

}