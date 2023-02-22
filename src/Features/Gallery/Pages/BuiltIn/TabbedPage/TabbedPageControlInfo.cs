namespace MAUIsland.Gallery.BuiltIn;
class TabbedPageControlInfo : IControlInfo
{
    public string ControlName => nameof(TabbedPage);
    public string ControlRoute => typeof(TabbedPagePage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_phone_pagination_24_regular
    };
    public string ControlDetail => "The .NET Multi-platform App UI (.NET MAUI) TabbedPage maintains a collection of children of type Page, only one of which is fully visible at a time. Each child is identified by a series of tabs across the top or bottom of the page. Typically, each child will be a ContentPage and when its tab is selected the page content is displayed.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pages/tabbedpage?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}