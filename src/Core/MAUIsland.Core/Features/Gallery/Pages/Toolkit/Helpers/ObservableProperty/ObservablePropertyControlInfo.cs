namespace MAUIsland.Core;

public class ObservablePropertyControlInfo : ICommunityToolkitGalleryCardInfo
{
    public string ControlName => "Observable Property";
    public string ControlRoute => "MAUIsland.ObservablePropertyPage";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The ObservableProperty type is an attribute that allows generating observable properties from annotated fields. Its purpose is to greatly reduce the amount of boilerplate that is needed to define observable properties.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/Toolkit/Helpers/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/generators/observableproperty";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
    public GalleryCardType CardType => GalleryCardType.Helper;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}