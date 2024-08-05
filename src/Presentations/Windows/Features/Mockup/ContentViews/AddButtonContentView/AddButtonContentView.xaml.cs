namespace MAUIsland.Mockup;

public partial class AddButtonContentView : ContentView
{
    #region [ CTors ]

    public AddButtonContentView()
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

    public delegate void ImageDropEventHandler(Object sender, DropEventArgs e, DroppedImage model);
    public event ImageDropEventHandler ImageDrop;
    #endregion

    #region [ Event Handler ]

    private void DropGestureRecognizer_Drop(System.Object sender, Microsoft.Maui.Controls.DropEventArgs e)
    {
        if (ImageDrop is null)
            return;

        if (this.BindingContext is null)
            return;

        var context = (PreviewImageModel)this.BindingContext;

        DroppedImage eventModel = new()
        {
            Id = context.Id,
            ImageSource = context.ImageSource,
            CollectionViewId = context.CollectionViewId
        };

        ImageDrop.Invoke(sender, e, eventModel);
    }
    #endregion
}