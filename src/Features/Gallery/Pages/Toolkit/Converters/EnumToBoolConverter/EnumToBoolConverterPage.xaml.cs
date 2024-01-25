namespace MAUIsland;

public partial class EnumToBoolConverterPage : IGalleryPage
{
	public EnumToBoolConverterPage(EnumToBoolConverterPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}