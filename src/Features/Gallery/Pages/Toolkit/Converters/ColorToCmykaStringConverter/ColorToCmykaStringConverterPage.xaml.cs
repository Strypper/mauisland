namespace MAUIsland;

public partial class ColorToCmykaStringConverterPage : IGalleryPage
{
	public ColorToCmykaStringConverterPage(ColorToCmykaStringConverterPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}