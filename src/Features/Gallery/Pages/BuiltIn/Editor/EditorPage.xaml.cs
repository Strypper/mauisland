namespace MAUIsland;

public partial class EditorPage : IControlPage
{
	public EditorPage(EditorPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
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
}