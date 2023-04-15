namespace MAUIsland;

public partial class SearchBarPage : IControlPage
{
    #region [Services]
    private readonly IControlsService mauiControlsService;
    #endregion

    #region[View Model]
    protected SearchBarPageViewModel ViewModel { get; set; }
    #endregion

    #region [CTor]
    public SearchBarPage(SearchBarPageViewModel vm,
                         IControlsService mauiControlsService)
    {
        InitializeComponent();

        this.mauiControlsService = mauiControlsService;
        BindingContext = vm;
        ViewModel = vm;
    }
    #endregion

    #region [Event]
    private async void OnSearchAsync(object sender, TextChangedEventArgs args)
    {
        ViewModel.ControlGroupList.Clear();

        var items = await mauiControlsService.GetControlsAsync(ViewModel.ControlInformation.GroupName);

        var filtered = items.Where(x => x.ControlName.ToLower().Contains(EventHandlerSearchBar.Text.ToLower(), StringComparison.OrdinalIgnoreCase));

        foreach (var item in filtered)
        {
            ViewModel.ControlGroupList.Add(item);
        }
    }
    #endregion
}