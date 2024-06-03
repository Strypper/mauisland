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
