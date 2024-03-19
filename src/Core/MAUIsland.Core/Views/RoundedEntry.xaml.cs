namespace MAUIsland.Core;

public partial class RoundedEntry : ContentView
{
    public RoundedEntry()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty PrefixIconProperty = BindableProperty.Create(
        nameof(PrefixIcon),
        typeof(ImageSource),
        typeof(RoundedEntry),
        default(ImageSource)
        );
    public ImageSource PrefixIcon
    {
        get => (ImageSource)GetValue(PrefixIconProperty);
        set => SetValue(PrefixIconProperty, value);
    }

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        nameof(Placeholder),
        typeof(string),
        typeof(RoundedEntry),
        default(string)
        );
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(RoundedEntry),
        default(string),
        BindingMode.TwoWay
        );
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
        nameof(IsPassword),
        typeof(bool),
        typeof(RoundedEntry),
        default(bool)
        );
    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(
        nameof(Keyboard),
        typeof(Keyboard),
        typeof(RoundedEntry),
        Keyboard.Default
    );
    public Keyboard Keyboard
    {
        get => (Keyboard)GetValue(KeyboardProperty);
        set => SetValue(KeyboardProperty, value);
    }

    public static readonly BindableProperty IsValidProperty = BindableProperty.Create(
        nameof(IsValid),
        typeof(bool),
        typeof(RoundedEntry),
        true,
        BindingMode.OneWay,
        propertyChanged: HandleIsValidChanged
    );
    private static void HandleIsValidChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not RoundedEntry entry) return;

        entry.border.BorderColor = (bool)newValue ? AppColors.Green : AppColors.Red;
    }

    public bool IsValid
    {
        get => (bool)GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }

    void Entry_Focused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
        if (e.IsFocused)
        {
            border.BorderColor = Colors.Transparent;
            return;
        }

        border.BorderColor = IsValid ? AppColors.Green : AppColors.Red;
    }
}
