namespace MAUIsland;
public partial class StackLayoutPage : IGalleryPage
{
    #region [ Fields ]

    private readonly StackLayoutPageViewModel viewModel;
    #endregion

    #region [ CTor ]
    public StackLayoutPage(StackLayoutPageViewModel vm)
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