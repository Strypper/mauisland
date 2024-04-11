namespace MAUIsland.Core;

public partial class MrIncreadibleCollectionTemplateWithSwipeContentView : ContentView
{
    #region [ CTor ]
    public MrIncreadibleCollectionTemplateWithSwipeContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(MrIncreadible),
        typeof(MrIncreadibleCollectionTemplateWithSwipeContentView),
        default(MrIncreadible)
    );
    #endregion

    #region [ Properties ]
    public MrIncreadible ComponentData
    {
        get => (MrIncreadible)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }
    #endregion
}