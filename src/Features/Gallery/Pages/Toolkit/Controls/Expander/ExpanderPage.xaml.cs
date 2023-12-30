namespace MAUIsland;

public partial class ExpanderPage : IGalleryPage
{
	public ExpanderPage(ExpanderPageViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}