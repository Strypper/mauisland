namespace MAUIsland;

public partial class DoubleToIntConverterPage : IGalleryPage
{
	public DoubleToIntConverterPage(DoubleToIntConverterPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}