namespace MAUIsland;
public partial class MaterialChipPage : IControlPage
{
    #region [CTor]
    public MaterialChipPage(MaterialChipPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}