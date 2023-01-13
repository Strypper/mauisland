namespace MAUIsland;

public partial class ButtonPage : IControlPage
{
    public ButtonPage(ButtonPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}