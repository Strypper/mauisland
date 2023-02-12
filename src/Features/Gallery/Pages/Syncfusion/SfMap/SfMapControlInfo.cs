using Syncfusion.Maui.Maps;

namespace MAUIsland.Gallery.Syncfusion;
class SfMapControlInfo : IControlInfo 
{
    public string ControlName => nameof(SfMaps);
    public string ControlRoute => typeof(SfMapPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The .NET MAUI Maps control is a powerful data visualization component that displays statistical information for a geographical area. It has highly interactive and customizable features such as selection, tooltip, legends, markers, bubbles, and color mapping. Using the Maps control, you can generate maps for population density, sales, political boundaries, weather, elections, and routes.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Syncfusion/{ControlName}";
    public string DocumentUrl => $"https://help.syncfusion.com/maui/maps/overview";
    public string GroupName => ControlGroupInfo.SyncfusionControls;
}