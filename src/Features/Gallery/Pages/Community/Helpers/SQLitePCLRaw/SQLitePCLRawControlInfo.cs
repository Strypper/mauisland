using Octokit;

namespace MAUIsland;

public class SQLitePCLRawControlInfo : IGithubGalleryCardInfo
{
    private readonly Repository repository;
    private readonly IRepositorySyncService _repositorySyncService;

    public SQLitePCLRawControlInfo(IRepositorySyncService repositorySyncService)
    {
        _repositorySyncService = repositorySyncService;

        var owner = "ericsink";
        var repoName = "SQLitePCL.raw";

        var syncedRepo = Task.Run(async () => {
            var repo = await _repositorySyncService.GetRepositoryAsync(owner, repoName);
            return repo;
        }).ConfigureAwait(false).GetAwaiter().GetResult();

        repository = syncedRepo;
    }

    public string ControlName => repository.Name;
    public string ControlRoute => typeof(SQLitePCLRawPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_database_search_20_regular
    };
    public string ControlDetail => "SQLitePCL.raw is a Portable Class Library (PCL) for low-level (raw) access to SQLite. This package does not provide an API which is friendly to app developers. Rather, it provides an API which handles platform and configuration issues, upon which a friendlier API can be built. In order to use this package, you will need to also add one of the SQLitePCLRaw.provider.* packages and call SQLitePCL.raw.SetProvider(). Convenience packages are named SQLitePCLRaw.bundle_*.";
    public string GitHubUrl => $"";

    public string RepositoryUrl => repository.SvnUrl;

    public string AuthorUrl => repository.Owner.Url;

    public string AuthorAvatar => repository.Owner.AvatarUrl;

    public int Stars => repository.StargazersCount;

    public int Forks => repository.ForksCount;

    public int Issues => repository.OpenIssuesCount;

    public string License => repository.License is null
                                    ? "No license"
                                    : repository.License.Name;

    public List<PlatformInfo> SupportedPlatformsInfo => new() { new() { Id = "1", Name = "Android", Logo = "androidlogo.png" },
                                                                new() { Id = "2", Name = "IOS", Logo = "ioslogo.png" },
                                                                new() { Id = "3", Name = "Windows", Logo = "windowslogo.png"} };

    public string DocumentUrl => repository.SvnUrl;

    public string GroupName => ControlGroupInfo.GitHubCommunity;

    public GalleryCardType CardType => GalleryCardType.Helper;

    public GalleryCardStatus CardStatus => throw new NotImplementedException();

    public DateTime LastUpdate => repository.UpdatedAt.DateTime;

    public List<string> DoList => throw new NotImplementedException();

    public List<string> DontList => throw new NotImplementedException();
}
