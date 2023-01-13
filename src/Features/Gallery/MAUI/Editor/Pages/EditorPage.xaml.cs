namespace MAUIsland;

public partial class EditorPage
{
	public EditorPage(EditorPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}

    void OnEditorTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = editor.Text;
    }

    void OnEditorCompleted(object sender, EventArgs e)
    {
        string text = ((Editor)sender).Text;
    }
}