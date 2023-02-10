namespace MAUIsland;
public partial class SfBusyIndicatorPage : IControlPage
{
    public SfBusyIndicatorPage(SfBusyIndicatorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}