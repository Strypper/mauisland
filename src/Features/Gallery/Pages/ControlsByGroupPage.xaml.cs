namespace MAUIsland;

public partial class ControlsByGroupPage
{
    #region [ Fields ]
    private ControlsByGroupPageViewModel viewModel;
    #endregion

    #region [ CTor ]
    public ControlsByGroupPage(ControlsByGroupPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
    }
    #endregion

    #region [ Event Handlers ]
    private void BasePage_SizeChanged(object sender, EventArgs e)
    {
        if (viewModel is not null)
        {
            if (Window.Width < 500)
            {
                viewModel.IsGalleryDetailVisible = false;
                return;
            }
            else if (Window.Width < 900)
            {
                viewModel.IsGalleryDetailVisible = false;
                return;
            }
            else if (Window.Width < 2000)
            {
                viewModel.IsGalleryDetailVisible = true;
                return;
            }

            if (Window is not null)
            {
                System.Diagnostics.Debug.WriteLine(this.Window.Width);
                System.Diagnostics.Debug.WriteLine(this.Window.Height);
            }
        }
    }

    private void ControlCardContentView_DetailClicked(IControlInfo control)
        => viewModel.NavigateToDetailCommand.Execute(control);

    private void ControlCardContentView_DetailInNewWindowClicked(IControlInfo control)
        => viewModel.NavigateToDetailInNewWindowCommand.Execute(control);

    private void CardsSearchHandler_SelectCard(IControlInfo control)
        => viewModel.NavigateToDetailCommand.Execute(control);
    #endregion
}