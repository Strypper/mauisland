namespace MAUIsland.Core;
class PopupControlInfo : IBuiltInGalleryCardInfo
{
    public string ControlName => "Popup";
    public string ControlRoute => $"MAUIsland.{ControlName}Page";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_square_shadow_12_regular
    };
    public string ControlDetail => "Displaying an alert, asking a user to make a choice, or displaying a prompt is a common UI task. .NET Multi-platform App UI (.NET MAUI) has three methods on the Page class for interacting with the user via a pop-up: DisplayAlert, DisplayActionSheet, and DisplayPromptAsync. Pop-ups are rendered with native controls on each platform.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/BuiltIn/Helpers/Popup";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pop-ups";
    public string GroupName => ControlGroupInfo.BuiltInControls;
    public BuiltInGalleryCardStatus Status => BuiltInGalleryCardStatus.Stable;
    public GalleryCardType CardType => GalleryCardType.Helper;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
    public string GitHubAuthorIssueName => "dotnet";
    public string GitHubRepositoryIssueName => "maui";
    public List<string> GitHubIssueLabels => new List<string>() { "area-controls-dialogalert" };
}