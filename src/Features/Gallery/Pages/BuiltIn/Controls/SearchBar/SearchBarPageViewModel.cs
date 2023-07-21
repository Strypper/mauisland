namespace MAUIsland;

public partial class SearchBarPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IControlsService mauiControlsService;
    #endregion

    #region [CTor]
    public SearchBarPageViewModel(IAppNavigator appNavigator,
                                  IControlsService mauiControlsService)
                                : base(appNavigator)
    {
        this.mauiControlsService = mauiControlsService;
    }
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    ObservableCollection<IGalleryCardInfo> controlGroupList;

    [ObservableProperty]
    string standardSearchBarXamlCode = "<SearchBar Placeholder=\"Search items...\" />";

    [ObservableProperty]
    string performASearchWithEventHandlersXamlCode = 
        "<SearchBar Placeholder=\"Search items...\"\r\n" +
        "           x:Name=\"EventHandlerSearchBar\"\r\n" +
        "           TextChanged=\"OnSearchAsync\"/>";

    [ObservableProperty]
    string performASearchWithEventHandlersCSCode =
        "private async void OnSearchAsync(object sender, TextChangedEventArgs args)\r\n" +
        "{\r\n        ViewModel.ControlGroupList.Clear();\r\n\r\n" +
        "    var items = await mauiControlsService.GetControlsAsync(ViewModel.ControlInformation.GroupName);\r\n\r\n" +
        "    var filtered = items.Where(x => x.ControlName.ToLower().Contains(EventHandlerSearchBar.Text.ToLower(), StringComparison.OrdinalIgnoreCase));\r\n\r\n" +
        "    foreach (var item in filtered)\r\n" +
        "    {\r\n" +
        "        ViewModel.ControlGroupList.Add(item);\r\n" +
        "    }\r\n" +
        "}";

    [ObservableProperty]
    string performASearchWithViewModelXamlCode =
        "<SearchBar Placeholder=\"Search items...\"\r\n" +
        "           x:Name=\"searchBar\"\r\n" +
        "           SearchCommand=\"{x:Binding SearchCommand}\"\r\n" +
        "           SearchCommandParameter=\"{Binding Text, Source={x:Reference searchBar}}\"/>";

    [ObservableProperty]
    string performASearchWithViewModelCSCode =
        "[RelayCommand]\r\n" +
        "private async Task SearchAsync(string query)\r\n" +
        "{\r\n" +
        "    ControlGroupList.Clear();\r\n\r\n" +
        "    var items = await mauiControlsService.GetControlsAsync(ControlInformation.GroupName);\r\n\r\n" +
        "    foreach (var item in items.Where(x => x.ControlName.ToLower().Contains(query.ToLower())))\r\n" +
        "    {\r\n" +
        "        ControlGroupList.Add(item);\r\n" +
        "    }\r\n" +
        "}";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
        ControlGroupList = new ObservableCollection<IGalleryCardInfo>();
        ControlInformation = query.GetData<IGalleryCardInfo>();

        LoadDataAsync().FireAndForget();
    }
    #endregion

    #region [ Relay Commands ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    private async Task SearchAsync(string query)
    {
        ControlGroupList.Clear();

        var items = await mauiControlsService.GetControlsAsync(ControlInformation.GroupName);

        foreach (var item in items.Where(x => x.ControlName.ToLower().Contains(query.ToLower())))
        {
            ControlGroupList.Add(item);
        }
    }
    #endregion

    #region [Data]
    private async Task LoadDataAsync()
    {
        ControlGroupList.Clear();

        var items = await mauiControlsService.GetControlsAsync(ControlInformation.GroupName);

        foreach (var item in items)
        {
            ControlGroupList.Add(item);
        }
        return;
    }
    #endregion
}