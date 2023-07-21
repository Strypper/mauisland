namespace MAUIsland;

public partial class GithubCardContentView : ContentView
{
    #region [CTor]
    public GithubCardContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [Delegates]
    public delegate void DetailEventHandler(IGithubGalleryCardInfo control);

    public delegate void DetailInNewWindowEventHandler(IGithubGalleryCardInfo control);
    #endregion

    #region [ Events ]
    public event DetailEventHandler DetailClicked;

    public event DetailInNewWindowEventHandler DetailInNewWindowClicked;
    #endregion

    #region [Bindable Properties]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(IGithubGalleryCardInfo),
        typeof(GithubCardContentView),
        default(IGithubGalleryCardInfo)
    );

    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    #endregion

    #region [Properties]
    public IGithubGalleryCardInfo ComponentData
    {
        get => (IGithubGalleryCardInfo)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }
    #endregion

    #region [Event Handlers]
    private void Detail_Clicked(object sender, EventArgs e)
    {
        DetailClicked?.Invoke(ComponentData);
    }

    private void DetailInNewWindow_Clicked(object sender, EventArgs e)
    {
        DetailInNewWindowClicked?.Invoke(ComponentData);
    }
    #endregion
}