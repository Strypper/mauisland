using Syncfusion.Maui.Gauges;

namespace MAUIsland.Gallery.Syncfusion;
class SfRadialGaugeControlInfo : IGalleryCardInfo
{
    public string ControlName => nameof(SfRadialGauge);
    public string ControlRoute => typeof(SfRadialGaugePage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_top_speed_24_regular
    };
    public string ControlDetail => "The Syncfusion .NET MAUI Radial Gauge is a multi-purpose data visualization control, that displays numerical values on a circular scale. It has a rich set of features such as axes, ranges, pointers, and annotations that are fully customizable and extendable. Use it to create speedometers, temperature monitors, dashboards, meter gauges, multi axis clocks, watches, progress indicators, compasses, and more.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Syncfusion/Controls/SfRadialGauge";
    public string DocumentUrl => "https://help.syncfusion.com/maui/radial-gauge/overview";
    public string GroupName => ControlGroupInfo.SyncfusionControls;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();

    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}