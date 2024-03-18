namespace MAUIsland;
partial class GalleryPage
{
    #region [ Fields ]
    private readonly GalleryPageViewModel viewModel;
    #endregion

    #region [ CTor ]
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
    private void BrandIconContentView_DetailInNewWindowClicked(ControlGroupInfo control)
    {
        this.viewModel.ViewControlsInNewWindowCommand.Execute(control);
    }
    private void NavigateToBuiltIn_Clicked(object sender, EventArgs e)
    {
        var controlInfo = this.viewModel.ControlGroups.FirstOrDefault(x => x.Title == "Built-in");
        this.viewModel.ViewControlsCommand.Execute(controlInfo);
    }
    #endregion

}