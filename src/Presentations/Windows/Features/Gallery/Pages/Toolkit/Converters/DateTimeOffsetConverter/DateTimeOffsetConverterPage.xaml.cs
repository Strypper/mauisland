namespace MAUIsland;

public partial class DateTimeOffsetConverterPage : IGalleryPage
{
	public DateTimeOffsetConverterPage(DateTimeOffsetConverterPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}