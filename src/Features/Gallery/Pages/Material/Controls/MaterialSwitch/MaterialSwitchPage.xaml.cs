namespace MAUIsland;
public partial class MaterialSwitchPage : IGalleryPage
{
    #region [CTor]
    public MaterialSwitchPage(MaterialSwitchPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}