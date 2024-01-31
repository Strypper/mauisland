namespace MAUIsland;

public partial class ImageButtonPage : IGalleryPage
{
    #region [ Field ]
    private bool IsPressed = true;
    #endregion

    #region [ CTor ]
    public ImageButtonPage(ImageButtonPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;

    }
    #endregion

    #region [ Event Handler ]
    private void OnButtonPressed(object sender, EventArgs e)
    {
        var imageButton = sender as ImageButton;
        imageButton.BackgroundColor = Colors.DarkGray;
    }

    private void OnButtonReleased(object sender, EventArgs e)
    {
        var imageButton = sender as ImageButton;
        imageButton.BackgroundColor = Colors.White;
    }

    private void ImageButtonEventHandlerClicked(object sender, EventArgs e)
    {
        if (IsPressed)
        {
            ImageButtonWithEvent.BackgroundColor = Colors.Blue;
            ImageButtonWithEventLabel.TextColor = Colors.White;
            IsPressed = false;
        }
        else
        {
            ImageButtonWithEvent.BackgroundColor = Colors.DarkGray;
            ImageButtonWithEventLabel.TextColor = Colors.Black;
            IsPressed = true;
        }
    }
    #endregion
}