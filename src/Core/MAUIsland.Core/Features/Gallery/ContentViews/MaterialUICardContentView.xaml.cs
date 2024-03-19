namespace MAUIsland.Core;

public partial class MaterialUICardContentView : ContentView
{
    #region [ CTor ]

    public MaterialUICardContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Delegates ]
    public delegate void DetailEventHandler(IMaterialUIGalleryCardInfo control);

    public delegate void DetailInNewWindowEventHandler(IMaterialUIGalleryCardInfo control);
    #endregion

    #region [ Event Handlers ]
    public event DetailEventHandler DetailClicked;

    public event DetailInNewWindowEventHandler DetailInNewWindowClicked;
    #endregion

    #region [ Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
                    nameof(ComponentData),
                    typeof(IMaterialUIGalleryCardInfo),
                    typeof(MaterialUICardContentView),
                    default(IMaterialUIGalleryCardInfo)
                );

    public IMaterialUIGalleryCardInfo ComponentData
    {
        get => (IMaterialUIGalleryCardInfo)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }
    #endregion

    #region [ Event Handlers ]

    private void Detail_Clicked(object sender, TouchEventArgs e)
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