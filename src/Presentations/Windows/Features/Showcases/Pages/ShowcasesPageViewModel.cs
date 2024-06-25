using MAUIsland.GitHubFeatures;

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
    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    BaseMockUp mauiPlanet = new Iphone15Model()
    {
        MockUps = new List<string>()
        {
            "maui_planets_001.png",
            "maui_planets_002.png",
            "maui_planets_003.png"
        }
    };

    [ObservableProperty]
    BaseMockUp gadgetsStoreApp = new SamsungS8Model()
    {
        MockUps = new List<string>()
        {
            "gadgets_store_app_1.gif",
            "gadgets_store_app_2.gif",
            "gadgets_store_app_3.gif"
        }
    };

    [ObservableProperty]
    BaseMockUp callingApp = new SamsungS8Model()
    {
        MockUps = new List<string>()
        {
            "calling_app_1.gif"
        }
    };

    [ObservableProperty]
    BaseMockUp fourSeasonsApp = new SamsungS8Model()
    {
        MockUps = new List<string>()
        {
            "four_seasons_1.gif"
        }
    };

    [ObservableProperty]
    BaseMockUp chickAndPaddy = new Iphone15Model()
    {
        MockUps = new List<string>()
        {
            "chick_and_paddy_1.png",
            "chick_and_paddy_2.png",
            "chick_and_paddy_3.png",
            "chick_and_paddy_4.png",
        }
    };

    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}