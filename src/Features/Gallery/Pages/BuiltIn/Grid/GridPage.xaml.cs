namespace MAUIsland;
public partial class GridPage : IControlPage
{
    #region [CTor]
    public GridPage(GridPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;

        Slider redSlider = new();
        redSlider.ValueChanged += OnSliderValueChanged;

        Slider blueSlider = new();
        blueSlider.ValueChanged += OnSliderValueChanged;

        Slider greenSlider = new();
        greenSlider.ValueChanged += OnSliderValueChanged;
    }
    #endregion

    void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        boxView.Color = new Color((float)redSlider.Value, (float)greenSlider.Value, (float)blueSlider.Value);
    }
}