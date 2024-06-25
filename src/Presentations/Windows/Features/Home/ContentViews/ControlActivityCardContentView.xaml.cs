namespace MAUIsland.Home;

public partial class ControlActivityCardContentView : ContentView
{
    #region [ CTor ]
    public ControlActivityCardContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ApplicationNewProperty = BindableProperty.Create(
            nameof(ApplicationNew),
            typeof(ApplicationNew),
            typeof(RoundedEntry),
            default(ApplicationNew)
    );
    #endregion

    #region [ Properties ]
    public ApplicationNew ApplicationNew
    {
        get => (ApplicationNew)GetValue(ApplicationNewProperty);
        set => SetValue(ApplicationNewProperty, value);
    }
    #endregion

    private async void Detail_Clicked(object sender, EventArgs e)
    {
        var appNavigator = ServiceHelper.GetService<IAppNavigator>();
        if (ApplicationNew.Arg is null)
            await appNavigator.NavigateAsync(ApplicationNew.NewsRoute);
        else
            await appNavigator.NavigateAsync(ApplicationNew.NewsRoute, args: ApplicationNew.Arg);
    }
}