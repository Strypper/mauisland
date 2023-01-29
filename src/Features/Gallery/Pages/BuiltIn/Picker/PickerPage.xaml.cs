namespace MAUIsland;

public partial class PickerPage : IControlPage
{
    #region [CTor]
    public PickerPage(PickerPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion
}