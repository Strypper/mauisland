namespace MAUIsland;
public partial class MaterialSwitchPage : IControlPage
{
    #region [CTor]
    public MaterialSwitchPage(MaterialSwitchPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}