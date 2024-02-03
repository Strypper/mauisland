namespace MAUIsland;

public partial class ControllInfoCollectionTwoItemRowTemplateContentView : ContentView
{
    #region [ CTor ]
    public ControllInfoCollectionTwoItemRowTemplateContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(IGalleryCardInfo),
        typeof(ControllInfoCollectionTwoItemRowTemplateContentView),
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