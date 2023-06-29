namespace MAUIsland;
public partial class MaterialContextMenuPage : IControlPage
{
    #region [CTor]
    public MaterialContextMenuPage(MaterialContextMenuPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}