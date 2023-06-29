namespace MAUIsland;
public partial class MaterialComboBoxPage : IControlPage
{
    #region [CTor]
    public MaterialComboBoxPage(MaterialComboBoxPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}