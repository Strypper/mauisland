namespace MAUIsland;
public partial class FramePage : IControlPage
{
    public FramePage(FramePageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}