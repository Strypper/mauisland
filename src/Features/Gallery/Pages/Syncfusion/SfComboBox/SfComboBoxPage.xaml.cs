namespace MAUIsland;

public partial class SfComboBoxPage : IControlPage
{
    #region [CTor]
    public SfComboBoxPage(SfComboBoxPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}

    #endregion
}