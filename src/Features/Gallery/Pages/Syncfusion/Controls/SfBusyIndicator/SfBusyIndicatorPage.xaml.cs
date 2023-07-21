namespace MAUIsland;
public partial class SfBusyIndicatorPage : IGalleryPage
{
    public SfBusyIndicatorPage(SfBusyIndicatorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}