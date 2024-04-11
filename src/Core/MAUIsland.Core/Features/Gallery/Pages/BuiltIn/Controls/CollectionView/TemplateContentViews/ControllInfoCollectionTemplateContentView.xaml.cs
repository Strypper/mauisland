namespace MAUIsland.Core;

public partial class ControllInfoCollectionTemplateContentView : ContentView
{
    #region [ CTor ]
    public ControllInfoCollectionTemplateContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(IGalleryCardInfo),
        typeof(ControllInfoCollectionTemplateContentView),
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