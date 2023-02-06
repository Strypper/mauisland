namespace MAUIsland;
public partial class SfListViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IControlsService mauiControlsService;
    #endregion
    public SfListViewPageViewModel(
        IAppNavigator appNavigator,
        IControlsService mauiControlsService
    ) : base(appNavigator)
    {
        this.mauiControlsService = mauiControlsService;
    }

    #region [Properties]
    [ObservableProperty]
    int span = 5;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<IControlInfo> mauiAllControlsItems;

    [ObservableProperty]
    ControlGroupInfo controlGroup;
    #endregion

    #region [RelayCommand]
    [RelayCommand]
    Task NavigateToDetailAsync(string controlRoute) => AppNavigator.NavigateAsync(controlRoute);
    #endregion

    #region [Override]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlGroup = query.GetData<ControlGroupInfo>();

        LoadDataAsync(true)
            .FireAndForget();
    }
    #endregion

    #region [Methods]
    private async Task LoadDataAsync(bool forced)
    {
        if (IsBusy) return;
        IsBusy = true;


        var items = await mauiControlsService.GetControlsAsync(ControlGroupInfo.SyncfusionControls);

        IsBusy = false;


        if (MauiAllControlsItems == null)
        {
            MauiAllControlsItems = new ObservableCollection<IControlInfo>(items);
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