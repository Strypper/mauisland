namespace MAUIsland;

class CollectionViewControlInfo : IBuiltInGalleryCardInfo
{
    public string ControlName => nameof(CollectionView);
    public string ControlRoute => typeof(CollectionViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_apps_list_detail_24_regular,
    };
    public string ControlDetail => "CollectionView is a view for presenting lists of data using different layout specifications.  ";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/BuiltIn/Layouts/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
    public BuiltInGalleryCardStatus Status => BuiltInGalleryCardStatus.ExtremelyBuggy;
    public GalleryCardType CardType => GalleryCardType.Layout;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}
