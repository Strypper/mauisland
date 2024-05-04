namespace MAUIsland;
public partial class MaterialButtonPage : IGalleryPage
{
    #region [ CTor ]
    public MaterialButtonPage(MaterialButtonPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}