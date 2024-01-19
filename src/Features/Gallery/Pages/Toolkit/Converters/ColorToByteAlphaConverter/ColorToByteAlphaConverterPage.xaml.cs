namespace MAUIsland;

public partial class ColorToByteAlphaConverterPage : IGalleryPage
{
	public ColorToByteAlphaConverterPage(ColorToByteAlphaConverterPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}