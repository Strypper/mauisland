namespace MAUIsland;

public partial class MenuBarPage : IGalleryPage
{
    public MenuBarPage(MenuBarPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}