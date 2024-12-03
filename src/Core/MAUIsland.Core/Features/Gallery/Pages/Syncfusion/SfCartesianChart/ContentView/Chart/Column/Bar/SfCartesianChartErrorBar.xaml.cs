using Syncfusion.Maui.Toolkit.Charts;

namespace MAUIsland.Core;

public partial class SfCartesianChartErrorBar : ContentView
{
    #region [ CTor ]
    public SfCartesianChartErrorBar()               
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartErrorBar),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty ErrorBarTypesProperty = BindableProperty.Create(
        nameof(ErrorBarTypes),
        typeof(ObservableCollection<string>),
        typeof(SfCartesianChartErrorBar),
        default(ObservableCollection<string>)
    );
    public static readonly BindableProperty ErrorBarModesProperty = BindableProperty.Create(
        nameof(ErrorBarModes),
        typeof(ObservableCollection<string>),
        typeof(SfCartesianChartErrorBar),
        default(ObservableCollection<string>)
    );
    public static readonly BindableProperty ErrorBarDirectionsProperty = BindableProperty.Create(
        nameof(ErrorBarDirections),
        typeof(ObservableCollection<string>),
        typeof(SfCartesianChartErrorBar),
        default(ObservableCollection<string>)
    );

    public static readonly BindableProperty DefaultCodeDescriptionProperty = BindableProperty.Create(
        nameof(DefaultCodeDescription),
        typeof(string),
        typeof(SfCartesianChartErrorBar),
        default(string)
    );

    public static readonly BindableProperty CustomCodeDescriptionProperty = BindableProperty.Create(
        nameof(CustomCodeDescription),
        typeof(string),
        typeof(SfCartesianChartErrorBar),
        default(string)
    );
    #endregion

    #region [ Properties ]

    public ObservableCollection<SfCartesianChartModel> ComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }

    public ObservableCollection<string> ErrorBarTypes
    {
        get => (ObservableCollection<string>)GetValue(ErrorBarTypesProperty);
        set => SetValue(ErrorBarTypesProperty, value);
    }

    public ObservableCollection<string> ErrorBarModes
    {
        get => (ObservableCollection<string>)GetValue(ErrorBarModesProperty);
        set => SetValue(ErrorBarModesProperty, value);
    }

    public ObservableCollection<string> ErrorBarDirections
    {
        get => (ObservableCollection<string>)GetValue(ErrorBarDirectionsProperty);
        set => SetValue(ErrorBarDirectionsProperty, value);
    }

    public string DefaultCodeDescription
    {
        get => (string)GetValue(DefaultCodeDescriptionProperty);
        set => SetValue(DefaultCodeDescriptionProperty, value);
    }

    public string CustomCodeDescription
    {
        get => (string)GetValue(CustomCodeDescriptionProperty);
        set => SetValue(CustomCodeDescriptionProperty, value);
    }

    #endregion

    #region [ Event ]
    private void TypePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedValue = picker.SelectedItem;
        if (selectedValue.ToString() == ErrorBarType.Fixed.ToString())
        {
            CustomErrorSeries.Type = ErrorBarType.Fixed;
        }
        else if (selectedValue.ToString() == ErrorBarType.Percentage.ToString())
        {
            CustomErrorSeries.Type = ErrorBarType.Percentage;
        }
        else if (selectedValue.ToString() == ErrorBarType.StandardError.ToString())
        {
            CustomErrorSeries.Type = ErrorBarType.StandardError;
        }
        else if (selectedValue.ToString() == ErrorBarType.StandardDeviation.ToString())
        {
            CustomErrorSeries.Type = ErrorBarType.StandardDeviation;
        }
    }

    private void ModePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedValue = picker.SelectedItem;
        if (selectedValue.ToString() == ErrorBarMode.Vertical.ToString())
        {
            CustomErrorSeries.Mode = ErrorBarMode.Vertical;
            HorizontalStepper.IsEnabled = false;
            VerticalStepper.IsEnabled = true;

        }
        else if (selectedValue.ToString() == ErrorBarMode.Horizontal.ToString())
        {
            CustomErrorSeries.Mode = ErrorBarMode.Horizontal;
            HorizontalStepper.IsEnabled = true;
            VerticalStepper.IsEnabled = false;
        }
        else
        {
            CustomErrorSeries.Mode = ErrorBarMode.Both;
            HorizontalStepper.IsEnabled = true;
            VerticalStepper.IsEnabled = true;
        }
    
    }

    private void DirectionPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedValue = picker.SelectedItem;
        if (ModePicker.SelectedItem == null) 
        {
            return;
        }
        if (selectedValue.ToString() == ErrorBarDirection.Both.ToString())
        {
            if (ModePicker.SelectedItem.ToString() == ErrorBarMode.Horizontal.ToString())
            {
                CustomErrorSeries.HorizontalDirection = ErrorBarDirection.Both;
            }
            else if (ModePicker.SelectedItem.ToString() == ErrorBarMode.Vertical.ToString())
            {
                CustomErrorSeries.VerticalDirection = ErrorBarDirection.Both;
            }
            else
            {
                CustomErrorSeries.HorizontalDirection = ErrorBarDirection.Both;
                CustomErrorSeries.VerticalDirection = ErrorBarDirection.Both;
            }
        }
        else if (selectedValue.ToString() == ErrorBarDirection.Plus.ToString())
        {
            if (ModePicker.SelectedItem.ToString() == ErrorBarMode.Horizontal.ToString())
            {
                CustomErrorSeries.HorizontalDirection = ErrorBarDirection.Plus;
            }
            else if (ModePicker.SelectedItem.ToString() == ErrorBarMode.Vertical.ToString())
            {
                CustomErrorSeries.VerticalDirection = ErrorBarDirection.Plus;
            }
            else if (ModePicker.SelectedItem.ToString() == ErrorBarMode.Both.ToString())
            {
                CustomErrorSeries.HorizontalDirection = CustomErrorSeries.VerticalDirection = ErrorBarDirection.Plus;
            }
        }
        else
        {
            if (ModePicker.SelectedItem.ToString() == ErrorBarMode.Horizontal.ToString())
            {
                CustomErrorSeries.HorizontalDirection = ErrorBarDirection.Minus;
            }
            if (ModePicker.SelectedItem.ToString() == ErrorBarMode.Vertical.ToString())
            {
                CustomErrorSeries.VerticalDirection = ErrorBarDirection.Minus;
            }
            if (ModePicker.SelectedItem.ToString() == ErrorBarMode.Both.ToString())
            {
                CustomErrorSeries.HorizontalDirection = CustomErrorSeries.VerticalDirection = ErrorBarDirection.Minus;
            }
        }

    }
    #endregion
}