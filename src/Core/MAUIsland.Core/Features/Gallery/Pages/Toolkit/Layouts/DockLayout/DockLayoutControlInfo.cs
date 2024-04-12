using CommunityToolkit.Maui.Layouts;

namespace MAUIsland.Core;

class DockLayoutControlInfo : ICommunityToolkitGalleryCardInfo
{
    public string ControlName => nameof(DockLayout);
    public string ControlRoute => "MAUIsland.DockLayoutPage";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_table_16_regular,
    };
    public string ControlDetail => "DockLayout is a layout where views can be docked to the sides of the layout container.\r\nThe image below shows how a DockLayout is conceptually structured. Child views are docked at one of 4 possible docking positions: Top, Bottom, Left or Right (equivalent to DockPosition.Top, DockPosition.Bottom, DockPosition.Left, and DockPosition.Right). Views that are not explicitly docked (or with DockPosition.None) are displayed at the center (or between Top / Bottom and Left / Right positions).";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/Toolkit/Layouts/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/layouts/docklayout";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
    public GalleryCardType CardType => GalleryCardType.Layout;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}
