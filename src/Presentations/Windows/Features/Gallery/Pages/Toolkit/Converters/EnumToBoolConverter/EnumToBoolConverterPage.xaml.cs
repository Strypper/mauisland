namespace MAUIsland;

public partial class EnumToBoolConverterPage : IGalleryPage
{

    #region [ Fields ]

    private readonly EnumToBoolConverterPageViewModel viewModel;
    #endregion

    #region [ Ctor ]


    public EnumToBoolConverterPage(EnumToBoolConverterPageViewModel vm)
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