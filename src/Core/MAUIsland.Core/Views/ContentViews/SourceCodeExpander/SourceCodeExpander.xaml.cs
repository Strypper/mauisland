using ColorCode;
using CommunityToolkit.Maui.Views;
using System.ComponentModel;

namespace MAUIsland.Core;

public partial class SourceCodeExpander : ContentView, INotifyPropertyChanged
{
    #region [ Fields ]

    private IAppNavigator appNavigator;

    private FormattedString outputFormattedString;
    #endregion

    #region [ CTor ]
    public SourceCodeExpander()
    {
        InitializeComponent();


        appNavigator = ServiceHelper.GetService<IAppNavigator>();
    }
    #endregion

    #region [ Properties ]
    public FormattedString OutputFormattedString
    {
        get { return outputFormattedString; }
        set { outputFormattedString = value; OnPropertyChanged("OutputFormattedString"); }
    }
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty CodeProperty = BindableProperty.Create(nameof(Code),
                                                                                           typeof(string),
                                                                                           typeof(SourceCodeExpander),
                                                                                           default(string));
    public string Code
    {
        get => (string)GetValue(CodeProperty);
        set => SetValue(CodeProperty, value);
    }


    public static readonly BindableProperty CopyStatusProperty = BindableProperty.Create(nameof(CopyStatus),
                                                                                           typeof(string),
                                                                                           typeof(SourceCodeExpander),
                                                                                           default(string));
    public string CopyStatus
    {
        get => (string)GetValue(CopyStatusProperty);
        set => SetValue(CopyStatusProperty, value);
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

    #region [ Event Handlers ]

    private async void Copy_Clicked(object sender, EventArgs e)
    {
        await Clipboard.Default.SetTextAsync(Code);
        CopyStatus = $"Copied at: {DateTime.Now:HH:mm:ss}";
        await appNavigator.ShowSnackbarAsync("Code copied to clipboard", null, null);
    }
    private void root_Loaded(object sender, EventArgs e)
    {
        CodeTypeLabel.Text = CodeType == CodeType.Xaml ? "Xaml Code" : "C# Code";
        ApplyColor(Code, CodeType == CodeType.Xaml ? Languages.Xml : Languages.CSharp);
        ComponentFrame.BackgroundColor = CodeType == CodeType.Xaml
                                        ? Color.FromRgba("#ffffff") // Hex color for XAML type
                                        : Color.FromRgba("#2f2f2f");
        //CodeExpander.BackgroundColor = CodeType == CodeType.Xaml
        //                            ? Color.FromHex("#ffffff") // Hex color for XAML type
        //                            : Color.FromHex("#00B1EE");

    }
    private async void CodeExpander_ExpandedChanged(object sender, CommunityToolkit.Maui.Core.ExpandedChangedEventArgs e)
    {
        var expander = (Expander)sender;
        if (expander.Content is not null)
        {
            var lazyView = (LazyViewSourceCodeExpanderContent)expander.Content;
            if (expander.IsExpanded)
            {
                var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                await lazyView.LoadViewAsync(cts.Token);
            }
        }
    }

    #endregion

    #region [ Methods ]
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