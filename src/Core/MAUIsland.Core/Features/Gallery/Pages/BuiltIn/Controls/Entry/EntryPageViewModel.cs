using DiscordRPC;
using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;

public partial class EntryPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public EntryPageViewModel(IAppNavigator appNavigator,
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
    string textMessage = string.Empty;

    [ObservableProperty]
    ObservableCollection<ChatMessageModel> messages = default!;

    [ObservableProperty]
    string standardEntryXamlCode =
    "<Entry x:Name=\"Entry\"\n" +
    "       Placeholder=\"Enter text here\"\n" +
    "       PlaceholderColor=\"LightSlateGray\"\n" +
    "       HorizontalTextAlignment=\"Start\"\n" +
    "       VerticalTextAlignment=\"Center\"/>";

    [ObservableProperty]
    string content = "In addition, Entry defines a Completed event, which is raised when the user finalizes text in the Entry with the return key.";

    [ObservableProperty]
    string content1 = "Entry derives from the InputView class, from which it inherits the following properties:";

    [ObservableProperty]
    List<string> entryList = new()
    {
        "CharacterSpacing, of type double, sets the spacing between characters in the entered text.",
        "CursorPosition, of type int, defines the position of the cursor within the editor.",
        "FontAttributes, of type FontAttributes, determines text style.",
        "FontAutoScalingEnabled, of type bool, defines whether the text will reflect scaling preferences set in the operating system. The default value of this property is true.",
        "FontFamily, of type string, defines the font family.",
        "FontSize, of type double, defines the font size.",
        "IsReadOnly, of type bool, defines whether the user should be prevented from modifying text. The default value of this property is false.",
        "IsSpellCheckEnabled, of type bool, controls whether spell checking is enabled.",
        "IsTextPredictionEnabled, of type bool, controls whether text prediction and automatic text correction is enabled.",
        "Keyboard, of type Keyboard, specifies the soft input keyboard that's displayed when entering text.",
        "MaxLength, of type int, defines the maximum input length.",
        "Placeholder, of type string, defines the text that's displayed when the control is empty.",
        "PlaceholderColor, of type Color, defines the color of the placeholder text.",
        "SelectionLength, of type int, represents the length of selected text within the control.",
        "Text, of type string, defines the text entered into the control.",
        "TextColor, of type Color, defines the color of the entered text.",
        "TextTransform, of type TextTransform, specifies the casing of the entered text."
    };

    [ObservableProperty]
    string content2 = "In addition, InputView defines a TextChanged event, which is raised when the text in the Entry changes. The TextChangedEventArgs object that accompanies the TextChanged event has NewTextValue and OldTextValue properties, which specify the new and old text, respectively.";

    [ObservableProperty]
    string createAnEntryHeader = "Create an Entry";

    [ObservableProperty]
    string content3 = "The following example shows how to create an Entry:";

    [ObservableProperty]
    string createAnEntryXamlCode =
        "<Entry x:Name=\"entry\"\n" +
        "       Placeholder=\"Enter text\"\n" +
        "       TextChanged=\"OnEntryTextChanged\"\n" +
        "       Completed=\"OnEntryCompleted\" />";

    [ObservableProperty]
    string content4 = "The equivalent C# code is:";

    [ObservableProperty]
    string createAnEntryCSharpCode =
    "Entry entry = new Entry \n" +
    "{ \n" +
    "    Placeholder = \"Enter text\" \n" +
    "};\n" +
    "entry.TextChanged += OnEntryTextChanged;\n" +
    "entry.Completed += OnEntryCompleted;";

    [ObservableProperty]
    string createAnEntryNote = "On iOS, the soft input keyboard can cover a text input field when the field is near the bottom of the screen, making it difficult to enter text. However, in a .NET MAUI iOS app, pages automatically scroll when the soft input keyboard would cover a text entry field, so that the field is above the soft input keyboard. The KeyboardAutoManagerScroll.Disconnect method, in the Microsoft.Maui.Platform namespace, can be called to disable this default behavior. The KeyboardAutoManagerScroll.Connect method can be called to re-enable the behavior after it's been disabled.";

    [ObservableProperty]
    string content5 = "Entered text can be accessed by reading the Text property, and the TextChanged and Completed events signal that the text has changed or been completed.";

    [ObservableProperty]
    string content6 = "The TextChanged event is raised when the text in the Entry changes, and the TextChangedEventArgs provide the text before and after the change via the OldTextValue and NewTextValue properties:";

    [ObservableProperty]
    string createAnEntryCSharpCode1 =
    "void OnEntryTextChanged(object sender, TextChangedEventArgs e)\n" +
    "{\n" +
    "    string oldText = e.OldTextValue;\n" +
    "    string newText = e.NewTextValue;\n" +
    "    string myText = entry.Text;\n" +
    "}";

    [ObservableProperty]
    string content7 = "The Completed event is raised when the user has ended input by pressing the Return key on the keyboard, or by pressing the Tab key on Windows. The handler for the event is a generic event handler:";

    [ObservableProperty]
    string createAnEntryCSharpCode2 =
    "void OnEntryCompleted(object sender, EventArgs e)\n" +
    "{\n" +
    "    string text = ((Entry)sender).Text;\n" +
    "}";

    [ObservableProperty]
    string content8 = "After the Completed event fires, any ICommand specified by the ReturnCommand property is executed, with the object specified by the ReturnCommandParameter property being passed to the ReturnCommand.";

    [ObservableProperty]
    string createAnEntryNote1 = "The VisualElement class, which is in the Entry inheritance hierarchy, also has Focused and Unfocused events.";

    [ObservableProperty]
    string setCharacterSpacingHeader = "Set character spacing";

    [ObservableProperty]
    string setCharacterSpacing = "Character spacing can be applied to an Entry by setting the CharacterSpacing property to a double value:";

    [ObservableProperty]
    string setCharacterSpacingXamlCode = "<Entry ...\r\n       CharacterSpacing=\"10\" />";

    [ObservableProperty]
    string setCharacterSpacing1 = "The result is that characters in the text displayed by the Entry are spaced CharacterSpacing device-independent units apart.";

    [ObservableProperty]
    string setCharacterSpacingNote = "The CharacterSpacing property value is applied to the text displayed by the Text and Placeholder properties.";

    [ObservableProperty]
    string limitInputLengthHeader = "Limit input length";

    [ObservableProperty]
    string limitInputLength = "The MaxLength property can be used to limit the input length that's permitted for the Entry. This property should be set to a positive integer:";

    [ObservableProperty]
    string limitInputLengthXamlCode = "<Entry ...\r\n       MaxLength=\"10\" />";

    [ObservableProperty]
    string limitInputLength1 = "A MaxLength property value of 0 indicates that no input will be allowed, and a value of int.MaxValue, which is the default value for an Entry, indicates that there is no effective limit on the number of characters that may be entered.";

    [ObservableProperty]
    string setTheCursorPositionAndTextSelectionLengthHeader = "Set the cursor position and text selection length";

    [ObservableProperty]
    string setTheCursorPositionAndTextSelectionLength = "The CursorPosition property can be used to return or set the position at which the next character will be inserted into the string stored in the Text property:";

    [ObservableProperty]
    string setTheCursorPositionAndTextSelectionLengthXamlCode = "<Entry Text=\"Cursor position set\"\r\n       CursorPosition=\"5\" />";

    [ObservableProperty]
    string setTheCursorPositionAndTextSelectionLength1 = "The default value of the CursorPosition property is 0, which indicates that text will be inserted at the start of the Entry.";

    [ObservableProperty]
    string setTheCursorPositionAndTextSelectionLength2 = "In addition, the SelectionLength property can be used to return or set the length of text selection within the Entry:";

    [ObservableProperty]
    string setTheCursorPositionAndTextSelectionLengthXamlCode1 =
        "<Entry Text=\"Cursor position and selection length set\"\n" +
        "       CursorPosition=\"2\"\n" +
        "       SelectionLength=\"10\" />";

    [ObservableProperty]
    string setTheCursorPositionAndTextSelectionLength3 = "The default value of the SelectionLength property is 0, which indicates that no text is selected.";

    [ObservableProperty]
    string displayAClearButtonHeader = "Display a clear button";

    [ObservableProperty]
    string displayAClearButton = "The ClearButtonVisibility property can be used to control whether an Entry displays a clear button, which enables the user to clear the text. This property should be set to a ClearButtonVisibility enumeration member:";

    [ObservableProperty]
    List<string> displayAClearButtonList = new()
    {
        "Never indicates that a clear button will never be displayed. This is the default value for the ClearButtonVisibility property.",
        "WhileEditing indicates that a clear button will be displayed in the Entry, while it has focus and text."
    };

    [ObservableProperty]
    string displayAClearButtonXamlCode =
    "<Entry Text=\".NET MAUI\"\n" +
    "       ClearButtonVisibility=\"WhileEditing\" />";

    [ObservableProperty]
    string displayAClearButton1 = "The following example shows setting the property:";

    [ObservableProperty]
    string transformTextHeader = "Transform text";

    [ObservableProperty]
    string transformText = "An Entry can transform the casing of its text, stored in the Text property, by setting the TextTransform property to a value of the TextTransform enumeration. This enumeration has four values:";

    [ObservableProperty]
    List<string> transformTextList = new()
    {
        "None indicates that the text won't be transformed.",
        "Default indicates that the default behavior for the platform will be used. This is the default value of the TextTransform property.",
        "Lowercase indicates that the text will be transformed to lowercase.",
        "Uppercase indicates that the text will be transformed to uppercase."
    };

    [ObservableProperty]
    string transformText1 = "The following example shows transforming text to uppercase:";

    [ObservableProperty]
    string transformTextXamlCode =
        "<Entry Text=\"This text will be displayed in uppercase.\"\n" +
        "       TextTransform=\"Uppercase\" />";

    [ObservableProperty]
    string obscureTextEntryHeader = "Obscure text entry";

    [ObservableProperty]
    string obscureTextEntry = "Entry provides the IsPassword property which visually obscures entered text when it's set to true:";

    [ObservableProperty]
    string obscureTextEntryXamlCode = "<Entry IsPassword=\"true\" />";

    [ObservableProperty]
    string customizeTheKeyboardHeader = "Customize the keyboard";

    [ObservableProperty]
    string customizeTheKeyboard = "The soft input keyboard that's presented when users interact with an Entry can be set programmatically via the Keyboard property, to one of the following properties from the Keyboard class:";

    [ObservableProperty]
    List<string> customizeTheKeyboardList = new()
    {
        "Chat – used for texting and places where emoji are useful.",
        "Default – the default keyboard.",
        "Email – used when entering email addresses.",
        "Numeric – used when entering numbers.",
        "Plain – used when entering text, without any KeyboardFlags specified.",
        "Telephone – used when entering telephone numbers.",
        "Text – used when entering text.",
        "Url – used for entering file paths & web addresses."
    };

    [ObservableProperty]
    string customizeTheKeyboard1 = "The following example shows setting the Keyboard property:";

    [ObservableProperty]
    string customizeTheKeyboardXamlCode = "<Entry Keyboard=\"Chat\" />";

    [ObservableProperty]
    string customizeTheKeyboard2 = "The Keyboard class also has a Create factory method that can be used to customize a keyboard by specifying capitalization, spellcheck, and suggestion behavior. KeyboardFlags enumeration values are specified as arguments to the method, with a customized Keyboard being returned. The KeyboardFlags enumeration contains the following values:";

    [ObservableProperty]
    List<string> customizeTheKeyboardList1 = new()
    {
        "None – no features are added to the keyboard.",
        "CapitalizeSentence – indicates that the first letter of the first word of each entered sentence will be automatically capitalized.",
        "Spellcheck – indicates that spellcheck will be performed on entered text.",
        "Suggestions – indicates that word completions will be offered on entered text.",
        "CapitalizeWord – indicates that the first letter of each word will be automatically capitalized.",
        "CapitalizeCharacter – indicates that every character will be automatically capitalized.",
        "CapitalizeNone – indicates that no automatic capitalization will occur.",
        "All – indicates that spellcheck, word completions, and sentence capitalization will occur on entered text."
    };

    [ObservableProperty]
    string customizeTheKeyboard3 = "The following XAML code example shows how to customize the default Keyboard to offer word completions and capitalize every entered character:";

    [ObservableProperty]
    string customizeTheKeyboardXamlCode1 =
    "<Entry Placeholder=\"Enter text here\">\n" +
    "    <Entry.Keyboard>\n" +
    "        <Keyboard x:FactoryMethod=\"Create\">\n" +
    "            <x:Arguments>\n" +
    "                <KeyboardFlags>Suggestions,CapitalizeCharacter</KeyboardFlags>\n" +
    "            </x:Arguments>\n" +
    "        </Keyboard>\n" +
    "    </Entry.Keyboard>\n" +
    "</Entry>";

    [ObservableProperty]
    string customizeTheKeyboard4 = "The equivalent C# code is:";

    [ObservableProperty]
    string customizeTheKeyboardCSharpCode =
    "Entry entry = new Entry { Placeholder = \"Enter text here\" };\n" +
    "entry.Keyboard = Keyboard.Create(KeyboardFlags.Suggestions | KeyboardFlags.CapitalizeCharacter);";

    [ObservableProperty]
    string customizeTheReturnKeyHeader = "Customize the return key";

    [ObservableProperty]
    string customizeTheReturnKey = "The appearance of the return key on the soft input keyboard, which is displayed when an Entry has focus, can be customized by setting the ReturnType property to a value of the ReturnType enumeration:";

    [ObservableProperty]
    List<string> customizeTheReturnKeyList = new()
    {
        "Default – indicates that no specific return key is required and that the platform default will be used.",
        "Done – indicates a \"Done\" return key.",
        "Go – indicates a \"Go\" return key.",
        "Next – indicates a \"Next\" return key.",
        "Search – indicates a \"Search\" return key.",
        "Send – indicates a \"Send\" return key."
    };

    [ObservableProperty]
    string customizeTheReturnKeyXamlCode = "<Entry ReturnType=\"Send\" />";

    [ObservableProperty]
    string customizeTheReturnKey1 = "The following XAML example shows how to set the return key:";

    [ObservableProperty]
    string customizeTheReturnKeyNote = "The exact appearance of the return key is dependent upon the platform. On iOS, the return key is a text-based button. However, on Android and Windows, the return key is a icon-based button.";

    [ObservableProperty]
    string customizeTheReturnKey2 = "When the Return key is pressed, the Completed event fires and any ICommand specified by the ReturnCommand property is executed. In addition, any object specified by the ReturnCommandParameter property will be passed to the ICommand as a parameter. For more information about commands, see Commanding.";

    [ObservableProperty]
    string hideAndShowTheSoftInputKeyboardHeader = "Hide and show the soft input keyboard";

    [ObservableProperty]
    string hideAndShowTheSoftInputKeyboard = "The SoftInputExtensions class, in the Microsoft.Maui namespace, provides a series of extension methods that support interacting with the soft input keyboard on controls that support text input. The class defines the following methods:";

    [ObservableProperty]
    List<string> hideAndShowTheSoftInputKeyboardList = new()
    {
        "IsSoftInputShowing, which checks to see if the device is currently showing the soft input keyboard.",
        "HideSoftInputAsync, which will attempt to hide the soft input keyboard if it's currently showing.",
        "ShowSoftInputAsync, which will attempt to show the soft input keyboard if it's currently hidden."
    };

    [ObservableProperty]
    string hideAndShowTheSoftInputKeyboard1 = "The following example shows how to hide the soft input keyboard on an Entry named entry, if it's currently showing:";

    [ObservableProperty]
    string hideAndShowTheSoftInputKeyboardCSharpCode =
    "if (entry.IsSoftInputShowing())\n" +
    "    await entry.HideSoftInputAsync(System.Threading.CancellationToken.None);";

    [ObservableProperty]
    string enableAndDisableSpellCheckingHeader = "Enable and disable spell checking";

    [ObservableProperty]
    string enableAndDisableSpellChecking = "The IsSpellCheckEnabled property controls whether spell checking is enabled. By default, the property is set to true. As the user enters text, misspellings are indicated.";

    [ObservableProperty]
    string enableAndDisableSpellChecking1 = "However, for some text entry scenarios, such as entering a username, spell checking provides a negative experience and should be disabled by setting the IsSpellCheckEnabled property to false:";

    [ObservableProperty]
    string enableAndDisableSpellCheckingXamlCode = "<Entry ... IsSpellCheckEnabled=\"false\" />";

    [ObservableProperty]
    string enableAndDisableSpellCheckingNote = "When the IsSpellCheckEnabled property is set to false, and a custom keyboard isn't being used, the native spell checker will be disabled. However, if a Keyboard has been set that disables spell checking, such as Keyboard.Chat, the IsSpellCheckEnabled property is ignored. Therefore, the property cannot be used to enable spell checking for a Keyboard that explicitly disables it.";

    [ObservableProperty]
    string enableAndDisableTextPredictionHeader = "Enable and disable text prediction";

    [ObservableProperty]
    string enableAndDisableTextPrediction = "The IsTextPredictionEnabled property controls whether text prediction and automatic text correction is enabled. By default, the property is set to true. As the user enters text, word predictions are presented.";

    [ObservableProperty]
    string enableAndDisableTextPrediction1 = "However, for some text entry scenarios, such as entering a username, text prediction and automatic text correction provides a negative experience and should be disabled by setting the IsTextPredictionEnabled property to false:";

    [ObservableProperty]
    string enableAndDisableTextPredictionXamlCode = "<Entry ... IsTextPredictionEnabled=\"false\" />";

    [ObservableProperty]
    string enableAndDisableTextPredictionNote = "When the IsTextPredictionEnabled property is set to false, and a custom keyboard isn't being used, text prediction and automatic text correction is disabled. However, if a Keyboard has been set that disables text prediction, the IsTextPredictionEnabled property is ignored. Therefore, the property cannot be used to enable text prediction for a Keyboard that explicitly disables it.";

    [ObservableProperty]
    string preventTextEntryHeader = "Prevent text entry";

    [ObservableProperty]
    string preventTextEntry = "Users can be prevented from modifying the text in an Entry by setting the IsReadOnly property to true:";

    [ObservableProperty]
    string preventTextEntryXamlCode =
    "<Entry Text=\"User input won't be accepted.\"\n" +
    "       IsReadOnly=\"true\" />";


    [ObservableProperty]
    string preventTextEntryNote = "The IsReadonly property does not alter the visual appearance of an Entry, unlike the IsEnabled property that also changes the visual appearance of the Entry to gray.";
    #endregion

    #region [ Overrides ]

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IBuiltInGalleryCardInfo>();

        Messages = new();
    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
        await RefreshAsync();
    }

    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    Task SendMessage(string message)
    {
        Messages.Add(new ChatMessageModel()
        {
            AuthorName = "MAUIsland",
            AuthorImage = "dotnet_bot.png",
            ChatMessageContent = message,
            SentTime = DateTime.Now
        });

        TextMessage = string.Empty;

        return Task.CompletedTask;
    }

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
    #endregion
}
