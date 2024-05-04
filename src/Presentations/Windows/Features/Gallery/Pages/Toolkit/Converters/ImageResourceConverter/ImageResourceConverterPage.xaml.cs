namespace MAUIsland;

public partial class ImageResourceConverterPage : IGalleryPage
{

    #region [ Fields ]

    private readonly ImageResourceConverterPageViewModel viewModel;
    #endregion

    #region [ CTor ]
    public ImageResourceConverterPage(ImageResourceConverterPageViewModel vm)
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