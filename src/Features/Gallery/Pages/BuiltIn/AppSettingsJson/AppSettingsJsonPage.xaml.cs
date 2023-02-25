namespace MAUIsland;
public partial class AppSettingsJsonPage : IControlPage
{
    #region [CTor]
    public AppSettingsJsonPage(AppSettingsJsonPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}