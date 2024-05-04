namespace MAUIsland.Core;

public partial class MrIncreadibleItemVerticalSpan2TemplateContentView : ContentView
{
    #region [ CTor ]
    public MrIncreadibleItemVerticalSpan2TemplateContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(MrIncreadible),
        typeof(MrIncreadibleItemVerticalSpan2TemplateContentView),
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