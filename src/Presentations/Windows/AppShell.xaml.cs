using MAUIsland.Mockup;
using MAUIsland.ResumesTemplate;
using MAUIsland.Settings;
using MAUIsland.Showcases;
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
        appSettings = ServiceHelper.GetService<AppSettings>();

        RegisterRoutes();
        WriteAppVersion();
        RegisterSyncfusionLicense();

    }
    #endregion

    #region [ Methods ]
    void RegisterRoutes()
    {
        Routing.RegisterRoute(AppRoutes.MockupPage, typeof(MockupPage));
        Routing.RegisterRoute(AppRoutes.ResumesPage, typeof(ResumesPage));
        Routing.RegisterRoute(AppRoutes.SettingsPage, typeof(SettingsPage));
        Routing.RegisterRoute(AppRoutes.ResumeDetailPage, typeof(ResumeDetailPage));
        Routing.RegisterRoute(AppRoutes.CardsByGroupPage, typeof(CardsByGroupPage));
        Routing.RegisterRoute(AppRoutes.ShowcasesPage, typeof(ShowcasesPage));
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
