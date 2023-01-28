namespace MAUIsland;

public partial class SourceCodeExpander : ContentView
{
    #region [CTor]
    public SourceCodeExpander()
    {
        InitializeComponent();

    }
    #endregion

    #region [Bindable Properties]
    public static readonly BindableProperty XamlCodeProperty = BindableProperty.Create( nameof(XamlCode),
                                                                                           typeof(string),
                                                                                           typeof(SourceCodeExpander),
                                                                                           default(string));
    public string XamlCode
    {
        get => (string)GetValue(XamlCodeProperty);
        set => SetValue(XamlCodeProperty, value);
    }


    public static readonly BindableProperty CodeTypeProperty = BindableProperty.Create(nameof(CodeType),
                                                                                       typeof(CodeType),
                                                                                       typeof(SourceCodeExpander),
                                                                                       CodeType.Xaml);
    public CodeType CodeType
    {
        get => (CodeType)GetValue(CodeTypeProperty);
        set => SetValue(CodeTypeProperty, value);
    }
    #endregion

    private async void Copy_Clicked(object sender, EventArgs e) =>
        await Clipboard.Default.SetTextAsync(XamlCode);
}

public class CodeTypeToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public partial class SourceCodeForSample : BaseModel
{
    [ObservableProperty]
    string codeContent;

    [ObservableProperty]
    CodeType codeType;
}

public enum CodeType
{
    CSharp, Xaml
}