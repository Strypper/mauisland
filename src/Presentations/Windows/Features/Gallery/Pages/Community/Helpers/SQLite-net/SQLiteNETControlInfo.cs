namespace MAUIsland;
public class SQLiteNETControlInfo : IGithubGalleryCardInfo
{
    public string RepositoryName => "sqlite-net";
    public string AuthorName => "praeclarum";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_database_search_24_regular
    };
    public string ControlName => "sqlite-net";
    public string ControlDetail => "SQLite-net is an open source, minimal library to allow .NET, .NET Core, and Mono applications to store data in SQLite 3 databases. It was first designed to work with Xamarin.iOS, but has since grown up to work on all the platforms (Xamarin.*, .NET, UWP, Azure, etc.).";
    public string ControlRoute => typeof(SQLiteNETPage).FullName;
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/Community/Helpers/SQLite-net";
    public string DocumentUrl => "https://github.com/praeclarum/sqlite-net";
    public string GroupName => ControlGroupInfo.GitHubCommunity;
    public GalleryCardType CardType => GalleryCardType.Helper;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => default;
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}
