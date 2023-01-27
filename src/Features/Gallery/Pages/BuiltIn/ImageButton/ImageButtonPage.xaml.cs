namespace MAUIsland;

public partial class ImageButtonPage : IControlPage
{
    public ImageButtonPage(ImageButtonPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}