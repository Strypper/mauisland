namespace MAUIsland;

public partial class MenuBarPage : IGalleryPage
{
    public MenuBarPage(EditorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}