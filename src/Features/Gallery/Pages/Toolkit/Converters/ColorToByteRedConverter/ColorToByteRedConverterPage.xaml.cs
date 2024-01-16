namespace MAUIsland;

public partial class ColorToByteRedConverterPage : IGalleryPage
{
	public ColorToByteRedConverterPage(ColorToByteRedConverterPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}