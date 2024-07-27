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
        this.BindingContext = (MockupPreviewItemModel)BindingContext;
    }
    #endregion
}