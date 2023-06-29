namespace MAUIsland;
public partial class MaterialTextFieldPage : IControlPage
{
    #region [CTor]
    public MaterialTextFieldPage(MaterialTextFieldPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}