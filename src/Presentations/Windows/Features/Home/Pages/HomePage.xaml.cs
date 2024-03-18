namespace MAUIsland;
public partial class HomePage
{
    public HomePage(HomePageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }

    private void ResizeWindows()
    {

        if (Window is not null)
        {
            Window.Width = 1075.199951171875;
            Window.Height = 656.7999877929688;
        }
    }

    private void BasePage_SizeChanged(object sender, EventArgs e)
    {
    }

    private void BasePage_Appearing(object sender, EventArgs e)
    {
#if WINDOWS
            ResizeWindows();
#else
#endif
    }
}