namespace MAUIsland;

public partial class SourceCodeExpander : ContentView
{
    #region [CTor]

    #endregion

    #region [Bindable Properties]
    public static readonly BindableProperty XAMLCodeProperty = BindableProperty.Create( nameof(XAMLCode),
                                                                                           typeof(Array),
                                                                                           typeof(RoundedEntry),
                                                                                           default(Array));
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title),
                                                                                    typeof(string),
                                                                                    typeof(RoundedEntry),
                                                                                    default(string));
    public Array XAMLCode
    {
        get => (Array)GetValue(XAMLCodeProperty);
        set => SetValue(XAMLCodeProperty, value);
    }

    public string Title
    {
        get=> (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion
    public SourceCodeExpander()
	{
		InitializeComponent();
    }

    private async void Copy_Clicked(object sender, EventArgs e) =>
        await Clipboard.Default.SetTextAsync(XAMLCode.ToString());
}