using MAUIsland.Settings;

namespace MAUIsland;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        SettingsPageViewModel settingsPageViewModel = ServiceHelper.GetService<SettingsPageViewModel>(); 
        return new MAUIslandWindow(settingsPageViewModel);
    }
}
