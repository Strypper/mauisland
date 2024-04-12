namespace MAUIsland;

public partial class ImageButtonPage : IGalleryPage
{
    #region [ Fields ]

    private readonly ImageButtonPageViewModel viewModel;
    #endregion

    #region [ Properties ]

    private bool IsPressed = true;
    #endregion

    #region [ CTor ]
    public ImageButtonPage(ImageButtonPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;

    }
    #endregion

    #region [ Event Handler ]

    private void BasePage_Loaded(object sender, EventArgs e)
    {
        if (NewWindowParameter is not null && viewModel.ControlInformation is null)
        {
            viewModel.SetControlInformation(NewWindowParameter);
            viewModel.RefreshCommand.Execute(null);
        }
    }
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