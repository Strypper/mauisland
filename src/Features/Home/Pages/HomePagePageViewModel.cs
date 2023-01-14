namespace MAUIsland;
public partial class HomePageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IHomeService homeService;
    #endregion
    public HomePageViewModel(
        IAppNavigator appNavigator,
        IHomeService homeService
    ) : base(appNavigator)
    {
        this.homeService = homeService;
    }

    #region [Properties]
    [ObservableProperty]
    ObservableCollection<MAUIFact> mauiFacts;

    [ObservableProperty]
    bool isBusy;
    #endregion

    #region [Methods]

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

        IsBusy = false;

        if (MauiFacts == null)
        {
            MauiFacts = new ObservableCollection<MAUIFact>(items);
            return;
        }

        if (forced)
        {
            MauiFacts.Clear();
        }

        foreach (var item in items)
        {
            MauiFacts.Add(item);
        }
    }
    #endregion

    #region [RelayCommands]
    [RelayCommand]
    Task OpenFactUrlAsync(MAUIFact fact) => AppNavigator.OpenUrlAsync(fact.FactUrl);
    #endregion
}