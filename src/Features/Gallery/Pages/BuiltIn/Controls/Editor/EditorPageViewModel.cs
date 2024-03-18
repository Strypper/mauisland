namespace MAUIsland;

public partial class EditorPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public EditorPageViewModel(IAppNavigator appNavigator)
                                : base(appNavigator)
    {

    }
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    int editorCharacterLimit = 10;

    [ObservableProperty]
    EditorAutoSizeOption autoSizeMode;

    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string title = "Welcome to Editor";

    [ObservableProperty]
    string simpleEditXamlCode =
        "<Editor x:Name=\"editor\"\r\n" +
        "        Placeholder=\"Enter your response here\"\r\n" +
        "        HeightRequest=\"250\"\r\n" +
        "        TextChanged=\"OnEditorTextChanged\"\r\n" +
        "        Completed=\"OnEditorCompleted\" />";

    [ObservableProperty]
    string controlTextInEditorXamlCode =
    "<VerticalStackLayout Spacing=\"10\">\r\n" +
    "    <Label Style=\"{x:StaticResource DocumentSectionTitleStyle}\" Text=\"Set character spacing\" />\r\n" +
    "    <Slider\r\n" +
    "        x:Name=\"EditorCharacterSpacingSlider\"\r\n" +
    "        Maximum=\"50\"\r\n" +
    "        Minimum=\"0\" />\r\n" +
    "\r\n" +
    "    <Picker\r\n" +
    "        x:Name=\"EditorColorPicker\"\r\n" +
    "        Title=\"Change Text Color\"\r\n" +
    "        BackgroundColor=\"#512bd4\"\r\n" +
    "        ItemsSource=\"{x:StaticResource LabelColorResource}\" />\r\n" +
    "    <Editor\r\n" +
    "        x:Name=\"CharacterSpacingEditor\"\r\n" +
    "        CharacterSpacing=\"{x:Binding Source={x:Reference EditorCharacterSpacingSlider},\r\n" +
    "                                     Path=Value,\r\n" +
    "                                     Mode=TwoWay}\"\r\n" +
    "        TextColor=\"{x:Binding Source={x:Reference EditorColorPicker},\r\n" +
    "                              Path=SelectedItem,\r\n" +
    "                              Converter={x:StaticResource StringToColorConverter}}\" />\r\n" +
    "</VerticalStackLayout>";

    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    void ChangeAutoSizeMode()
        => AutoSizeMode = AutoSizeMode == EditorAutoSizeOption.TextChanges ? EditorAutoSizeOption.Disabled : EditorAutoSizeOption.TextChanges;
    #endregion
}
