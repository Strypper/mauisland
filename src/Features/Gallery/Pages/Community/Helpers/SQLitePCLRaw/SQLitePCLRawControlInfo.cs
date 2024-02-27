namespace MAUIsland;
public class SQLitePCLRawControlInfo : IGithubGalleryCardInfo
{
    public string RepositoryName => "SQLitePCL.raw";
    public string AuthorName => "ericsink";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_database_search_20_regular
    };
    public string ControlName => "SQLitePCL.raw";
    public string ControlDetail => "SQLitePCL.raw is a Portable Class Library (PCL) for low-level (raw) access to SQLite. This package does not provide an API which is friendly to app developers. Rather, it provides an API which handles platform and configuration issues, upon which a friendlier API can be built. In order to use this package, you will need to also add one of the SQLitePCLRaw.provider.* packages and call SQLitePCL.raw.SetProvider(). Convenience packages are named SQLitePCLRaw.bundle_*.";
    public string ControlRoute => typeof(SQLitePCLRawPage).FullName;
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/Community/Helpers/SQLitePCLRaw";
    public string DocumentUrl => throw new NotImplementedException();  //SvnUrl
    public string GroupName => ControlGroupInfo.GitHubCommunity;
    public GalleryCardType CardType => GalleryCardType.Helper;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => default;
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}
