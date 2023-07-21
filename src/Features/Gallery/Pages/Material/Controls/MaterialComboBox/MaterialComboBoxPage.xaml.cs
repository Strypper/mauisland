namespace MAUIsland;
public partial class MaterialComboBoxPage : IGalleryPage
{
    #region [CTor]
    public MaterialComboBoxPage(MaterialComboBoxPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}