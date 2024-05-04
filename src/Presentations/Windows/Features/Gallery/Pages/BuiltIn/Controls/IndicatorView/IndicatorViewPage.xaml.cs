namespace MAUIsland;

public partial class IndicatorViewPage : IGalleryPage
{
    #region [ Fields ]

    private readonly IndicatorViewPageViewModel viewModel;
    #endregion

    #region [ CTor ]
    public IndicatorViewPage(IndicatorViewPageViewModel vm)
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