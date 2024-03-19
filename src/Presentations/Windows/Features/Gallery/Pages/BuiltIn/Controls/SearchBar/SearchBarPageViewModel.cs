using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUIsland;

public partial class SearchBarPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IControlsService MauiControlsService;
    #endregion

    #region [CTor]
    public SearchBarPageViewModel(IAppNavigator appNavigator,
                                  IControlsService mauiControlsService)
                                : base(appNavigator)
    {
        this.MauiControlsService = mauiControlsService;
    }
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    string searchText = string.Empty;

    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    ObservableCollection<IGalleryCardInfo> controlGroupListForEventCall;

    [ObservableProperty]
    ObservableCollection<IGalleryCardInfo> controlGroupListForCommandCall;

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
        "           x:Name=\"ViewModelSearchBar\"\r\n" +
        "           Text=\"{x:Binding SearchText}\"/>";

    [ObservableProperty]
    string performASearchWithViewModelCSCode =
        "[ObservableProperty]\r\n" +
        "[NotifyCanExecuteChangedFor(nameof(SearchCommand))]\r\n" +
        "string searchText = string.Empty;\r\n\r\n" +
        "partial void OnSearchTextChanged(string value)\r\n" +
        "{\r\n" +
        "    SearchCommand.ExecuteAsync(null);\r\n" +
        "}\r\n\r\n" +
        "[RelayCommand]\r\n" +
        "private async Task SearchAsync(string query)\r\n" +
        "{\r\n" +
        "    ControlGroupList.Clear();\r\n\r\n" +
        "    var items = await mauiControlsService.GetControlsAsync(ControlInformation.GroupName);\r\n\r\n" +
        "    foreach (var item in items.Where(x => x.ControlName.ToLower().Contains(SearchText.ToLower())))\r\n" +
        "    {\r\n" +
        "        ControlGroupList.Add(item);\r\n" +
        "    }\r\n" +
        "}";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
        ControlGroupListForEventCall = new ObservableCollection<IGalleryCardInfo>();
        ControlGroupListForCommandCall = new ObservableCollection<IGalleryCardInfo>();
        ControlInformation = query.GetData<IGalleryCardInfo>();

        LoadDataAsync().FireAndForget();
    }
    #endregion

    #region [ Methods ]
    partial void OnSearchTextChanged(string value)
    {
        SearchCommand.ExecuteAsync(null);
    }
    #endregion

    #region [ Relay Commands ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    private async Task SearchAsync()
    {
        ControlGroupListForCommandCall.Clear();

        var items = await MauiControlsService.GetControlsAsync(ControlInformation.GroupName);

        foreach (var item in items.Where(x => x.ControlName.ToLower().Contains(SearchText.ToLower())))
        {
            ControlGroupListForCommandCall.Add(item);
        }
    }
    #endregion

    #region [Data]
    private async Task LoadDataAsync()
    {
        ControlGroupListForEventCall.Clear();
        ControlGroupListForCommandCall.Clear();

        var items = await MauiControlsService.GetControlsAsync(ControlInformation.GroupName);

        foreach (var item in items)
        {
            ControlGroupListForEventCall.Add(item);
            ControlGroupListForCommandCall.Add(item);
        }
        return;
    }
    #endregion
}