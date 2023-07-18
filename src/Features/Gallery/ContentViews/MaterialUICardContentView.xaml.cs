namespace MAUIsland;

public partial class MaterialUICardContentView : ContentView
{
    #region [ CTor ]

    public MaterialUICardContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [Delegates]
    public delegate void DetailEventHandler(IMaterialUIControlInfo control);

    public delegate void DetailInNewWindowEventHandler(IMaterialUIControlInfo control);
    #endregion

    #region [Event Handlers]
    public event DetailEventHandler DetailClicked;

    public event DetailInNewWindowEventHandler DetailInNewWindowClicked;
    #endregion

    #region [ Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
                    nameof(ComponentData),
                    typeof(IMaterialUIControlInfo),
                    typeof(MaterialUICardContentView),
                    default(IMaterialUIControlInfo)
                );

    public IMaterialUIControlInfo ComponentData
    {
        get => (IMaterialUIControlInfo)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }
    #endregion

    #region [Event Handlers]

    private void Detail_Clicked(object sender, SkiaSharp.Views.Maui.SKTouchEventArgs e)
    {
        DetailClicked?.Invoke(ComponentData);
    }

    private void DetailInNewWindow_Clicked(object sender, EventArgs e)
    {
        DetailInNewWindowClicked?.Invoke(ComponentData);
    }

    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    #endregion
}