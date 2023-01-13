namespace MAUIsland;

public partial class CheckBoxPage : IControlPage
{
    #region [CTor]
    public CheckBoxPage(CheckBoxPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

}