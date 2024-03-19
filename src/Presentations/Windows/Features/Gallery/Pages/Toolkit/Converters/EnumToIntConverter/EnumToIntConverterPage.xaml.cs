namespace MAUIsland;

public partial class EnumToIntConverterPage : IGalleryPage
{
	public EnumToIntConverterPage(EnumToIntConverterPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}