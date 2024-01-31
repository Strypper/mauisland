namespace MAUIsland;

public partial class ImageButtonPage : IGalleryPage
{
    private bool isPressed = true;
    public ImageButtonPage(ImageButtonPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;

    }

    private void ImageButtonClicked(object sender, EventArgs e)
    {
        var imageButton = sender as ImageButton;
        imageButton.Pressed += (s, e) => imageButton.BackgroundColor = Colors.DarkGray;
        imageButton.Released += (s, e) => imageButton.BackgroundColor = Colors.White;
    }

    private void ImageButtonEventHandlerClicked(object sender, EventArgs e)
    {
        if (isPressed)
        {
            ImageButtonWithEvent.BackgroundColor = Colors.Blue;
            ImageButtonWithEventLabel.TextColor = Colors.White;
            isPressed = false;
        }
        else
        {
            ImageButtonWithEvent.BackgroundColor = Colors.DarkGray;
            ImageButtonWithEventLabel.TextColor = Colors.Black;
            isPressed = true;
        }
    }
}