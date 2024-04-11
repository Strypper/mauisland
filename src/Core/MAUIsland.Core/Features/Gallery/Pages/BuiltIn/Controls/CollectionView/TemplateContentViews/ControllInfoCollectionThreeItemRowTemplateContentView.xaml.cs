namespace MAUIsland.Core;

public partial class ControllInfoCollectionThreeItemRowTemplateContentView : ContentView
{
    #region [ CTor ]
    public ControllInfoCollectionThreeItemRowTemplateContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(IGalleryCardInfo),
        typeof(ControllInfoCollectionThreeItemRowTemplateContentView),
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