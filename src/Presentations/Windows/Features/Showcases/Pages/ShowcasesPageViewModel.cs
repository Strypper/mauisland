using MAUIsland.GitHubFeatures;
using MAUIsland.Mockup;

namespace MAUIsland.Showcases;

public partial class ShowcasesPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]

    public ShowcasesPageViewModel(IAppNavigator appNavigator,
                                  IGitHubService gitHubService) : base(appNavigator)
    {
        this.gitHubService = gitHubService;
    }

    #endregion

    #region [ Overrides ]

    protected override void OnInit(IDictionary<string, object> query)
    {
        Mockups = new List<BaseMockup>()
        {
            MauiPlanetApp,
            ChickAndPaddyApp,
            MauiTrackizerApp,
            EcommerceApp,
            RealStateApp,
            StarBuckApp,
        };

        RefreshAsync().FireAndForget();
    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    int collectionViewSpan = 3;

    [ObservableProperty]
    string mockUpPageUrl = nameof(MockupPage);

    [ObservableProperty]
    ICollection<BaseMockup> mockups;

    [ObservableProperty]
    BaseMockup mauiPlanetApp = new IPhone13MiniModel()
    {
        AppName = "MAUI Planet",
        Mockups = new()
        {
            "maui_planets_001.png",
            "maui_planets_002.png",
            "maui_planets_003.png"
        },
        CurrentMockupFrameState = "iPhone 13 Mini",
        AuthorGitHubUserName = "naweed",
        GitHubRepoName = "MauiPlanets"
    };

    [ObservableProperty]
    BaseMockup mauiTrackizerApp = new AppleIphone15ProMaxModel()
    {
        AppName = "MAUI Trackizer",
        Mockups =
        {
            "maui_trackizer_7.jpg",
            "maui_trackizer_1.jpg",
            "maui_trackizer_2.jpg",
            "maui_trackizer_3.jpg",
            "maui_trackizer_4.jpg",
            "maui_trackizer_5.jpg",
            "maui_trackizer_6.jpg",
        },

        CurrentMockupFrameState = "Apple iPhone 15 Pro Max",
        AuthorGitHubUserName = "chsakell",
        GitHubRepoName = "maui-trackizer"
    };

    [ObservableProperty]
    BaseMockup ecommerceApp = new SamsungGalaxyS22UltraModel()
    {
        AppName = "Ecommerce",
        Mockups =
        {
            "ecommerce_1.jpg",
            "ecommerce_2.jpg",
            "ecommerce_3.jpg",
            "ecommerce_4.jpg",
            "ecommerce_5.jpg",
            "ecommerce_6.jpg",
            "ecommerce_7.jpg",
        },
        CurrentMockupFrameState = "Samsung Galaxy S22 Ultra",
        AuthorGitHubUserName = "exendahal",
        GitHubRepoName = "ecommerce_maui"
    };

    [ObservableProperty]
    BaseMockup realStateApp = new GooglePixel6ProModel()
    {
        AppName = "Real State App",
        Mockups = new()
        {
            "real_state_app_1.png",
            "real_state_app_2.png",
            "real_state_app_3.png",
            "real_state_app_4.png",
            "real_state_app_5.png"
        },
        CurrentMockupFrameState = "Google Pixel 6 Pro",
        AuthorGitHubUserName = "marcfabregatb",
        GitHubRepoName = "RealEstate.App"
    };

    [ObservableProperty]
    BaseMockup starBuckApp = new GooglePixel5Model()
    {
        AppName = "Starbuck",
        Mockups = new()
        {
            "starbuck_1.png",
            "starbuck_2.png"
        },
        CurrentMockupFrameState = "Google Pixel 5",
        AuthorGitHubUserName = "sattasundar",
        GitHubRepoName = "maui-starbucks-ui"
    };

    [ObservableProperty]
    BaseMockup chickAndPaddyApp = new IPhone13MiniModel()
    {
        AppName = "Chick And Paddy",
        Mockups = new()
        {
            "chick_and_paddy_1.png",
            "chick_and_paddy_2.png",
            "chick_and_paddy_3.png",
            "chick_and_paddy_4.png",
        },
        CurrentMockupFrameState = "iPhone 13 Mini",
        AuthorGitHubUserName = "tuyen-vuduc",
        GitHubRepoName = "chick-and-paddy-dotnet-maui"
    };

    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    Task NavigateAsync(string url)
        => AppNavigator.NavigateAsync(url);
    #endregion

    #region [ Methods ]
    async Task RefreshAsync()
    {
        var mauiPlanetAppTask = this.gitHubService.GetRepository(MauiPlanetApp.AuthorGitHubUserName, MauiPlanetApp.GitHubRepoName);
        var starBuckAppTask = this.gitHubService.GetRepository(StarBuckApp.AuthorGitHubUserName, StarBuckApp.GitHubRepoName);
        var mauiTrackizerAppTask = this.gitHubService.GetRepository(MauiTrackizerApp.AuthorGitHubUserName, MauiTrackizerApp.GitHubRepoName);
        var ecommerceAppTask = this.gitHubService.GetRepository(EcommerceApp.AuthorGitHubUserName, EcommerceApp.GitHubRepoName);
        var chickAndPaddyAppTask = this.gitHubService.GetRepository(ChickAndPaddyApp.AuthorGitHubUserName, ChickAndPaddyApp.GitHubRepoName);
        var realStateAppTask = this.gitHubService.GetRepository(RealStateApp.AuthorGitHubUserName, RealStateApp.GitHubRepoName);

        var results = await Task.WhenAll(mauiPlanetAppTask,
                                         starBuckAppTask,
                                         mauiTrackizerAppTask,
                                         ecommerceAppTask,
                                         chickAndPaddyAppTask,
                                         realStateAppTask);

        foreach (var result in results)
        {
            result.Match(
                success =>
                {
                    var repositoryInformation = success.AttachedData as GitHubRepositoryModel;
                    if (repositoryInformation is null)
                        return Task.CompletedTask;

                    var mockup = Mockups.FirstOrDefault(x => x.GitHubRepoName == repositoryInformation.Name);
                    if (mockup is null)
                        return Task.CompletedTask;

                    mockup.RepoStarsCount = repositoryInformation.StarCount;
                    mockup.AuthorAvatar = repositoryInformation.AuthorAvatarUrl;
                    mockup.AuthorLinkUrl = repositoryInformation.AuthorUrl;
                    mockup.RepoUrl = repositoryInformation.SvnUrl;
                    return Task.CompletedTask;
                },
                error =>
                {
                    var errorMessage = error.ErrorMessage;
                    return Task.CompletedTask;
                }
            );
        }
    }


    #endregion
}