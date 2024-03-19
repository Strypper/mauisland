namespace MAUIsland;

public partial class ImageResourceConverterPage : IGalleryPage
{
	public ImageResourceConverterPage(ImageResourceConverterPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}