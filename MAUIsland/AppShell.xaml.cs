namespace MAUIsland;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("galleryPage", typeof(GalleryPage));
		Routing.RegisterRoute("mauiAllControlsPage", typeof(MAUIAllControlsPage));

		Routing.RegisterRoute("buttonPage", typeof(ButtonPage));
		Routing.RegisterRoute("activityIndicatorPage", typeof(ActivityIndicatorPage));
		Routing.RegisterRoute("editorPage", typeof(EditorPage));
		Routing.RegisterRoute("menuBarPage", typeof(MenuBarPage));
	}
}
