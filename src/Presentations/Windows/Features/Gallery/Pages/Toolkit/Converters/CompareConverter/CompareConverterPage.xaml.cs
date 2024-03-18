namespace MAUIsland;

public partial class CompareConverterPage : IGalleryPage
{
	public CompareConverterPage(CompareConverterPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}