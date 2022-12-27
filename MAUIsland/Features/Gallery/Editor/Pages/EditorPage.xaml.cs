namespace MAUIsland;

public partial class EditorPage
{
	public EditorPage(EditorPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}