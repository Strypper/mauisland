namespace MAUIsland;

public partial class SliderPage : IControlPage
{
    #region [CTor]
    public SliderPage(SliderPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

}