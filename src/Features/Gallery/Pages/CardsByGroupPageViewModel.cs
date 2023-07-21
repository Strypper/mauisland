namespace MAUIsland;

public partial class CardsByGroupPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]
    private readonly IControlsService mauiControlsService;
    #endregion

    #region [ CTor ]
    public CardsByGroupPageViewModel(
        IAppNavigator appNavigator,
        IControlsService mauiControlsService
    ) : base(appNavigator)
    {
        this.mauiControlsService = mauiControlsService;
    }
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    int span = 4;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    bool isGalleryDetailVisible;

    [ObservableProperty]
    ObservableCollection<IGalleryCardInfo> items;

    [ObservableProperty]
    ControlGroupInfo controlGroup;

    #endregion

    #region [ RelayCommand ]
    [RelayCommand]
    Task NavigateToDetailAsync(IGalleryCardInfo control) => AppNavigator.NavigateAsync(control.ControlRoute, args: control);

    [RelayCommand]
    Task NavigateToDetailInNewWindowAsync(IGalleryCardInfo control) => AppNavigator.NavigateAsync(control.ControlRoute, inNewWindow: true, args: control);

    [RelayCommand]
    async Task OpenUrlAsync(string url)
    {
        IsBusy = true;
        await AppNavigator.OpenUrlAsync(url);
        IsBusy = false;
    }
    #endregion

    #region [ Overrides ]

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlGroup = query.GetData<ControlGroupInfo>();

        CommunityToolkit.Diagnostics.Guard.IsNotNull(ControlGroup);

        LoadDataAsync(true)
            .FireAndForget();
    }
    #endregion

    #region [ Methods ]

    private async Task LoadDataAsync(bool forced)
    {
        if (IsBusy) return;
        IsBusy = true;

        var items = await mauiControlsService.GetControlsAsync(ControlGroup.Name);

        IsBusy = false;

        if (Items is null)
        {
            Items = new ObservableCollection<IGalleryCardInfo>(items);
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
