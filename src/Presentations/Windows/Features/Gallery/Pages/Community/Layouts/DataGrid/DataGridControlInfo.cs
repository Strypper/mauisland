namespace MAUIsland;
class DataGridControlInfo : IGithubGalleryCardInfo
{
    public string RepositoryName => "Maui.DataGrid";
    public string AuthorName => "akgulebubekir";
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_document_table_24_regular
    };
    public string ControlName => "DataGrid";
    public string ControlDetail => "MAUI.Datagrid is a library allows us to create complex data grids or tables for displaying record data, it supports sorting and virtualization, so creating another card demonstrates the use cases of this library";
    public string ControlRoute => typeof(DataGridPage).FullName;
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/tree/main/src/Presentations/Windows/Features/Gallery/Pages/Community/Layouts/DataGrid";
    public string DocumentUrl => "https://github.com/akgulebubekir/Maui.DataGrid";  //SvnUrl
    public string GroupName => ControlGroupInfo.GitHubCommunity;
    public GalleryCardType CardType => GalleryCardType.Layout;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => default;
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}