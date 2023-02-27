using Microsoft.Extensions.Configuration;

namespace MAUIsland;
public partial class AppSettingsJsonPage : IControlPage
{
    #region [Services]
    Settings settings;
    #endregion

    #region [CTor]
    public AppSettingsJsonPage(AppSettingsJsonPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;

        settings = ServiceHelper.GetService<IConfiguration>()
                                   .GetRequiredSection("Settings")
                                   .Get<Settings>();
    }
    #endregion

    #region [Event Handlers]
    private async void SettingsButton_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Config", $"{nameof(settings.KeyOne)}: {settings.KeyOne}" +
            $"{nameof(settings.KeyTwo)}: {settings.KeyTwo}" +
            $"{nameof(settings.KeyThree.Message)}: {settings.KeyThree.Message}", "OK");

    }
    #endregion

}