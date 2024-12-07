namespace MAUIsland.Core;

public partial class SfCartesianChartAnnotation : ContentView
{
    #region [ CTor ]
    public SfCartesianChartAnnotation()
    {
        InitializeComponent();
        TextAnnotation.IsVisible = false;
        ShapeAnnotation.IsVisible = false;
        ViewAnnotation.IsVisible = false;
        ShapeAnnotationAxisLabel.IsVisible = false;
        ShapeAnnotationText.IsVisible = false;
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(ObservableCollection<SfCartesianChartModel>),
        typeof(SfCartesianChartArea),
        default(ObservableCollection<SfCartesianChartModel>)
    );

    public static readonly BindableProperty CodeDescriptionProperty = BindableProperty.Create(
        nameof(CodeDescription),
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

    public string CodeDescription
    {
        get => (string)GetValue(CodeDescriptionProperty);
        set => SetValue(CodeDescriptionProperty, value);
    }
    #endregion

    #region [ Events ]
    private void OnComponentLoaded(object sender, EventArgs e)
    {
        var textAnnotation = (string[])Resources["TextAnnotation"];
        TextAnnotationCollectionView.ItemsSource = textAnnotation;

        var shapeAnnotation = (string[])Resources["ShapeAnnotation"];
        ShapeAnnotationCollectionView.ItemsSource = shapeAnnotation;

        var shapeAnnotationAxisLabel = (string[])Resources["ShapeAnnotationAxisLabel"];
        ShapeAnnotationAxisLabelCollectionView.ItemsSource = shapeAnnotationAxisLabel;

        var shapeAnnotationText = (string[])Resources["ShapeAnnotationText"];
        ShapeAnnotationTextCollectionView.ItemsSource = shapeAnnotationText;
    }

    private async void OnTextGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (TextArrowImage.Rotation == 0)
        {
            await TextArrowImage.RotateTo(90);
            TextAnnotation.IsVisible = true;
        }
        else
        {
            await TextArrowImage.RotateTo(0);
            TextAnnotation.IsVisible = false;
        }
    }

    private async void OnShapeGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (ShapeArrowImage.Rotation == 0)
        {
            await ShapeArrowImage.RotateTo(90);
            ShapeAnnotation.IsVisible = true;
        }
        else
        {
            await ShapeArrowImage.RotateTo(0);
            ShapeAnnotation.IsVisible = false;
        }
    }

    private async void OnViewGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (ViewArrowImage.Rotation == 0)
        {
            await ViewArrowImage.RotateTo(90);
            ViewAnnotation.IsVisible = true;
        }
        else
        {
            await ViewArrowImage.RotateTo(0);
            ViewAnnotation.IsVisible = false;
        }
    }

    private async void OnShapeAxisLabelGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (ShapeAxisArrowImage.Rotation == 0)
        {
            await ShapeAxisArrowImage.RotateTo(90);
            ShapeAnnotationAxisLabel.IsVisible = true;
        }
        else
        {
            await ShapeAxisArrowImage.RotateTo(0);
            ShapeAnnotationAxisLabel.IsVisible = false;
        }
    }

    private async void OnShapeTextGridTapped(object sender, EventArgs e)
    {
        // Rotate the arrow image based on the expanded state
        if (ShapeTextArrowImage.Rotation == 0)
        {
            await ShapeTextArrowImage.RotateTo(90);
            ShapeAnnotationText.IsVisible = true;
        }
        else
        {
            await ShapeTextArrowImage.RotateTo(0);
            ShapeAnnotationText.IsVisible = false;
        }
    }
    #endregion
}