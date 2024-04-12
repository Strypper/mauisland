namespace MAUIsland;

public partial class EntryPage : IGalleryPage
{
    #region [ Fields ]

    private readonly EntryPageViewModel viewModel;
    #endregion

    #region [ CTor ]

    public EntryPage(EntryPageViewModel vm)
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

    private void Entry_Completed(object sender, EventArgs e)
    {

    }

    #endregion
}