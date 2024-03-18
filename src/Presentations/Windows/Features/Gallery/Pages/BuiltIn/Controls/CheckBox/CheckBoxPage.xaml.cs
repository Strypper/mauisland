namespace MAUIsland;

public partial class CheckBoxPage : IGalleryPage
{
    #region [CTor]
    public CheckBoxPage(CheckBoxPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

}