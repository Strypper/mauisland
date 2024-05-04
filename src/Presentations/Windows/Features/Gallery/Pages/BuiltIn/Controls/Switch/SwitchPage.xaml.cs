namespace MAUIsland;

public partial class SwitchPage : IGalleryPage
{
    #region [ Fields ]

    private readonly SwitchPageViewModel viewModel;
    #endregion

    #region [ CTor ]

    public SwitchPage(SwitchPageViewModel vm)
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