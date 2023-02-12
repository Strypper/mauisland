namespace MAUIsland.Gallery.BuiltIn;
class VerticalStackLayoutControlInfo : IControlInfo 
{
    public string ControlName => nameof(VerticalStackLayout);
    public string ControlRoute => typeof(VerticalStackLayoutPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_align_space_evenly_vertical_20_regular
    };
    public string ControlDetail => "The .NET Multi-platform App UI (.NET MAUI) VerticalStackLayout organizes child views in a one-dimensional vertical stack, and is a more performant alternative to a StackLayout. In addition, a VerticalStackLayout can be used as a parent layout that contains other child layouts.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/verticalstacklayout?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}