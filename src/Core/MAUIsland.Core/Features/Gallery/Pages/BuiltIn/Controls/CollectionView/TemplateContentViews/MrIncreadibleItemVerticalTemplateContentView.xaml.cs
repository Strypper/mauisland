namespace MAUIsland.Core;

public partial class MrIncreadibleItemVerticalTemplateContentView : ContentView
{
    #region [ CTor ]
    public MrIncreadibleItemVerticalTemplateContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(MrIncreadible),
        typeof(MrIncreadibleItemVerticalTemplateContentView),
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