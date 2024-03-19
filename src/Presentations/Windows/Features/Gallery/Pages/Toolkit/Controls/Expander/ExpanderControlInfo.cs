using CommunityToolkit.Maui.Views;

namespace MAUIsland;

internal class ExpanderControlInfo : ICommunityToolkitGalleryCardInfo
{
    public string ControlName => nameof(Expander);
    public string ControlRoute => typeof(ExpanderPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_panel_top_expand_20_regular
    };
    public string ControlDetail => "The Expander control provides an expandable container to host any content. The control has two main properties to store your content.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Toolkit/Controls/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/views/expander";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}
