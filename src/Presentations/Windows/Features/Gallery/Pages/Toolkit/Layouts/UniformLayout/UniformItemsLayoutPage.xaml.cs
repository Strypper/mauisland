namespace MAUIsland;

public partial class UniformItemsLayoutPage : IGalleryPage
{
    #region [CTor]
    public UniformItemsLayoutPage(UniformItemsLayoutPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}