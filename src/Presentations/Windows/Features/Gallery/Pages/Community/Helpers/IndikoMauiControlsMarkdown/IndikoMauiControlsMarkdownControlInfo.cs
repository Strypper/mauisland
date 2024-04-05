namespace MAUIsland;
public class IndikoMauiControlsMarkdownControlInfo : IGithubGalleryCardInfo
{
    public string RepositoryName => "Indiko.Maui.Controls.Markdown";
    public string AuthorName => "0xc3u";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_database_search_24_regular
    };
    public string ControlName => "Indiko.Maui.Controls.Markdown";
    public string ControlDetail => "The MarkdownView component is a versatile and customizable Markdown renderer designed for MAUI.NET applications. It allows developers to display Markdown-formatted text within their MAUI.NET applications, providing a rich text experience.";
    public string ControlRoute => typeof(IndikoMauiControlsMarkdownPage).FullName;
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/Community/Helpers/IndikoMauiControlsMarkdown";
    public string DocumentUrl => "https://github.com/0xc3u/Indiko.Maui.Controls.Markdown?tab=readme-ov-file";
    public string GroupName => ControlGroupInfo.GitHubCommunity;
    public GalleryCardType CardType => GalleryCardType.Helper;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => default;
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}
