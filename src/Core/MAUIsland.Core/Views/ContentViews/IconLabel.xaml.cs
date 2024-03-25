namespace MAUIsland.Core;

public partial class IconLabel : ContentView
{

    #region [CTor]

    public IconLabel()
    {
        InitializeComponent();
    }

    #endregion

    #region [Properties]
    public static readonly BindableProperty PrefixIconProperty = BindableProperty.Create(nameof(PrefixIcon),
                                                                                         typeof(ImageSource),
                                                                                         typeof(IconLabel),
                                                                                         default(ImageSource));
    public ImageSource PrefixIcon
    {
        get => (ImageSource)GetValue(PrefixIconProperty);
        set => SetValue(PrefixIconProperty, value);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text),
                                                                                   typeof(string),
                                                                                   typeof(IconLabel),
                                                                                   default(string),
                                                                                   BindingMode.OneWay);
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor),
                                                                               typeof(Color),
                                                                               typeof(IconLabel),
                                                                               default(Color),
                                                                               BindingMode.OneWay);
    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }
    #endregion
}