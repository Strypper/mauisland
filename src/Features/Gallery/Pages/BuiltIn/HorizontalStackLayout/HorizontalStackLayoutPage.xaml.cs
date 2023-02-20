namespace MAUIsland;
public partial class HorizontalStackLayoutPage : IControlPage
{
    #region [CTor]
    public HorizontalStackLayoutPage(HorizontalStackLayoutPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}