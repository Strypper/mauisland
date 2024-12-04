namespace MAUIsland;

public partial class SyncfusionCardContentView : ContentView
{
    #region [CTor]
    public SyncfusionCardContentView()
    {
        InitializeComponent();

        this.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(ComponentData))
            {
                UpdateIsFreeControl();
            }
        };
    }
    #endregion

    #region [Delegates]
    public delegate void DetailEventHandler(IGalleryCardInfo control);

    public delegate void DetailInNewWindowEventHandler(IGalleryCardInfo control);
    #endregion

    #region [Event Handlers]
    public event DetailEventHandler DetailClicked;

    public event DetailInNewWindowEventHandler DetailInNewWindowClicked;
    #endregion

    #region [Bindable Properties]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(IGalleryCardInfo),
        typeof(ControlCardContentView),
        default(IGalleryCardInfo)
    );

    public static readonly BindableProperty IsFreeControlProperty = BindableProperty.Create(
        nameof(IsFreeControl),
        typeof(bool),
        typeof(SyncfusionCardContentView),
        false);

    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    #endregion

    #region [Properties]
    public IGalleryCardInfo ComponentData
    {
        get => (IGalleryCardInfo)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }

    public bool IsFreeControl
    {
        get => (bool)GetValue(IsFreeControlProperty);
        set => SetValue(IsFreeControlProperty, value);
    }

    public List<string> FreeControls { get; } = new List<string> 
    { 
        "SfDataGrid", 
        "SfCartesianChart", 
        "SfCircularChart", 
        "SfFunnelChart", 
        "SfPyramidChart", 
        "SfPolarChart", 
        "SfRadialGauge", 
        "SfLinearGauge", 
        "SfDigitalGauge", 
        "SfMap", 
        "SfTreeMap", 
        "SfListView", 
        "SfPopup", 
        "SfTextInputLayout" 
    };
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

    #region [ Methods ]
    private void UpdateIsFreeControl()
    {
        if (ComponentData != null)
        {
            IsFreeControl = FreeControls?.Contains(ComponentData.ControlName) ?? true;
        }
        else
        {
            IsFreeControl = false;
        }
    }
    #endregion
}