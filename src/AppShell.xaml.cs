namespace MAUIsland;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("bridgeWindowChatPage", typeof(BridgeWindowChatPage));
        Routing.RegisterRoute(nameof(ControlsByGroupPage), typeof(ControlsByGroupPage));
	}
}
