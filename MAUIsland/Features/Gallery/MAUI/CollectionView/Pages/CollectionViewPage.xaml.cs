namespace MAUIsland;



public partial class CollectionViewPage
{

    #region [CTor]
    public CollectionViewPage(CollectionViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

}