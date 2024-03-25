namespace MAUIsland.Core;

public partial class HorizontalIconButton : ContentView
{
    #region [ Ctor ]

    public HorizontalIconButton()
    {
        InitializeComponent();
    }

    #endregion

    #region [Bindable Properties]

    public static readonly BindableProperty PrefixIconProperty = BindableProperty.Create(
        nameof(PrefixIcon),
        typeof(ImageSource),
        typeof(HorizontalIconButton),
        default(ImageSource)
        );

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(HorizontalIconButton),
        default(string),
        BindingMode.TwoWay
        );
    #endregion

    #region [Properties]
    public ImageSource PrefixIcon
    {
        get => (ImageSource)GetValue(PrefixIconProperty);
        set => SetValue(PrefixIconProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    #endregion
}