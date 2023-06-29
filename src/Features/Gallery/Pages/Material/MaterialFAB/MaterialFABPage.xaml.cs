namespace MAUIsland;
public partial class MaterialFABPage : IControlPage
{
    #region [CTor]
    public MaterialFABPage(MaterialFABPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}