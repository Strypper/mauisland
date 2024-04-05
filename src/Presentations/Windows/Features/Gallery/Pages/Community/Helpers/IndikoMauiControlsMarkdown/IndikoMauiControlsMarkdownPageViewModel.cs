namespace MAUIsland;

public partial class IndikoMauiControlsMarkdownPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public IndikoMauiControlsMarkdownPageViewModel(
    IAppNavigator appNavigator
) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string intro = "The MarkdownView component is a versatile and customizable Markdown renderer designed for MAUI.NET applications. It allows developers to display Markdown-formatted text within their MAUI.NET applications, providing a rich text experience.";

    [ObservableProperty]
    string markDownContent = "![](nuget.png)\r\n\r\n# MarkdownView Component for MAUI.NET\r\n\r\nThe `MarkdownView` component is a versatile and customizable Markdown renderer designed for MAUI.NET applications. It allows developers to display Markdown-formatted text within their MAUI.NET applications, providing a rich text experience.\r\n\r\n## Build Status\r\n![ci](https://github.com/0xc3u/Indiko.Maui.Controls.Markdown/actions/workflows/ci.yml/badge.svg)\r\n\r\n## Install Controls\r\n[![NuGet](https://img.shields.io/nuget/v/Indiko.Maui.Controls.Markdown.svg?label=NuGet)](https://www.nuget.org/packages/Indiko.Maui.Controls.Markdown/)\r\n\r\nAvailable on [NuGet](http://www.nuget.org/packages/Indiko.Maui.Controls.Markdown.Markdown).\r\n\r\nInstall with the dotnet CLI: `dotnet add package Indiko.Maui.Controls.Markdown`, or through the NuGet Package Manager in Visual Studio.\r\n\r\n\r\n## Features\r\n\r\n- **Customizable Appearance:** Offers extensive support for customizing text appearance, including font size, color, and line break modes for different Markdown elements.\r\n- **Bindable Properties:** Enables dynamic updates and data binding for Markdown content and styling properties.\r\n- **Supported Markdown Elements:** Renders basic Markdown elements, including headers, lists, block quotes, images, and code blocks.\r\n- **Multiple Image Sources:** The `MarkdownView` supports various sources for displaying images within Markdown content, including image URLs, local file paths, and base64 encoded strings. This flexibility allows for a wide range of image content to be seamlessly integrated into your Markdown text.\r\n\r\n## Bindable Properties\r\n\r\nThe `MarkdownView` component offers several bindable properties to customize the Markdown rendering:\r\n\r\n- **MarkdownText:** The Markdown-formatted text to be displayed.\r\n- **LineBreakModeText:** Controls the line break mode for regular text content.\r\n- **LineBreakModeHeader:** Controls the line break mode for header elements (H1, H2, H3).\r\n- **H1Color, H2Color, H3Color:** Sets the text color for H1, H2, and H3 headers, respectively.\r\n- **H1FontSize, H2FontSize, H3FontSize:** Sets the font size for H1, H2, and H3 headers, respectively.\r\n- **TextColor:** The default text color for the Markdown content.\r\n- **TextFontSize:** The default font size for the Markdown content.\r\n- **CodeBlockBackgroundColor, CodeBlockBorderColor:** Customize the background and border colors for code blocks.\r\n- **CodeBlockTextColor:** Sets the text color for code blocks.\r\n- **CodeBlockFontSize:** Sets the font size for code blocks.\r\n- **PlaceholderBackgroundColor:** Sets the background color for placeholder elements, such as space between Markdown elements.\r\n\r\n## Supported Markdown Tags and Features\r\n\r\nThe `MarkdownView` supports a subset of Markdown elements and features, suitable for most text formatting needs:\r\n\r\n- **Headers (H1, H2, H3):** Marked by `#`, `##`, `###` at the beginning of a line.\r\n- **Unordered Lists:** Created with lines starting with `-` or `*`.\r\n- **Block Quotes:** Denoted by lines starting with `>`.\r\n- **Images:** Uses the Markdown image syntax `![alt text](image_url)`, where the URL can be an http(s) link, a local file path, or a base64 encoded string. This enables the embedding of images from various sources directly within the Markdown content.\r\n- **Code Blocks:** Supports inline code with `` `code` `` and fenced code blocks with triple backticks ```.\r\n\r\n### Image Support Details\r\n\r\n- **Image URLs:** Direct links to images hosted online.\r\n- **Local File Paths:** Path to an image file stored locally within the application's directories.\r\n- **Base64 Encoded Strings:** A base64 encoded representation of an image, allowing for embedding image data directly within the Markdown string.\r\n\r\nTo include an image, simply use the standard Markdown image syntax with the desired source type. The `MarkdownView` component will automatically detect and handle the image source accordingly, ensuring that images are rendered correctly regardless of the source type.\r\n\r\n```markdown\r\n![Alt text](http://example.com/image.jpg)  // Image URL\r\n![Alt text](image.png)      // Local file\r\n![Alt text](base64,...)     // Base64 encoded string\r\n```\r\n\r\n### Platform supported\r\n\r\n| Platform | Minimum Version Supported |\r\n|----------|--------------------------|\r\n| iOS      |   14.2+         |\r\n| Android  |   21+   |\r\n\r\n## Usage\r\n\r\nTo use the `MarkdownView` in your MAUI.NET application, include it in your XAML or C# code and bind or set the `MarkdownText` property to your Markdown-formatted string. Customize the appearance using the available bindable properties to match your application's design.\r\n\r\n```xml\r\nxmlns:idk=\"clr-namespace:Indiko.Maui.Controls.Markdown.Markdown;assembly=Indiko.Maui.Controls.Markdown.Markdown\"\r\n\r\n...\r\n\r\n<idk:MarkdownView MarkdownText=\"{Binding YourMarkdownContent}\" />\r\n```\r\n\r\nEnsure to include the namespace reference for `MarkdownView` in your XAML or add the component programmatically in your C# code.";
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    async Task CopyToClipboardAsync(string text)
    {
        await Clipboard.Default.SetTextAsync(text);
        await AppNavigator.ShowSnackbarAsync("Code copied to clipboard", null, null);
    }
    #endregion
}
