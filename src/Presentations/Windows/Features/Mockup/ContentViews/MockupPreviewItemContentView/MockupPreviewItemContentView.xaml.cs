namespace MAUIsland.Mockup;

public partial class MockupPreviewItemContentView : ContentView
{

    #region [ CTor ]

    public MockupPreviewItemContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Overrides ]

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        this.BindingContext = (PreviewImageModel)BindingContext;
    }
    #endregion

    #region [ Delegates ]

    public delegate void ScreenShotDeleteEventHandler(PreviewImageModel payload);
    public event ScreenShotDeleteEventHandler ScreenShotDeleteClicked;
    #endregion

    #region [ Event Handlers ]

    private void DeleteButton_Clicked(System.Object sender, System.EventArgs e)
    {
        if (ScreenShotDeleteClicked is null)
            return;

        var context = (PreviewImageModel)this.BindingContext;

        ScreenShotDeleteClicked.Invoke(context);
    }
    #endregion
}