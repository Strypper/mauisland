namespace MAUIsland;

public partial class ControllInfoCollectionFourItemRowTemplateContentView : ContentView
{
    #region [ CTor ]
    public ControllInfoCollectionFourItemRowTemplateContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(IGalleryCardInfo),
        typeof(ControllInfoCollectionFourItemRowTemplateContentView),
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