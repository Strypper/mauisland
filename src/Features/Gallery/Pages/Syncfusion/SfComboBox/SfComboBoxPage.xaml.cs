namespace MAUIsland;

public partial class SfComboBoxPage : IControlPage
{
    #region [CTor]
    public SfComboBoxPage(SfCartesianChartPageViewModel vm)
	{
		IntializeComponent();

		BindingContext = vm;
	}
    #endregion
}