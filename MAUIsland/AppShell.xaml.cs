namespace MAUIsland;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("buttonPage", typeof(ButtonPage));
	}
}
