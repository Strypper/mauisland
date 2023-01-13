using System.ComponentModel;

namespace MAUIsland;

public class CodeLine
{
    public int Index { get; set; }

    public string Code { get; set; }
}

public partial class SourceCodeExpander : ContentView
{
    #region [CTor]

    #endregion

    #region [Bindable Properties]
    public static readonly BindableProperty XAMLCodeProperty = BindableProperty.Create( nameof(XAMLCode),
                                                                                        typeof(string),
                                                                                        typeof(RoundedEntry),
                                                                                        default(string));
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title),
                                                                                    typeof(string),
                                                                                    typeof(RoundedEntry),
                                                                                    default(string));

    VerticalStackLayout _verticalStackLayout;

    public string XAMLCode
    {
        get => (string)GetValue(XAMLCodeProperty);
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

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _verticalStackLayout = (VerticalStackLayout)GetTemplateChild("sourceCodeContainer1");
    }
    private async void Copy_Clicked(object sender, EventArgs e) =>
        await Clipboard.Default.SetTextAsync(XAMLCode.ToString());

    private void btn_showCode_Clicked(object sender, EventArgs e)
    {
        _verticalStackLayout.IsVisible = !_verticalStackLayout.IsVisible;
    }
}