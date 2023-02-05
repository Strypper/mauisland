namespace MAUIsland;

public partial class GalleryPage
{
    #region [Services]
    private readonly GalleryPageViewModel viewModel;
    #endregion

    #region [CTor]
    public GalleryPage(GalleryPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
    }
    #endregion


    #region [Event Handlers]
    private void BrandIconContentView_DetailClicked(ControlGroupInfo control)
    {
        this.viewModel.ViewControlsCommand.Execute(control);
    }
    #endregion
}