namespace MAUIsland;

public partial class ByteArrayToImageSourceConverterPage : IGalleryPage
{
	public ByteArrayToImageSourceConverterPage(ByteArrayToImageSourceConverterPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}