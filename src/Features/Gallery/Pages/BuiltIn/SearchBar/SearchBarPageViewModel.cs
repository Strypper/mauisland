namespace MAUIsland;


public partial class SearchBarPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public SearchBarPageViewModel(IAppNavigator appNavigator)
                                : base(appNavigator)
    {

    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

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

        ControlInformation = query.GetData<IControlInfo>();

    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}
