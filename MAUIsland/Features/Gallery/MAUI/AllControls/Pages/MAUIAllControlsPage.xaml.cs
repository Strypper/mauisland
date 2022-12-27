namespace MAUIsland;

public partial class MAUIAllControlsPage
{
    #region [Fields]
    private MAUIAllControlsPageViewModel viewModel;
    #endregion

    #region [CTor]
    public MAUIAllControlsPage(MAUIAllControlsPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
    }
    #endregion

    private void ControlCardContentView_DetailClicked(string route)
    {
        viewModel.NavigateToDetailCommand.Execute(route);
    }
}