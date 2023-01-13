namespace MAUIsland;

public partial class CheckBoxPage
{
    #region [CTor]
    public CheckBoxPage(CheckBoxPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

}