namespace MAUIsland;

public partial class SwipeViewPage : IGalleryPage
{
    #region [ Fields ]

    private readonly SwipeViewPageViewModel viewModel;
    #endregion

    #region [ CTor ]
    public SwipeViewPage(SwipeViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
    }
    #endregion

    #region [ Event Handlers ]

    private void BasePage_Loaded(object sender, EventArgs e)
    {
        if (NewWindowParameter is not null && viewModel.ControlInformation is null)
        {
            viewModel.SetControlInformation(NewWindowParameter);
            viewModel.RefreshCommand.Execute(null);
        }
    }
    #endregion
}