namespace MAUIsland;

public partial class MenuBarPage : IControlPage
{
    public MenuBarPage(EditorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}