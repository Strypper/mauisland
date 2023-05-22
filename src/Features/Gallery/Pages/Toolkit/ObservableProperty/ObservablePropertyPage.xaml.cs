namespace MAUIsland;
public partial class ObservablePropertyPage : IControlPage
{
    #region [CTor]
    public ObservablePropertyPage(ObservablePropertyPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}