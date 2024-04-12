namespace MAUIsland;

public partial class SliderPage : IGalleryPage
{
    #region [ Fields ]

    private readonly SliderPageViewModel viewModel;
    #endregion

    #region [ CTor ]

    public SliderPage(SliderPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;
    }
    #endregion

    #region [ Event Handlers ]

    private void BasePage_Loaded(object sender, EventArgs e)
    {
        if (NewWindowParameter is not null && viewModel.ControlInformation is null)
        {
            viewModel.SetControlInformation(NewWindowParameter);
            viewModel.RefreshCommand.Execute(null);
        }
    }
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
    #endregion

}