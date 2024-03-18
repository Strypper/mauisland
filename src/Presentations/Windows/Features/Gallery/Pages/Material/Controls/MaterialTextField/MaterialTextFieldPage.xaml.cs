namespace MAUIsland;
public partial class MaterialTextFieldPage : IGalleryPage
{
    #region [CTor]
    public MaterialTextFieldPage(MaterialTextFieldPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}