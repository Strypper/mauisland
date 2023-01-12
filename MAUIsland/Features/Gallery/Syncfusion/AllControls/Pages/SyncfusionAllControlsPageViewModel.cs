namespace MAUIsland;

public partial class SyncfusionAllControlsPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly ISyncfusionControlsService syncfusionControlsService;
    #endregion

    #region [CTor]
    public SyncfusionAllControlsPageViewModel(IAppNavigator appNavigator,
                                              ISyncfusionControlsService syncfusionControlsService)
                                            : base(appNavigator)
    {
        this.syncfusionControlsService = syncfusionControlsService;
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    int span = 4;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<ControlInfo> items;
    #endregion

    #region [RelayCommand]
    [RelayCommand]
    Task NavigateToDetailAsync(string controlRoute) => AppNavigator.NavigateAsync(controlRoute);
    #endregion

    #region [Methods]
    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();

        LoadDataAsync(true)
            .FireAndForget();
    }


    private async Task LoadDataAsync(bool forced)
    {
        if (IsBusy) return;
        IsBusy = true;


        var items = await syncfusionControlsService.GetAllControlInfoAsync();

        IsBusy = false;


        if (Items == null)
        {
            Items = new ObservableCollection<ControlInfo>(items);
            return;
        }

        if (forced)
        {
            Items.Clear();
        }

        foreach (var item in items)
        {
            Items.Add(item);
        }
    }
    #endregion
}
