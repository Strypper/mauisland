using Octokit;

namespace MAUIsland;
class ZXingNetMauIGalleryCardInfo : IGithubGalleryCardInfo
{
    private readonly Repository repository;
    private readonly IRepositorySyncService _repositorySyncService;

    public ZXingNetMauIGalleryCardInfo(IRepositorySyncService repositorySyncService)
    {
        _repositorySyncService = repositorySyncService;

        var owner = "Redth";
        var repoName = "ZXing.Net.Maui";

        var syncedRepo = Task.Run(async () => {
            var repo = await _repositorySyncService.GetRepositoryAsync(owner, repoName);
            return repo;
        }).ConfigureAwait(false).GetAwaiter().GetResult();

        repository = syncedRepo;
    }
    public string ControlName => "ZXing.Net.Maui";
    public string ControlRoute => typeof(ZXingNetMauiPage).FullName;
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
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_barcode_scanner_24_regular
    };
    public string ControlDetail => "The successor to ZXing.Net.Mobile is a C#/.NET library based on the open source Barcode Library: ZXing (Zebra Crossing), using the ZXing.Net Port. It works with Xamarin.iOS, Xamarin.Android, Tizen, and UWP. The goal of ZXing.Net.Mobile is to make scanning barcodes as effortless and painless as possible in your own applications.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/Community/{ControlName}";
    public string DocumentUrl => repository.SvnUrl;
    public string GroupName => ControlGroupInfo.GitHubCommunity;
    public GalleryCardType CardType => GalleryCardType.Helper;
    public GalleryCardStatus CardStatus => GalleryCardStatus.Completed;
    public DateTime LastUpdate => repository.UpdatedAt.DateTime;
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}