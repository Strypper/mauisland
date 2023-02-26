using ColorCode;
using System.ComponentModel;

namespace MAUIsland;

public partial class SourceCodeExpander : ContentView, INotifyPropertyChanged
{
    #region [CTor]
    public SourceCodeExpander()
    {
        InitializeComponent();
    }
    #endregion

    #region [Fields]
    private FormattedString outputFormattedString;
    #endregion

    #region [Properties]
    public FormattedString OutputFormattedString
    {
        get { return outputFormattedString; }
        set { outputFormattedString = value; OnPropertyChanged("OutputFormattedString"); }
    }
    #endregion

    #region [Bindable Properties]
    public static readonly BindableProperty CodeProperty = BindableProperty.Create(nameof(Code),
                                                                                           typeof(string),
                                                                                           typeof(SourceCodeExpander),
                                                                                           default(string));
    public string Code
    {
        get => (string)GetValue(CodeProperty);
        set => SetValue(CodeProperty, value);
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

    public static readonly BindableProperty ShowCodeTypeProperty = BindableProperty.Create(nameof(ShowCodeType),
                                                                                   typeof(bool),
                                                                                   typeof(SourceCodeExpander),
                                                                                   true);
    public bool ShowCodeType
    {
        get => (bool)GetValue(ShowCodeTypeProperty);
        set => SetValue(ShowCodeTypeProperty, value);
    }

    public static readonly BindableProperty IsExpandingProperty = BindableProperty.Create(nameof(IsExpanding),
                                                                               typeof(bool),
                                                                               typeof(SourceCodeExpander),
                                                                               false);
    public bool IsExpanding
    {
        get => (bool)GetValue(IsExpandingProperty);
        set => SetValue(IsExpandingProperty, value);
    }
    #endregion

    #region [Event Handlers]

    private async void Copy_Clicked(object sender, EventArgs e) =>
        await Clipboard.Default.SetTextAsync(Code);
    private void root_Loaded(object sender, EventArgs e)
    {
        CodeTypeLabel.Text = CodeType == CodeType.Xaml ? "Xaml Code" : "C# Code";
        ApplyColor(Code, CodeType == CodeType.Xaml ? Languages.Xml : Languages.CSharp);
    }

    #endregion

    #region [Methods]
    private void ApplyColor(string code, ILanguage language)
    {
        var formatter = new FormattedStringFormatter();
        var fs = new FormattedString();
        formatter.FormatString(code, language, fs);

        //Output = XamlServices.Save(fs);

        OutputFormattedString = fs;
    }
    #endregion

}


#region [Converters]
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
#endregion

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