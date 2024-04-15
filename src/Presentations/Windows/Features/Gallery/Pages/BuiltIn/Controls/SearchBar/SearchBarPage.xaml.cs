namespace MAUIsland;

public partial class SearchBarPage : IGalleryPage
{
    #region [ Fields ]

    private readonly IControlsService mauiControlsService;
    #endregion

    #region[ View Model ]
    protected SearchBarPageViewModel viewModel { get; set; }
    #endregion

    #region [ CTor ]
    public SearchBarPage(SearchBarPageViewModel vm,
                         IControlsService mauiControlsService)
    {
        InitializeComponent();

        this.mauiControlsService = mauiControlsService;
        BindingContext = viewModel = vm;
    }
    #endregion

    #region [ Event Handler ]

    private void BasePage_Loaded(object sender, EventArgs e)
    {
        if (NewWindowParameter is not null && viewModel.ControlInformation is null)
        {
            viewModel.SetControlInformation(NewWindowParameter);
            viewModel.RefreshCommand.Execute(null);
        }
    }

    private async void OnSearchAsync(object sender, TextChangedEventArgs args)
    {
        viewModel.ControlGroupListForEventCall.Clear();

        var items = await mauiControlsService.GetControlsAsync(viewModel.ControlInformation.GroupName);

        var filtered = items.Where(x => x.ControlName.ToLower().Contains(EventHandlerSearchBar.Text.ToLower(), StringComparison.OrdinalIgnoreCase));

        foreach (var item in filtered)
        {
            viewModel.ControlGroupListForEventCall.Add(item);
        }
    }
    #endregion
}