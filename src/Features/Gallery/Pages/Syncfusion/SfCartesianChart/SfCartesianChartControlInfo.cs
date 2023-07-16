using Syncfusion.Maui.Charts;

namespace MAUIsland.Gallery.Syncfusion;
class SfCartesianChartControlInfo : IControlInfo
{
    public string ControlName => nameof(SfCartesianChart);
    public string ControlRoute => typeof(SfCartesianChartPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_data_histogram_24_regular
    };
    public string ControlDetail => "The .NET MAUI chart provides a perfect way to visualize data with a high level of user involvement that focuses on development, productivity, and simplicity of use. Chart also provides a wide variety of charting features that can be used to visualize large quantities of data, as well as flexibility in data binding and user customization.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/BuiltIn/{ControlName}";
    public string DocumentUrl => "https://help.syncfusion.com/maui/cartesian-charts/overview";
    public string GroupName => ControlGroupInfo.SyncfusionControls;
}