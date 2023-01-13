namespace MAUIsland;

public partial class ImageButtonPage
{
    public ImageButtonPage(EditorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}