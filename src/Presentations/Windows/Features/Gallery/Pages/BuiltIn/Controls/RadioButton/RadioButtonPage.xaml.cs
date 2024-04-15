namespace MAUIsland;

public partial class RadioButtonPage : IGalleryPage
{
    #region [ Fields ]

    private readonly RadioButtonPageViewModel viewModel;
    #endregion

    #region [ CTor ]
    public RadioButtonPage(RadioButtonPageViewModel vm)
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