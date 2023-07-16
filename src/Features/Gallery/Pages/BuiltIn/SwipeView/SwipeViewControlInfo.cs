namespace MAUIsland.Gallery.BuiltIn;

class SwipeViewControlInfo : IControlInfo
{
    public string ControlName => nameof(SwipeView);
    public string ControlRoute => typeof(SwipeViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_swipe_right_24_regular
    };
    public string ControlDetail => "SwipeView is a container control that wraps around an item of content, and provides context menu items that are revealed by a swipe gesture.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}
