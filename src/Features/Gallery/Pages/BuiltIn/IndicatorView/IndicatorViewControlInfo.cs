namespace MAUIsland.Gallery.BuiltIn;

class IndicatorViewControlInfo : IControlInfo
{
    public string ControlName => nameof(IndicatorView);
    public string ControlRoute => typeof(IndicatorViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_more_horizontal_48_regular
    };
    public string ControlDetail => " IndicatorView is a control that displays indicators that represent the number of items, and current position, in a CarouselView";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/indicatorview?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}