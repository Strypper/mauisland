namespace MAUIsland;
public partial class MaterialFABPage : IGalleryPage
{
    #region [CTor]
    public MaterialFABPage(MaterialFABPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}