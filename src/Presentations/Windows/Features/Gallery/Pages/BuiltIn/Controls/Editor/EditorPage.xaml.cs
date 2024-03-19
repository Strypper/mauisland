namespace MAUIsland;

public partial class EditorPage : IGalleryPage
{
	public EditorPage(EditorPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
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

    void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (!int.TryParse(e.NewTextValue, out _))
        {
            ((Entry)sender).Text = e.OldTextValue;
        }
    }
}