namespace MAUIsland;

public partial class StepperPage : IGalleryPage
{
    #region [ Fields ]

    private readonly StepperPageViewModel viewModel;
    #endregion

    #region [ CTor ]

    public StepperPage(StepperPageViewModel vm)
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
    private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;
        RotatingLabel.Rotation = value;
        DisplayLabel.Text = string.Format("The Stepper value is {0}", value);
    }
    #endregion
}