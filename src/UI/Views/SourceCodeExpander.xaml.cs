namespace MAUIsland;

public partial class SourceCodeExpander : ContentView
{
    #region [CTor]

    #endregion

    #region [Bindable Properties]
    public static readonly BindableProperty XamlCodeProperty = BindableProperty.Create( nameof(XamlCode),
                                                                                           typeof(string),
                                                                                           typeof(RoundedEntry),
                                                                                           default(string));
    public string XamlCode
    {
        get => (string)GetValue(XamlCodeProperty);
        set => SetValue(XamlCodeProperty, value);
    }

    #endregion
    public SourceCodeExpander()
	{
		InitializeComponent();

    }

    private async void Copy_Clicked(object sender, EventArgs e) =>
        await Clipboard.Default.SetTextAsync(XamlCode);
}