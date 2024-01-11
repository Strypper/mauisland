namespace MAUIsland;

public partial class BoolToObjectConverterPage : IGalleryPage
{
	public BoolToObjectConverterPage(BoolToObjectConverterPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;

    }
}