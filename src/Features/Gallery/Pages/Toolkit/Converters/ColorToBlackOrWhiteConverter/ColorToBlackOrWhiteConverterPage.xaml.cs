namespace MAUIsland;

public partial class ColorToBlackOrWhiteConverterPage : IGalleryPage
{
	public ColorToBlackOrWhiteConverterPage(ColorToBlackOrWhiteConverterPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}