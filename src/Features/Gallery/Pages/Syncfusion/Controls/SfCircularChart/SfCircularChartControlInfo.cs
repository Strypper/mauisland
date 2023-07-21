using Syncfusion.Maui.Charts;

namespace MAUIsland;
class SfCircularChartControlInfo : IGalleryCardInfo
{
    public string ControlName => nameof(SfCircularChart);
    public string ControlRoute => typeof(SfCircularChartPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_data_pie_24_regular
    };
    public string ControlDetail => "Syncfusion .NET MAUI Charts (SfCircularChart) is used to create the chart with beautiful and enhanced UI visualization of data that are used in high-quality .NET MAUI applications.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Syncfusion/{ControlName}";
    public string DocumentUrl => $"https://help.syncfusion.com/maui/circular-charts/overview";
    public string GroupName => ControlGroupInfo.SyncfusionControls;

    public GalleryCardType CardType => GalleryCardType.Control;

    public GalleryCardStatus CardStatus => throw new NotImplementedException();

    public DateTime LastUpdate => throw new NotImplementedException();

    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}