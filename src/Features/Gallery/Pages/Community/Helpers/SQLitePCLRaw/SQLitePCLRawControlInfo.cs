using Octokit;

namespace MAUIsland;

public class SQLitePCLRawControlInfo : IGithubGalleryCardInfo
{
    private readonly Repository repository;

    public SQLitePCLRawControlInfo()
    {
        var owner = "ericsink";
        var repo = "SQLitePCL.raw";

        var github = new GitHubClient(new ProductHeaderValue("SQLitePCLRaw"));
        repository = github.Repository.Get(owner, repo).Result;
    }

    public string ControlName => repository.Name;
    public string ControlRoute => typeof(SQLitePCLRawPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_database_search_20_regular
    };
    public string ControlDetail => "SQLitePCL.raw is a Portable Class Library (PCL) for low-level (raw) access to SQLite. This package does not provide an API which is friendly to app developers. Rather, it provides an API which handles platform and configuration issues, upon which a friendlier API can be built. In order to use this package, you will need to also add one of the SQLitePCLRaw.provider.* packages and call SQLitePCL.raw.SetProvider(). Convenience packages are named SQLitePCLRaw.bundle_*.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/Community/Helpers/SQLitePCLRaw";
    public string DocumentUrl => repository.SvnUrl;
    public string GroupName => ControlGroupInfo.GitHubCommunity;
    public string RepositoryName => repository.Name;
    public string AuthorName => repository.Owner.Name;
    public GalleryCardType CardType => GalleryCardType.Helper;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => repository.UpdatedAt.DateTime;
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}
