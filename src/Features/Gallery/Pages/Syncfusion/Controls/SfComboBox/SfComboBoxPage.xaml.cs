namespace MAUIsland;

public partial class SfComboBoxPage : IGalleryPage
{
    #region [CTor]
    public SfComboBoxPage(SfComboBoxPageViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}

    #endregion
}