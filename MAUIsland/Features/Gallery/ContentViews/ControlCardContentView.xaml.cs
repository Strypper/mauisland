namespace MAUIsland;

public partial class ControlCardContentView : ContentView
{

    #region [CTor]
    public ControlCardContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [Delegates]
    public delegate void DetailEventHandler(string route);
    #endregion

    #region [Event Handlers]
    public event DetailEventHandler DetailClicked;
    #endregion

    #region [Bindable Properties]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(nameof(ComponentData),
                                                                                            typeof(ControlInfo),
                                                                                            typeof(ControlCardContentView),
                                                                                            default(ControlInfo)
                                                                                            );
    #endregion

    #region [Properties]
    public ControlInfo ComponentData
    {
        get => (ControlInfo)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }
    #endregion

    private void Detail_Clicked(object sender, EventArgs e)
    {
        DetailClicked?.Invoke(ComponentData.ControlRoute);
    }
}