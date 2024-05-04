namespace MAUIsland.Core;

public partial class MrIncreadibleItemHorizontalTemplateContentView : ContentView
{
    #region [ CTor ]
    public MrIncreadibleItemHorizontalTemplateContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(MrIncreadible),
        typeof(MrIncreadibleItemHorizontalTemplateContentView),
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