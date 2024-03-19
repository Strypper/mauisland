namespace MAUIsland;
public partial class ObservablePropertyPage : IGalleryPage
{
    #region [CTor]
    public ObservablePropertyPage(ObservablePropertyPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}