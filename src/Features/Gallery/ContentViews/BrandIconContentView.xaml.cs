namespace MAUIsland;
using System.Windows.Input;

public partial class BrandIconContentView : ContentView
{

    #region [CTor]
    public BrandIconContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [Delegates]
    public delegate void DetailEventHandler(ControlGroupInfo control);

    public delegate void DetailInNewWindowEventHandler(ControlGroupInfo control);
    #endregion

    #region [Events]
    public event DetailEventHandler DetailClicked;

    public event DetailInNewWindowEventHandler DetailInNewWindowClicked;
    #endregion

    #region [Bindable Properties]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(ControlGroupInfo),
        typeof(BrandIconContentView),
        default(ControlGroupInfo)
    );

    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    #endregion

    #region [Properties]
    public ControlGroupInfo ComponentData
    {
        get => (ControlGroupInfo)GetValue(ComponentDataProperty);
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

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        DetailClicked?.Invoke(ComponentData);
    }

    private void MenuFlyoutItem_Clicked(object sender, EventArgs e)
    {
        DetailInNewWindowClicked?.Invoke(ComponentData);
    }
    #endregion
}