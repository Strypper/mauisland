namespace MAUIsland;
public partial class MaterialRadioButtonPage : IGalleryPage
{
    #region [CTor]
    public MaterialRadioButtonPage(MaterialRadioButtonPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}