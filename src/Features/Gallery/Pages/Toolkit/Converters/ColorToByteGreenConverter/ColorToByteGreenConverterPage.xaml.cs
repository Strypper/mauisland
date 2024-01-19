namespace MAUIsland;

public partial class ColorToByteGreenConverterPage : IGalleryPage
{
	public ColorToByteGreenConverterPage(ColorToByteGreenConverterPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}