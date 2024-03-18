using Syncfusion.Maui.ListView;

namespace MAUIsland.Gallery.Syncfusion;
class SfListViewControlInfo : IGalleryCardInfo
{
    public string ControlName => nameof(SfListView);
    public string ControlRoute => typeof(SfListViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_apps_list_24_regular
    };
    public string ControlDetail => "The Syncfusion .NET MAUI ListView renders set of data items using Maui views or custom templates. Data can easily be grouped, sorted, and filtered.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/Syncfusion/Controls/{ControlName}";
    public string DocumentUrl => $"https://help.syncfusion.com/maui/listview/overview";
    public string GroupName => ControlGroupInfo.SyncfusionControls;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}