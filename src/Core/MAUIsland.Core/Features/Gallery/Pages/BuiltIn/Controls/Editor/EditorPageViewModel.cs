using DiscordRPC;
using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class EditorPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public EditorPageViewModel(IAppNavigator appNavigator,
                               IGitHubService gitHubService,
                               DiscordRpcClient discordRpcClient,
                               IGitHubIssueLocalDbService gitHubIssueLocalDbService)
                                : base(appNavigator,
                                        gitHubService,
                                        discordRpcClient,
                                        gitHubIssueLocalDbService)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string title = "Welcome to Editor";

    [ObservableProperty]
    int editorCharacterLimit = 10;

    [ObservableProperty]
    EditorAutoSizeOption autoSizeMode;

    [ObservableProperty]
    TextTransform selectedTextTransform;

    [ObservableProperty]
    ObservableCollection<TextTransform> textTransformList;

    [ObservableProperty]
    bool isTextPrediction;

    [ObservableProperty]
    bool isReadOnly;

    [ObservableProperty]
    string xamlSimpleEditor =
        "<Editor x:Name=\"editor\"\r\n" +
        "        Placeholder=\"Enter your response here\"\r\n" +
        "        HeightRequest=\"250\"\r\n" +
        "        TextChanged=\"OnEditorTextChanged\"\r\n" +
        "        Completed=\"OnEditorCompleted\" />";

    [ObservableProperty]
    string cSharpSimpleEditorCodeBehind =
        "void OnEditorTextChanged(object sender, TextChangedEventArgs e)\r\n" +
        "{\r\n" +
        "    OldTextSpan.Text = e.OldTextValue;\r\n" +
        "    NewTextSpan.Text = e.NewTextValue;\r\n" +
        "}\r\n\r\n" +
        "void OnEditorCompleted(object sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    string text = ((Editor)sender).Text;\r\n" +
        "}";

    [ObservableProperty]
    string xamlEditorDecoration =
        "<Grid ColumnDefinitions=\"0.7*, 0.3*\" \r\n" +
        "      RowDefinitions=\"0.3*, 0.7*\" \r\n" +
        "      ColumnSpacing=\"10\"\r\n" +
        "      RowSpacing=\"10\"\r\n" +
        "      HeightRequest=\"200\">\r\n" +
        "   <VerticalStackLayout Grid.Row=\"0\"\r\n" +
        "                        Grid.Column=\"0\">\r\n" +
        "       <Label Text=\"Set character spacing\" TextColor=\"#bfbfbf\"/>\r\n" +
        "           <Slider x:Name=\"EditorCharacterSpacingSlider\"\r\n" +
        "                   Maximum=\"50\"\r\n" +
        "                   Minimum=\"0\"/>\r\n" +
        "   </VerticalStackLayout>\r\n" +
        "   <Picker x:Name=\"EditorColorPicker\"\r\n" +
        "           Grid.Row=\"0\"\r\n" +
        "           Grid.Column=\"1\"\r\n" +
        "           Title=\"Text Color\"\r\n" +
        "           ItemsSource=\"{x:StaticResource LabelColorResource}\"\r\n" +
        "           SelectedIndex=\"5\"/>\r\n" +
        "   <Editor Grid.Row=\"1\"\r\n" +
        "           Grid.Column=\"0\"\r\n" +
        "           Grid.ColumnSpan=\"2\"\r\n" +
        "           CharacterSpacing=\"{x:Binding Source={x:Reference EditorCharacterSpacingSlider},Path=Value, Mode=TwoWay}\"\r\n" +
        "           Placeholder=\"Type something in buddy\"\r\n" +
        "           TextColor=\"{x:Binding Source={x:Reference EditorColorPicker}, Path=SelectedItem, Converter={x:StaticResource StringToColorConverter}}\"/>\r\n" +
        "</Grid>";

    [ObservableProperty]
    string xamlEditorDecorationConverterDeclare =
        "<ContentPage x:Class=\"MAUIsland.EditorPage\"\r\n" +
        "             xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
        "             xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
        "             xmlns:app=\"clr-namespace:MAUIsland\"\r\n" +
        "             xmlns:core=\"clr-namespace:MAUIsland.Core;assembly=MAUIsland.Core\"\r\n" +
        "             x:DataType=\"app:EditorPageViewModel\">\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <ResourceDictionary>\r\n" +
        "           <core:StringToColorConverter x:Key=\"StringToColorConverter\" />\r\n" +
        "       </ResourceDictionary>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string cSharpEditorDecorationConverter =
        "public class StringToColorConverter : IValueConverter\r\n" +
        "{\r\n" +
        "    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)\r\n" +
        "    {\r\n" +
        "        var stringValue = value as String;\r\n\r\n" +
        "        if (stringValue != null && !string.IsNullOrWhiteSpace(stringValue) && !string.IsNullOrEmpty(stringValue))\r\n" +
        "        {\r\n" +
        "            var color = System.Drawing.Color.FromName(stringValue);\r\n" +
        "            return Color.FromRgb(color.R, color.G, color.B);\r\n" +
        "        }\r\n" +
        "        return null;\r\n" +
        "    }\r\n\r\n" +
        "    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)\r\n" +
        "    {\r\n" +
        "        throw new NotImplementedException();\r\n" +
        "    }\r\n" +
        "}";

    [ObservableProperty]
    string xamlEditorTextLengthAndAutoSize =
        "<Grid ColumnDefinitions=\"0.7*, 0.3*\"\r\n" +
        "      ColumnSpacing=\"10\">\r\n" +
        "   <Editor x:Name=\"Editor2\" Grid.Column=\"0\"\r\n" +
        "           Text=\"Enter text here\"\r\n" +
        "           AutoSize=\"{x:Binding AutoSizeMode}\"\r\n" +
        "           MaxLength=\"{x:Binding EditorCharacterLimit}\"/>\r\n" +
        "   <VerticalStackLayout Grid.Column=\"1\"\r\n" +
        "                        Spacing=\"5\">\r\n" +
        "       <Label Text=\"Limit Your Editor\"/>\r\n" +
        "       <Frame BackgroundColor=\"#4d4d4d\" \r\n" +
        "              BorderColor=\"#4d4d4d\" \r\n" +
        "              Padding=\"10\">\r\n" +
        "           <Grid ColumnDefinitions=\"0.7*, 0.2*\" \r\n" +
        "                 ColumnSpacing=\"10\">\r\n" +
        "               <Slider x:Name=\"CharacterLimitSlider\" \r\n" +
        "                       Grid.Column=\"0\" \r\n" +
        "                       Maximum=\"1000\" \r\n" +
        "                       Minimum=\"1\" \r\n" +
        "                       Value=\"{x:Binding EditorCharacterLimit}\"/>\r\n" +
        "               <Label Grid.Column=\"1\" \r\n" +
        "                      Text=\"{x:Binding EditorCharacterLimit}\" \r\n" +
        "                      VerticalOptions=\"Center\"\r\n" +
        "                      HorizontalOptions=\"Center\"/>\r\n" +
        "           </Grid>\r\n" +
        "       </Frame>\r\n" +
        "       <Label Text=\"Change AutoSize Mode\"/>\r\n" +
        "       <Button Text=\"{x:Binding AutoSizeMode}\"\r\n" +
        "               Command=\"{x:Binding ChangeAutoSizeModeCommand}\" />\r\n" +
        "   </VerticalStackLayout>\r\n" +
        "</Grid>";

    [ObservableProperty]
    string cSharpEditorTextLengthAndAutoSize =
        "[ObservableProperty]\r\n" +
        "int editorCharacterLimit = 10;\r\n\r\n" +
        "[ObservableProperty]\r\n" +
        "EditorAutoSizeOption autoSizeMode;";

    [ObservableProperty]
    string xamlEditorTransformText =
        "<Grid ColumnDefinitions=\"0.8*, 0.2*\"\r\n" +
        "      ColumnSpacing=\"10\">\r\n" +
        "   <Editor Grid.Column=\"0\"\r\n" +
        "           Text=\"Enter text here\"\r\n" +
        "           TextTransform=\"{x:Binding SelectedTextTransform}\"/>\r\n" +
        "   <Picker Grid.Column=\"1\"\r\n" +
        "           ItemsSource=\"{x:Binding TextTransformList, Mode=OneWay}\"\r\n" +
        "           SelectedItem=\"{x:Binding SelectedTextTransform, Mode=TwoWay, Converter={StaticResource TextTransformConverter}}\"/>\r\n" +
        "</Grid>";

    [ObservableProperty]
    string xamlEditorTransformTextConverterDeclare =
        "<ContentPage x:Class=\"MAUIsland.EditorPage\"\r\n" +
        "             xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
        "             xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
        "             xmlns:app=\"clr-namespace:MAUIsland\"\r\n" +
        "             xmlns:core=\"clr-namespace:MAUIsland.Core;assembly=MAUIsland.Core\"\r\n" +
        "             x:DataType=\"app:EditorPageViewModel\">\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <ResourceDictionary>\r\n" +
        "           <app:EditorTextTransformPickerConverter x:Key=\"TextTransformConverter\" />\r\n" +
        "       </ResourceDictionary>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string cSharpEditorTransformTextConverter =
        "public class EditorTextTransformPickerConverter : IValueConverter\r\n" +
        "{\r\n" +
        "    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)\r\n" +
        "    {\r\n" +
        "        if (value is TextTransform textTransform)\r\n" +
        "        {\r\n" +
        "            return textTransform;\r\n" +
        "        }\r\n\r\n" +
        "        return TextTransform.None;\r\n" +
        "    }\r\n\r\n" +
        "    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)\r\n" +
        "    {\r\n" +
        "        if (value is TextTransform textTransform)\r\n" +
        "        {\r\n" +
        "            return textTransform;\r\n" +
        "        }\r\n\r\n" +
        "        return TextTransform.None;\r\n" +
        "    }\r\n" +
        "}";

    [ObservableProperty]
    string cSharpEditorTransformTextViewModel =
        "[ObservableProperty]\r\n" +
        "TextTransform selectedTextTransform = TextTransform.None;\r\n\r\n" +
        "[ObservableProperty]\r\n" +
        "ObservableCollection<TextTransform> textTransformList = new ObservableCollection<TextTransform>\r\n" +
        "{\r\n" +
        "    TextTransform.None,\r\n" +
        "    TextTransform.Default,\r\n" +
        "    TextTransform.Lowercase,\r\n" +
        "    TextTransform.Uppercase\r\n" +
        "};";

    [ObservableProperty]
    string xamlEditorPredictionReadOnly =
        "<Grid ColumnDefinitions=\"0.8*, 0.2*\"\r\n" +
        "      ColumnSpacing=\"10\">\r\n" +
        "   <Editor Grid.Column=\"0\"\r\n" +
        "           Text=\"Enter text here\"\r\n" +
        "           IsTextPredictionEnabled=\"{x:Binding IsTextPrediction}\"\r\n" +
        "           IsReadOnly=\"{x:Binding IsReadOnly}\"/>\r\n" +
        "   <VerticalStackLayout Grid.Column=\"1\">\r\n" +
        "       <Label Text=\"Text Prediction\" />\r\n" +
        "       <Switch IsToggled=\"{x:Binding IsTextPrediction, Mode=TwoWay}\"/>\r\n" +
        "       <Label Text=\"Read Only\" />\r\n" +
        "       <Switch IsToggled=\"{x:Binding IsReadOnly, Mode=TwoWay}\"/>\r\n" +
        "   </VerticalStackLayout>\r\n" +
        "</Grid>";

    [ObservableProperty]
    string cSharpEditorPredictionReadOnlyViewModel =
        "[ObservableProperty]\r\n" +
        "bool isTextPrediction = false;\r\n\r\n" +
        "[ObservableProperty]\r\n" +
        "bool isReadOnly = false;";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IBuiltInGalleryCardInfo>();

        LoadDataAsync().FireAndForget();
    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
        await RefreshAsync();
    }
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    async Task RefreshAsync()
    {

        if (ControlInformation is null)
            return;

        await RefreshControlIssues(true,
                                   ControlInformation.ControlName,
                                   ControlInformation.GitHubAuthorIssueName,
                                   ControlInformation.GitHubRepositoryIssueName,
                                   ControlInformation.GitHubIssueLabels);
    }

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    void ChangeAutoSizeMode()
        => AutoSizeMode = AutoSizeMode == EditorAutoSizeOption.TextChanges ? EditorAutoSizeOption.Disabled : EditorAutoSizeOption.TextChanges;
    #endregion

    #region [ Data ]
    private async Task LoadDataAsync()
    {
        TextTransformList = new ObservableCollection<TextTransform>
        {
            TextTransform.None,
            TextTransform.Default,
            TextTransform.Lowercase,
            TextTransform.Uppercase
        };
        SelectedTextTransform = TextTransform.None;
        IsTextPrediction = false;
        IsReadOnly = false;
    }
    #endregion
}
