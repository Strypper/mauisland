using CommunityToolkit.Mvvm.Messaging;

namespace MAUIsland.Mockup;

public partial class MockupScreenShotsContentView : ContentView
{

    #region [ CTors ]
    public MockupScreenShotsContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Overrides ]

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        this.BindingContext = (MockupPageViewModel)BindingContext;
    }
    #endregion

    #region [ Event Handlers ]

    private void AddButton_ImageDropped(Object sender, DropEventArgs e, DroppedImage model)
    {
        WeakReferenceMessenger.Default.Send(new DropImageMessage(new()
        {
            Sender = sender,
            Args = e,
            CollectionViewId = model.CollectionViewId
        }));
    }

    private void MockupPreviewItemContentView_ScreenShotDeleteClicked(PreviewImageModel payload)
    {
        WeakReferenceMessenger.Default.Send(new DeleteScreenShotMessage(payload));
    }
    #endregion
}