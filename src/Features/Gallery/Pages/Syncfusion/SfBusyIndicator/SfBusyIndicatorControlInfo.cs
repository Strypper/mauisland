using Syncfusion.Maui.Core;

namespace MAUIsland.Gallery.Syncfusion;
class SfBusyIndicatorControlInfo : IControlInfo
{
    public string ControlName => nameof(SfBusyIndicator);
    public string ControlRoute => typeof(SfBusyIndicatorPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The Busy Indicator control for .NET MAUI provides an indication of the app loading, data processing etc. It can be customized in terms of Indicator size, color, speed and more.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => $"https://help.syncfusion.com/maui/busy-indicator/overview";
    public string GroupName => ControlGroupInfo.SyncfusionControls;
}