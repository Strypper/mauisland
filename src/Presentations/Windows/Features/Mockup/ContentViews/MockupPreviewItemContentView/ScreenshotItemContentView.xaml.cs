namespace MAUIsland.Mockup;

public partial class ScreenshotItemContentView : ContentView
{

    #region [ CTor ]

    public ScreenshotItemContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Overrides ]

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        this.BindingContext = (ScreenshotModel)BindingContext;
    }
    #endregion

    #region [ Delegates ]

    public delegate void ScreenShotDeleteEventHandler(ScreenshotModel payload);
    public event ScreenShotDeleteEventHandler ScreenShotDeleteClicked;
    #endregion

    #region [ Event Handlers ]

    private void DeleteButton_Clicked(System.Object sender, System.EventArgs e)
    {
        if (ScreenShotDeleteClicked is null)
            return;

        var context = (ScreenshotModel)this.BindingContext;

        ScreenShotDeleteClicked.Invoke(context);
    }
    #endregion
}