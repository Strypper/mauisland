namespace MAUIsland;

public partial class BreedLabel : ContentView
{
    #region [CTor]
    public BreedLabel()
    {
        InitializeComponent();
    }
    #endregion

    #region [Properties]
    public static readonly BindableProperty TextProperty = BindableProperty.Create( nameof(Text),
                                                                                    typeof(string),
                                                                                    typeof(BreedLabel),
                                                                                    default(string),
                                                                                    BindingMode.OneWay
                                                                                    );
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color),
                                                                                    typeof(Color),
                                                                                    typeof(BreedLabel),
                                                                                    default(Color),
                                                                                    BindingMode.OneWay
                                                                                    );
    public Color Color
    {
        get => (Color)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }
    #endregion
}