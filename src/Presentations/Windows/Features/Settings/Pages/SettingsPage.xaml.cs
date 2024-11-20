namespace MAUIsland.Settings;

public partial class SettingsPage
{
    public SettingsPage(SettingsPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;

        //vm.TitleBar = Window.TitleBar as TitleBar;
    }
}