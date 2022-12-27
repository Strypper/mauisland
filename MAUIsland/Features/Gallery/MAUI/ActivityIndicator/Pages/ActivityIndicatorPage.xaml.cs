namespace MAUIsland;

public partial class ActivityIndicatorPage
{
	public ActivityIndicatorPage(ActivityIndicatorPageViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}