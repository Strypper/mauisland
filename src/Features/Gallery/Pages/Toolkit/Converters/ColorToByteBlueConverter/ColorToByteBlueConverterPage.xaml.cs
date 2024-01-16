namespace MAUIsland;

public partial class ColorToByteBlueConverterPage : IGalleryPage
{
	public ColorToByteBlueConverterPage(ColorToByteBlueConverterPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}