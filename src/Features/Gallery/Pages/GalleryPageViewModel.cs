namespace MAUIsland;

public partial class GalleryPageViewModel : NavigationAwareBaseViewModel
{
    private readonly IControlsService controlsService;

    public GalleryPageViewModel(
        IControlsService controlsService,
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
        this.controlsService = controlsService;
    }

    [ObservableProperty]
    ObservableCollection<ControlGroupInfo> controlGroups;

    protected override async void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        var controlGroups = await controlsService.GetControlGroupsAsync();

        ControlGroups = new ObservableCollection<ControlGroupInfo>(controlGroups);
    }

    [RelayCommand]
    Task ViewControlsAsync(ControlGroupInfo controlGroupInfo)
        => AppNavigator.NavigateAsync(
            AppRoutes.ControlsByGroupPage,
            args: controlGroupInfo
        );
}
