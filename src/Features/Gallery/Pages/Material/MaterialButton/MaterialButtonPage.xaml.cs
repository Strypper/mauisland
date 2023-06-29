namespace MAUIsland;
public partial class MaterialButtonPage : IControlPage
{
    #region [CTor]
    public MaterialButtonPage(MaterialButtonPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}