namespace MAUIsland;

public partial class ColorToCmykStringConverterPage : IGalleryPage
{
	public ColorToCmykStringConverterPage(ColorToCmykStringConverterPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}