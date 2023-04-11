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

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    ObservableCollection<IControlInfo> controlGroupList;

    [ObservableProperty]
    string standardSearchBarXamlCode = "<SearchBar Placeholder=\"Search items...\" />";

    [ObservableProperty]
    string performASearchWithEventHandlers1XamlCode = "<SearchBar TextChanged=\"OnTextChanged\" />\r\n<ListView x:Name=\"searchResults\" >";

    [ObservableProperty]
    string performASearchWithEventHandlers2XamlCode = "<ContentPage ...>\r\n    <ContentPage.BindingContext>\r\n        <viewmodels:SearchViewModel />\r\n    </ContentPage.BindingContext>\r\n    <StackLayout>\r\n        <SearchBar x:Name=\"searchBar\"\r\n                   SearchCommand=\"{Binding PerformSearch}\"\r\n                   SearchCommandParameter=\"{Binding Text, Source={x:Reference searchBar}}\"/>\r\n        <ListView x:Name=\"searchResults\"\r\n                  ItemsSource=\"{Binding SearchResults}\" />\r\n    </StackLayout>\r\n</ContentPage>";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
        ControlGroupList = new ObservableCollection<IControlInfo>();
        ControlInformation = query.GetData<IControlInfo>();

        LoadDataAsync().FireAndForget();
    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);


    [RelayCommand]
    private async Task SearchAsync(string query)
    {
        ControlGroupList.Clear();

        var items = await mauiControlsService.GetControlsAsync(ControlInformation.GroupName);

        foreach (var item in items.Where(x => x.ControlName.Equals(query)))
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