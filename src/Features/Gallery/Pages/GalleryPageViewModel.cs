namespace MAUIsland;

public partial class GalleryPageViewModel : NavigationAwareBaseViewModel
{

    #region [ Fields ]
    private readonly IControlsService controlsService;
    private readonly ILocalControlService localControlService;
    #endregion

    #region [ CTor ]
    public GalleryPageViewModel(IControlsService controlsService, 
                                ILocalControlService localControlService,
                                IAppNavigator appNavigator) 
        : base(appNavigator)
    {
        this.controlsService = controlsService;
        this.localControlService = localControlService;
    }
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    ObservableCollection<ControlGroupInfo> controlGroups;
    #endregion

    #region [ Overrides ]
    protected override async void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        LoadControlsAsync().FireAndForget();
    }
    #endregion

    #region [ Methods ]
    async Task LoadControlsAsync()
    {
        var controlGroups = await controlsService.GetControlGroupsAsync();

        ControlGroups = new ObservableCollection<ControlGroupInfo>(controlGroups.Where(x => x.IsVisibile == true));
    }
    #endregion

    #region [ RelayCommands ]
    [RelayCommand]
    Task ViewControlsAsync(ControlGroupInfo controlGroupInfo)
        => AppNavigator.NavigateAsync(
            AppRoutes.CardsByGroupPage,
            args: controlGroupInfo
        );

    [RelayCommand]
    Task ViewControlsInNewWindowAsync(ControlGroupInfo controlGroupInfo)
        => AppNavigator.NavigateAsync(
            AppRoutes.CardsByGroupPage,
            inNewWindow: true,
            args: controlGroupInfo);
    #endregion
}
