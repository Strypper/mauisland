namespace MAUIsland;
public partial class GridPage : IGalleryPage
{
    #region [ Fields ]

    private readonly GridPageViewModel viewModel;
    #endregion

    #region [ CTor ]
    public GridPage(GridPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = viewModel = vm;

        Slider redSlider = new();
        redSlider.ValueChanged += OnSliderValueChanged;

        Slider blueSlider = new();
        blueSlider.ValueChanged += OnSliderValueChanged;

        Slider greenSlider = new();
        greenSlider.ValueChanged += OnSliderValueChanged;
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

    void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        boxView.Color = new Color((float)redSlider.Value, (float)greenSlider.Value, (float)blueSlider.Value);
    }
    #endregion

}