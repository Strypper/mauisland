namespace MAUIsland;

public partial class ButtonPage
{
    public ButtonPage(ButtonPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}