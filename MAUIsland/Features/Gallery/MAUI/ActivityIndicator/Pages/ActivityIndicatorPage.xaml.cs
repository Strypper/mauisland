namespace MAUIsland;

public partial class ActivityIndicatorPage : IControlPage
{
    public ActivityIndicatorPage(ActivityIndicatorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}