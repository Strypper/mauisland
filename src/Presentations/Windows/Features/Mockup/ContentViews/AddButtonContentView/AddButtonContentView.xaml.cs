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
        this.BindingContext = (MockupPreviewItemModel)BindingContext;
    }
    #endregion

    #region [ Delegates ]

    public delegate void ImageDropEventHandler(Object sender, DropEventArgs e, AddButtonEventModel model);
    public event ImageDropEventHandler ImageDrop;
    #endregion

    #region [ Event Handler ]

    private void DropGestureRecognizer_Drop(System.Object sender, Microsoft.Maui.Controls.DropEventArgs e)
    {
        if (ImageDrop is null)
            return;

        if (this.BindingContext is null)
            return;

        var context = (MockupPreviewItemModel)this.BindingContext;

        AddButtonEventModel eventModel = new()
        {
            Id = context.Id,
            ImageSource = context.ImageSource,
            IsAddButton = context.IsAddButton,
        };

        ImageDrop.Invoke(sender, e, eventModel);
    }
    #endregion
}