using Octokit;

namespace MAUIsland.Gallery.Community;
class OverFlowerControlInfo : IGithubGalleryCardInfo
{

    private readonly Repository repository;

    public OverFlowerControlInfo()
    {
        var owner = "nor0x";
        var repo = "OverFlower";

        var github = new GitHubClient(new ProductHeaderValue(nameof(OverFlower)));
        repository = github.Repository.Get(owner, repo).Result;
    }

    public string ControlName => repository.Name;
    public string ControlRoute => typeof(OverFlowerPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "Simple control to display scrolling overflow content!";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/Community/Controls/{ControlName}";
    public string DocumentUrl => repository.SvnUrl;
    public string GroupName => ControlGroupInfo.GitHubCommunity;
    public string RepositoryName => repository.Name;
    public string AuthorName => repository.Owner.Name;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => repository.UpdatedAt.DateTime;
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}