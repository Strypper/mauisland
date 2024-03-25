using Microsoft.Extensions.Configuration;

namespace MAUIsland;

public partial class AppShell : Shell
{
    #region [ Fields ]
    private readonly IAppInfo appInfo;

    private readonly AppSettings appSettings;
    #endregion

    #region [ CTor ]
    public AppShell()
    {
        InitializeComponent();

        appInfo = ServiceHelper.GetService<IAppInfo>();
        appSettings = ServiceHelper.GetService<IConfiguration>()
                                   .GetRequiredSection("AppSettings")
                                   .Get<AppSettings>();

        RegisterRoutes();
        WriteAppVersion();
        RegisterSyncfusionLicense();

    }
    #endregion

    #region [ Methods ]
    void RegisterRoutes()
    {
        Routing.RegisterRoute(nameof(CardsByGroupPage), typeof(CardsByGroupPage));
    }
    void WriteAppVersion()
    {
        AppVersionLabel.Text = appInfo.VersionString;
    }

    void RegisterSyncfusionLicense()
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(appSettings.SyncfusionKey);
    }

    void GetCurrentMicrosoftMauiControls()
    {

    }
    #endregion
}
