namespace MAUIsland;

public partial class EditorPage : IGalleryPage
{
    #region [ Fields ]

    private readonly EditorPageViewModel viewModel;
    #endregion

    #region [ CTor ]

    public EditorPage(EditorPageViewModel vm)
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

    void OnEditorGetTextLength(object sender, TextChangedEventArgs e)
    {
        Editor2TextLenghtLabelSpan.Text = e.NewTextValue.Length.ToString();
    }

    void OnEditorTextChanged(object sender, TextChangedEventArgs e)
    {
        OldTextSpan.Text = e.OldTextValue;
        NewTextSpan.Text = e.NewTextValue;
    }

    void OnEditorCompleted(object sender, EventArgs e)
    {
        string text = ((Editor)sender).Text;
    }
    #endregion
}