namespace MAUIsland;
class HorizontalStackLayoutControlInfo : IBuiltInGalleryCardInfo
{
    public string ControlName => nameof(HorizontalStackLayout);
    public string ControlRoute => typeof(HorizontalStackLayoutPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_align_space_evenly_horizontal_20_regular
    };
    public string ControlDetail => "The .NET Multi-platform App UI (.NET MAUI) HorizontalStackLayout organizes child views in a one-dimensional horizontal stack, and is a more performant alternative to a StackLayout. In addition, a HorizontalStackLayout can be used as a parent layout that contains other child layouts.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/BuiltIn/Layouts/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/horizontalstacklayout?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
    public BuiltInGalleryCardStatus Status => BuiltInGalleryCardStatus.Stable;
    public GalleryCardType CardType => GalleryCardType.Layout;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
    public string GitHubAuthorIssueName => "dotnet";
    public string GitHubRepositoryIssueName => "maui";
    public List<string> GitHubIssueLabels => new List<string>() { "layout-stack" };
}