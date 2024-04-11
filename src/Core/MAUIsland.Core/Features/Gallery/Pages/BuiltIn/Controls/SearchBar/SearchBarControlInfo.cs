namespace MAUIsland.Core;

public class SearchBarControlInfo : IBuiltInGalleryCardInfo
{
    public string ControlName => nameof(SearchBar);
    public string ControlRoute => $"MAUIsland.{ControlName}Page";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_search_24_regular
    };
    public string ControlDetail => "SearchBar is a user input control used to initiating a search.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/BuiltIn/Controls/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}";
    public string GroupName => ControlGroupInfo.BuiltInControls;
    public BuiltInGalleryCardStatus Status => BuiltInGalleryCardStatus.Unverified;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
    public string GitHubAuthorIssueName => "dotnet";
    public string GitHubRepositoryIssueName => "maui";
    public List<string> GitHubIssueLabels => new List<string>() { "control-searchbar" };
}
