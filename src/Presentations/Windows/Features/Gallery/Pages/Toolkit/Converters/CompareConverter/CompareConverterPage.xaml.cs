namespace MAUIsland;

public partial class CompareConverterPage : IGalleryPage
{

    #region [ Fields ]

    private readonly CompareConverterPageViewModel viewModel;
    #endregion

    #region [ CTor ]

    public CompareConverterPage(CompareConverterPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
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