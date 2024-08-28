using CommunityToolkit.Mvvm.Messaging;

namespace MAUIsland.Mockup;

public partial class DeviceListPageComponent : ContentView
{

    #region [ CTors ]
    public DeviceListPageComponent()
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

    private void MockupPreviewItemContentView_ScreenShotDeleteClicked(ScreenshotModel payload)
    {
        WeakReferenceMessenger.Default.Send(new DeleteScreenShotMessage(payload));
    }
    #endregion
}