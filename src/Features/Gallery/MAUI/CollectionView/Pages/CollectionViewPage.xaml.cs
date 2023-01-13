namespace MAUIsland;

public partial class CollectionViewPage : IControlPage
{

    #region [CTor]
    public CollectionViewPage(CollectionViewPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

}