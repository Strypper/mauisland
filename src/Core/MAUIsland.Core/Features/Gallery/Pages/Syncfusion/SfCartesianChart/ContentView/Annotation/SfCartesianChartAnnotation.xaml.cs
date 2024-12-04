namespace MAUIsland.Core;

public partial class SfCartesianChartAnnotation : ContentView
{
    #region [ CTor ]
    public SfCartesianChartAnnotation()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartArea),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty AnnotationCodeDescriptionProperty = BindableProperty.Create(
        nameof(AnnotationCodeDescription),
        typeof(string),
        typeof(SfCartesianChartAnnotation),
        default(string)
    );

    public static readonly BindableProperty AnnotationForDateTimeChartCodeDescriptionProperty = BindableProperty.Create(
        nameof(AnnotationForDateTimeChartCodeDescription),
        typeof(string),
        typeof(SfCartesianChartAnnotation),
        default(string)
    );
    #endregion

    #region [ Properties ]
    public ObservableCollection<SfCartesianChartModel> ComponentData
    {
        get => (ObservableCollection<SfCartesianChartModel>)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }

    public string AnnotationCodeDescription
    {
        get => (string)GetValue(AnnotationCodeDescriptionProperty);
        set => SetValue(AnnotationCodeDescriptionProperty, value);
    }

    public string AnnotationForDateTimeChartCodeDescription
    {
        get => (string)GetValue(AnnotationForDateTimeChartCodeDescriptionProperty);
        set => SetValue(AnnotationForDateTimeChartCodeDescriptionProperty, value);
    }
    #endregion
}