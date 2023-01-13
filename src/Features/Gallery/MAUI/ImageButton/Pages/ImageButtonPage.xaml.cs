namespace MAUIsland;

public partial class ImageButtonPage : IControlPage
{
    public ImageButtonPage(EditorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}