namespace MAUIsland;

public partial class SliderPage
{
    #region [CTor]
    public SliderPage(SliderPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

}