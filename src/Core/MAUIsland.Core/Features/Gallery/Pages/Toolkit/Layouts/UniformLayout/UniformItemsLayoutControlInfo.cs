using CommunityToolkit.Maui.Layouts;

namespace MAUIsland.Core;

class UniformItemsLayoutControlInfo : ICommunityToolkitGalleryCardInfo
{
    public string ControlName => nameof(UniformItemsLayout);
    public string ControlRoute => "MAUIsland.UniformItemsLayoutPage";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_dock_row_20_regular,
    };
    public string ControlDetail => "The UniformItemsLayout is a layout where all rows and columns have the same size.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/Toolkit/Layouts/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/layouts/uniformitemslayout";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
    public GalleryCardType CardType => GalleryCardType.Layout;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}
