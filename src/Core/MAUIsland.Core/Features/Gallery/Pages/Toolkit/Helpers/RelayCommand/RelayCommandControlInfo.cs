namespace MAUIsland.Core;

class RelayCommandControlInfo : ICommunityToolkitGalleryCardInfo
{
    public string ControlName => "Relay Command";
    public string ControlRoute => "MAUIsland.RelayCommandPage";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "The RelayCommand type is an attribute that allows generating relay command properties for annotated methods. Its purpose is to completely eliminate the boilerplate that is needed to define commands wrapping private methods in a viewmodel.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/Toolkit/Helpers/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/generators/relaycommand";
    public string GroupName => ControlGroupInfo.CommunityToolkit;
    public GalleryCardType CardType => GalleryCardType.Helper;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}
