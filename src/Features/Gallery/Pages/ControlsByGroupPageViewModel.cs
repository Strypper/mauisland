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
    Task NavigateToDetailAsync(IControlInfo control) => AppNavigator.NavigateAsync(control.ControlRoute, args: control);

    [RelayCommand]
    Task NavigateToDetailInNewWindowAsync(IControlInfo control) => AppNavigator.NavigateAsync(control.ControlRoute, inNewWindow: true, args: control);

    [RelayCommand]
    async Task OpenUrlAsync(string url)
    {
        IsBusy = true;
        await AppNavigator.OpenUrlAsync(url);
        IsBusy = false;
    }
    #endregion

    #region [Overrides]

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlGroup = query.GetData<ControlGroupInfo>();

        CommunityToolkit.Diagnostics.Guard.IsNotNull(ControlGroup);

        LoadDataAsync(true)
            .FireAndForget();
    }
    #endregion

    #region [Methods]

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
