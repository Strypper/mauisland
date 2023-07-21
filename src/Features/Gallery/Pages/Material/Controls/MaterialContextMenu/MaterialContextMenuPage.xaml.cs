namespace MAUIsland;
public partial class MaterialContextMenuPage : IGalleryPage
{
    #region [CTor]
    public MaterialContextMenuPage(MaterialContextMenuPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}