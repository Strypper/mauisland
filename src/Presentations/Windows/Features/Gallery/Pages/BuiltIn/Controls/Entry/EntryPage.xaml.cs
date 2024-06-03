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

    private void OnEntryCompleted(System.Object sender, System.EventArgs e)
    {
        string text = ((Entry)sender).Text;
    }
    private void OnEntryTextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = entry.Text;
    }

    #endregion

}