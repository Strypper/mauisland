namespace MAUIsland;

public partial class SyncfusionListViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IMAUIControlsService mauiControlsService;
    #endregion

    #region [CTor]
    public SyncfusionListViewPageViewModel(IAppNavigator appNavigator,
                                           IMAUIControlsService mauiControlsService) 
									: base(appNavigator)
	{
        this.mauiControlsService = mauiControlsService;
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    int span = 5;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<ControlInfo> mauiAllControlsItems;
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


        var items = await mauiControlsService.GetAllControlInfoAsync();

        IsBusy = false;


        if (MauiAllControlsItems == null)
        {
            MauiAllControlsItems = new ObservableCollection<ControlInfo>(items);
            return;
        }

        if (forced)
        {
            MauiAllControlsItems.Clear();
        }

        foreach (var item in items)
        {
            MauiAllControlsItems.Add(item);
        }
    }
    #endregion
}
