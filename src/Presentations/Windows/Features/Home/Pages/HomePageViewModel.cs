namespace MAUIsland;
public partial class HomePageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IHomeService homeService;
    private readonly IConversationService conversationService;
    #endregion

    #region [ CTor ]

    public HomePageViewModel(
        IAppNavigator appNavigator,
        IHomeService homeService,
        IConversationService conversationService
    ) : base(appNavigator)
    {
        this.homeService = homeService;
        this.conversationService = conversationService;
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string projectRepo = "https://github.com/Strypper/mauisland";

    [ObservableProperty]
    MAUIFact selectedMauiFact;

    [ObservableProperty]
    ObservableCollection<MAUIFact> mauiFacts;

    [ObservableProperty]
    ObservableCollection<ApplicationNew> applicationNews;

    [ObservableProperty]
    bool isBusy;
    #endregion

    #region [ Methods ]

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        LoadDataAsync(true)
            .FireAndForget();
    }

    private async Task LoadDataAsync(bool forced)
    {
        if (IsBusy) return;
        IsBusy = true;

        var items = await homeService.GetMAUIFactsAsync();

        var news = await homeService.GetApplicationNews();

        IsBusy = false;

        if (MauiFacts == null && ApplicationNews == null)
        {
            MauiFacts = new ObservableCollection<MAUIFact>(items);
            ApplicationNews = new ObservableCollection<ApplicationNew>(news);
            return;
        }

        if (forced)
        {
            MauiFacts.Clear();
            ApplicationNews.Clear();
        }

        foreach (var item in items)
        {
            MauiFacts.Add(item);
        }

        foreach (var item in news)
        {
            ApplicationNews.Add(item);
        }
    }
    #endregion

    #region [ RelayCommands ]

    [RelayCommand]
    Task OpenFactUrlAsync(MAUIFact fact) => AppNavigator.OpenUrlAsync(fact.FactUrl);

    [RelayCommand]
    async Task OpenUrlAsync(string url)
    {
        await AppNavigator.OpenUrlAsync(url);
    }
    #endregion
}
