namespace MAUIsland;
public partial class DataGridPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IControlsService MauiControlsService;
    private readonly IGitHubRepositorySyncService GitHubRepositorySyncService;
    #endregion

    #region [ CTor ]
    public DataGridPageViewModel(IAppNavigator appNavigator,
                                 IControlsService controlsService,
                                 IGitHubRepositorySyncService gitHubRepositorySyncService) 
        : base(appNavigator)
    {
        this.MauiControlsService = controlsService;
        this.GitHubRepositorySyncService = gitHubRepositorySyncService;
    }
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    IGalleryCardInfo selectedControl;

    [ObservableProperty]
    ObservableCollection<IGalleryCardInfo> controlGroupList;

    [ObservableProperty]
    GitHubRepositoryLocalDbModel selectedGithubControl;

    [ObservableProperty]
    ObservableCollection<GitHubRepositoryLocalDbModel> githubControlGroupList = new();

    [ObservableProperty]
    string normalDataGridTip =
        "A tip when using the DataGrid, data from the ItemsSource is passed to each column. Each DataGridColumn has a property named ‘PropertyName’. This property should be assigned the name of the property from the ItemsSource model that you want to bind to the column. Once this is done, the ‘{x:Binding}’ expression can be used in the CellTemplate to bind to that specific property";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

        LoadDataAsync().FireAndForget();

    }
    #endregion

    #region [ Relay commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);
    #endregion

    #region [ Data ]
    private async Task LoadDataAsync()
    {
        IsRefreshing = true;

        ControlGroupList = new ObservableCollection<IGalleryCardInfo>();
        ControlGroupList.Clear();

        var controls = await MauiControlsService.GetControlsAsync(ControlInformation.GroupName);
        foreach (var item in controls)
        {
            ControlGroupList.Add(item);
        }

        GithubControlGroupList = new ObservableCollection<GitHubRepositoryLocalDbModel>();
        GithubControlGroupList.Clear();

        var githubControls = await GitHubRepositorySyncService.GetAllAsync();
        foreach (var item in githubControls) 
        {
            GithubControlGroupList.Add(item);
        }

        IsRefreshing = false;
    }
    #endregion
}