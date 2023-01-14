using Syncfusion.Maui.ListView;

namespace MAUIsland.Gallery.Syncfusion;

class ListViewControlInfo : IControlInfo
{
    public string ControlName => nameof(SfListView);
    public string ControlRoute => typeof(SyncfusionListViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_swipe_right_24_regular
    };
    public string ControlDetail => "The Syncfusion .NET MAUI ListView renders set of data items using Maui views or custom templates. Data can easily be grouped, sorted, and filtered.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/Syncfusion/{ControlName}";
    public string DocumentUrl => $"https://help.syncfusion.com/maui/{ControlName.TrimStart()}/overview";
    public string GroupName => ControlGroupInfo.SyncfusionControls;
}