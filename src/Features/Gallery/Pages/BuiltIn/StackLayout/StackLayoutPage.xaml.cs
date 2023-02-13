namespace MAUIsland;
public partial class StackLayoutPage : IControlPage
{
    #region [CTor]
    public StackLayoutPage(StackLayoutPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}