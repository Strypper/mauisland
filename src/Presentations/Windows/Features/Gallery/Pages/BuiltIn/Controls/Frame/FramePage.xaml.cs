namespace MAUIsland;
public partial class FramePage : IGalleryPage
{
    public FramePage(FramePageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}