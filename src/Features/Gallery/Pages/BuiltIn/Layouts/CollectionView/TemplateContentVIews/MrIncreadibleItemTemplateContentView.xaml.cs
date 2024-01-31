namespace MAUIsland;

public partial class MrIncreadibleItemTemplateContentView : ContentView
{
    #region [ CTor ]
    public MrIncreadibleItemTemplateContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(MrIncreadible),
        typeof(MrIncreadibleItemTemplateContentView),
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