namespace MAUIsland;

public partial class SelectedItemTemplateContentView : ContentView
{
    #region [ CTor ]
    public SelectedItemTemplateContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(IGalleryCardInfo),
        typeof(SelectedItemTemplateContentView),
        default(IGalleryCardInfo)
    );
    #endregion

    #region [ Properties ]
    public IGalleryCardInfo ComponentData
    {
        get => (IGalleryCardInfo)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }
    #endregion
}