namespace MAUIsland;

public partial class ButtonPage : IGalleryPage
{
    public ButtonPage(ButtonPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}