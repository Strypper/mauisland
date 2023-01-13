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

    #region [Event Handlers]
    private void BasePage_SizeChanged(object sender, EventArgs e)
    {
        if (Window.Width < 500)
        {
            if (viewModel is not null)
            {
                viewModel.Span = 1;
                return;
            }
        }
        else if (Window.Width < 900)
        {
            if (viewModel is not null)
            {
                viewModel.Span = 2;
                return;
            }
        }
        else if (Window.Width < 2000)
        {
            if (viewModel is not null)
            {
                viewModel.Span = 4;
                return;
            }
        }
    }
    #endregion

    private void ControlCardContentView_DetailClicked(string route)
    {
        viewModel.NavigateToDetailCommand.Execute(route);
    }

    private void ControlCardContentView_DetailInNewWindowClicked(string route)
    {
        viewModel.NavigateToDetailInNewWindowCommand.Execute(route);
    }
}