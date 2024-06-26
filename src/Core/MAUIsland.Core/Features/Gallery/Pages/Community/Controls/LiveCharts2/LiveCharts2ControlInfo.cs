namespace MAUIsland.Core;
class LiveCharts2ControlInfo : IGithubGalleryCardInfo
{
    public string RepositoryName => "LiveCharts2";
    public string AuthorName => "beto-rodriguez";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_chart_multiple_24_regular
    };
    public string ControlName => "LiveCharts2";
    public string ControlDetail => "LiveCharts2 is a library developed by beto-rodriguez. It’s a simple, flexible, interactive, and powerful tool for creating charts, maps, and gauges in .Net. It’s designed to run on multiple platforms including Maui, Uno Platform, Blazor-wasm, WPF, WinForms, Xamarin, Avalonia, WinUI, and UWP. The library is designed to be highly flexible and can be easily moved to any other drawing engine. It also supports high-performance data visualization.";
    public string ControlRoute => "MAUIsland.LiveCharts2Page";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/Community/Controls/LiveCharts2";
    public string DocumentUrl => "https://livecharts.dev/docs/maui/2.0.0-rc2/gallery";
    public string GroupName => ControlGroupInfo.GitHubCommunity;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => GalleryCardStatus.Completed;
    public DateTime LastUpdate => default;
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();

}