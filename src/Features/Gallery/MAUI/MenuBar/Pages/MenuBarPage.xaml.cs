namespace MAUIsland;

public partial class MenuBarPage
{
    public MenuBarPage(EditorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}