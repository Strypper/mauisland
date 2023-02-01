namespace MAUIsland;

public partial class ImageButtonPage : IControlPage
{
    public ImageButtonPage(ImageButtonPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }

    private void BasePage_SizeChanged(object sender, EventArgs e)
    {
        if (Window.Width < 500)
        {
            rootGrid.SetColumnSpan(DocumentStack, 2);
            SidePanel.IsVisible = false;
            return;
        }
        else if (Window.Width < 900)
        {
            rootGrid.SetColumnSpan(DocumentStack, 2);
            SidePanel.IsVisible = false;
            return;
        }
        else if (Window.Width < 2000)
        {
            rootGrid.SetColumnSpan(DocumentStack, 1);
            SidePanel.IsVisible = true;
            return;
        }
    }
}