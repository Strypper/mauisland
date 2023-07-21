namespace MAUIsland;
public partial class MaterialChipPage : IGalleryPage
{
    #region [CTor]
    public MaterialChipPage(MaterialChipPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}