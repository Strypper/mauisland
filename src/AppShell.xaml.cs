namespace MAUIsland;

public partial class AppShell : Shell
{
    #region [Services]
    private readonly IAppInfo appInfo;
    #endregion

    #region [CTor]
    public AppShell()
    {
        InitializeComponent();

        appInfo = ServiceHelper.GetService<IAppInfo>();

        Routing.RegisterRoute(nameof(ControlsByGroupPage), typeof(ControlsByGroupPage));

        AppVersionLabel.Text = appInfo.VersionString;
    }
    #endregion
}
