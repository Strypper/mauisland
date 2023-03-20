namespace MAUIsland.Gallery.BuiltIn;
using SkiaSharp.Views.Maui.Controls.Hosting;

class RefreshViewControlInfo : IControlInfo
{
    public string ControlName => nameof(RefreshView);
    public string ControlRoute => typeof(RefreshViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_arrow_sync_24_regular
    };
    public string ControlDetail => "RefreshView is a container control that provides pull to refresh functionality for scrollable content.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
}
