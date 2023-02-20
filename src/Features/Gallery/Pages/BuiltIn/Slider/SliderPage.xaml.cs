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

    private void HavingFunSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;
        RotatingLabel.Rotation = value;
        RotatingLabel.Text = "Woohooooooo!!!!";
    }

    private void HavingFunSlider_DragCompleted(object sender, EventArgs e)
    {
        RotatingLabel.Text = "COME ON SLIDE ME !!!";
    }
}