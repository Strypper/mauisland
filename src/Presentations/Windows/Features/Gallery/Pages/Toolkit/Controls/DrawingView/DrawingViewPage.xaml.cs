namespace MAUIsland;
public partial class DrawingViewPage : IGalleryPage
{
    #region [ Fields ]

    private readonly DrawingViewPageViewModel viewModel;
    #endregion

    #region [ CTor ]
    public DrawingViewPage(DrawingViewPageViewModel vm)
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