namespace MAUIsland;

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
    #endregion
}