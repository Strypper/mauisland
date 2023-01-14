namespace MAUIsland;

public partial class ControlsByGroupPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IControlsService mauiControlsService;
    #endregion

    #region [CTor]
    public ControlsByGroupPageViewModel(
        IAppNavigator appNavigator,
        IControlsService mauiControlsService
    ) : base(appNavigator)
    {
        this.mauiControlsService = mauiControlsService;
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    int span = 4;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<IControlInfo> items;

    [ObservableProperty]
    ControlGroupInfo controlGroup;

    #endregion

    #region [RelayCommand]
    [RelayCommand]
    Task NavigateToDetailAsync(string controlRoute) => AppNavigator.NavigateAsync(controlRoute);

    [RelayCommand]
    Task NavigateToDetailInNewWindowAsync(string controlRoute) => AppNavigator.NavigateAsync(controlRoute, inNewWindow: true);
    #endregion

    #region [Methods]

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlGroup = query.GetData<ControlGroupInfo>();

        LoadDataAsync(true)
            .FireAndForget();
    }

    private async Task LoadDataAsync(bool forced)
    {
        if (IsBusy) return;
        IsBusy = true;

        var items = await mauiControlsService.GetControlsAsync(ControlGroup.Name);

        IsBusy = false;
        if (Items == null)
        {
            Items = new ObservableCollection<IControlInfo>(items);
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
