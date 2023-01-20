namespace MAUIsland;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ControlsByGroupPage), typeof(ControlsByGroupPage));
	}
}
