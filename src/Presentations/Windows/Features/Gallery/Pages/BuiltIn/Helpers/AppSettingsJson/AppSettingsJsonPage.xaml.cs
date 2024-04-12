using Microsoft.Extensions.Configuration;

namespace MAUIsland;
public partial class AppSettingsJsonPage : IGalleryPage
{
    #region [ Fields ]

    private readonly AppSettingsJsonPageViewModel viewModel;
    #endregion

    #region [ Properties ]

    Settings settings;
    #endregion

    #region [ CTor ]
    public AppSettingsJsonPage(AppSettingsJsonPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;

        settings = ServiceHelper.GetService<IConfiguration>()
                                   .GetRequiredSection("Settings")
                                   .Get<Settings>();
    }
    #endregion

    #region [ Event Handlers ]

    private void BasePage_Loaded(object sender, EventArgs e)
    {
        if (NewWindowParameter is not null && viewModel.ControlInformation is null)
        {
            viewModel.SetControlInformation(NewWindowParameter);
            viewModel.RefreshCommand.Execute(null);
        }
    }

    private async void SettingsButton_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Config", $"{nameof(settings.KeyOne)}: {settings.KeyOne}" +
            $"{nameof(settings.KeyTwo)}: {settings.KeyTwo}" +
            $"{nameof(settings.KeyThree.Message)}: {settings.KeyThree.Message}", "OK");

    }
    #endregion

}