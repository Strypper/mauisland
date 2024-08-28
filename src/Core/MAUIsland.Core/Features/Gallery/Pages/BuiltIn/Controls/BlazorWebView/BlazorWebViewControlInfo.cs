namespace MAUIsland.Core;

public class BlazorWebViewControlInfo : IBuiltInGalleryCardInfo
{
    public string ControlName => "BlazorWebView";
    public string ControlRoute => $"MAUIsland.{ControlName}Page";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_globe_star_20_regular
    };
    public string ControlDetail => "The .NET Multi-platform App UI (.NET MAUI) BlazorWebView is a control that enables you to host a Blazor web app in your .NET MAUI app. These apps, known as Blazor Hybrid apps, enable a Blazor web app to be integrated with platform features and UI controls. The BlazorWebView control can be added to any page of a .NET MAUI app, and pointed to the root of the Blazor app. The Razor components run natively in the .NET process and render web UI to an embedded web view control. In .NET MAUI, Blazor Hybrid apps can run on all the platforms supported by .NET MAUI.";
    public string GitHubUrl => "https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/BuiltIn/Controls/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}";
    public string GroupName => ControlGroupInfo.BuiltInControls;
    public BuiltInGalleryCardStatus Status => BuiltInGalleryCardStatus.Stable;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
    public string GitHubAuthorIssueName => "dotnet";
    public string GitHubRepositoryIssueName => "maui";
    public List<string> GitHubIssueLabels => new List<string>() { "area-blazor" };
}
