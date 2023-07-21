namespace MAUIsland;

public partial class ActivityIndicatorPage : IGalleryPage
{
    public ActivityIndicatorPage(ActivityIndicatorPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}