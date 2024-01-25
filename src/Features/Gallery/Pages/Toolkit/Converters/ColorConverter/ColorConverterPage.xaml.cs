namespace MAUIsland;

public partial class ColorConverterPage : IGalleryPage
{
	public ColorConverterPage(ColorConverterPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}