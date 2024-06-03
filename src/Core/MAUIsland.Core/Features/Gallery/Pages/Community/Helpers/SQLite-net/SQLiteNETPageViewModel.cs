namespace MAUIsland.Core;

public partial class SQLiteNETPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public SQLiteNETPageViewModel(
    IAppNavigator appNavigator
) : base(appNavigator)
    {
    }
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string intro = "SQLite-net is an open source, minimal library to allow .NET, .NET Core, and Mono applications to store data in SQLite 3 databases. It was first designed to work with Xamarin.iOS, but has since grown up to work on all the platforms (Xamarin.*, .NET, UWP, Azure, etc.).";

    [ObservableProperty]
    string headerFeatures = "SQLite-net was designed as a quick and convenient database layer. Its design follows from these goals:";

    [ObservableProperty]
    string[] features = new string[]
    {
        "Very easy to integrate with existing projects and runs on all the .NET platforms.",
        "Thin wrapper over SQLite that is fast and efficient. (This library should not be the performance bottleneck of your queries.)",
        "Very simple methods for executing CRUD operations and queries safely (using parameters) and for retrieving the results of those query in a strongly typed fashion.",
        "Works with your data model without forcing you to change your classes. (Contains a small reflection-driven ORM layer.)",
    };

    [ObservableProperty]
    string headerNuget = "NuGet Installation";

    [ObservableProperty]
    string nuget = "Install-Package sqlite-net-pcl";

    [ObservableProperty]
    string nugetImportant = "You will need to add the NuGet package to both your .NET Standard library project and your platform-dependent app project.";

    [ObservableProperty]
    string headerExample = "Example";

    [ObservableProperty]
    string example = "The library contains simple attributes that you can use to control the construction of tables. In a simple stock program, you might use:";

    [ObservableProperty]
    string code = @"
public class Stock
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Symbol { get; set; }
}

public class Valuation
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [Indexed]
    public int StockId { get; set; }
    public DateTime Time { get; set; }
    public decimal Price { get; set; }
    [Ignore]
    public string IgnoreField { get; set; }
}";

    [ObservableProperty]
    string example2 = "Once you've defined the objects in your model you have a choice of APIs. You can use the \"synchronous API\" where calls block one at a time, or you can use the \"asynchronous API\" where calls do not block. You may care to use the asynchronous API for mobile applications in order to increase responsiveness.\r\n\r\nBoth APIs are explained in the two sections below.";

    [ObservableProperty]
    string headerSynchronous = "Synchronous API";

    [ObservableProperty]
    string headerAsynchronous = "Asynchronous API";

    [ObservableProperty]
    string headerManualSQL = "Manual SQL";

    [ObservableProperty]
    string headerSQLCipher = "Using SQLCipher";

    [ObservableProperty]
    string synchronous = "Once you have defined your entity, you can automatically generate tables in your database by calling CreateTable:";

    [ObservableProperty]
    string asynchronous = "The asynchronous library uses the Task Parallel Library (TPL). As such, normal use of Task objects, and the async and await keywords will work for you.\r\n\r\nOnce you have defined your entity, you can automatically generate tables by calling CreateTableAsync:";

    [ObservableProperty]
    string asynchronous1 = "You can insert rows in the database using Insert. If the table contains an auto-incremented primary key, then the value for that key will be available to you after the insert:";

    [ObservableProperty]
    string asynchronous2 = "Similar methods exist for UpdateAsync and DeleteAsync.\r\n\r\nQuerying for data is most straightforwardly done using the Table method. This will return an AsyncTableQuery instance back, whereupon you can add predicates for constraining via WHERE clauses and/or adding ORDER BY. The database is not physically touched until one of the special retrieval methods - ToListAsync, FirstAsync, or FirstOrDefaultAsync - is called.";

    [ObservableProperty]
    string asynchronous3 = "There are a number of low-level methods available. You can also query the database directly via the QueryAsync method. Over and above the change operations provided by InsertAsync etc you can issue ExecuteAsync methods to change sets of data directly within the database.\r\n\r\nAnother helpful method is ExecuteScalarAsync. This allows you to return a scalar value from the database easily:";

    [ObservableProperty]
    string manualSQL = "sqlite-net is normally used as a light ORM (object-relational-mapper) using the methods CreateTable and Table. However, you can also use it as a convenient way to manually execute queries.";

    [ObservableProperty]
    string manualSQL1 = "Here is an example of creating a table, inserting into it (with a parameterized command), and querying it without using ORM features.";

    [ObservableProperty]
    string sqlCipher = "You can use an encrypted database by using the";

    [ObservableProperty]
    string sqlCipherLink = "https://www.nuget.org/packages/sqlite-net-sqlcipher";

    [ObservableProperty]
    string optionSQLCipher = "The database key is set in the SqliteConnectionString passed to the connection constructor:";

    [ObservableProperty]
    string option2SQLCipher = "If you need set pragmas to control the encryption, actions can be passed to the connection string:";

    [ObservableProperty]
    string codeSynchronous = @"
// Get an absolute path to the database file
var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ""MyData.db"");

var db = new SQLiteConnection(databasePath);
db.CreateTable<Stock>();
db.CreateTable<Valuation>();";

    [ObservableProperty]
    string codeAsynchronous = @"
// Get an absolute path to the database file
var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ""MyData.db"");

var db = new SQLiteAsyncConnection(databasePath);

await db.CreateTableAsync<Stock>();

Console.WriteLine(""Table created!"");";

    [ObservableProperty]
    string codeAsynchronous1 = @"
var stock = new Stock()
{
    Symbol = ""AAPL""
};

await db.InsertAsync(stock);

Console.WriteLine(""Auto stock id: {0}"", stock.Id);
";

    [ObservableProperty]
    string codeAsynchronous2 = @"
var query = db.Table<Stock>().Where(s => s.Symbol.StartsWith(""A""));

var result = await query.ToListAsync();

foreach (var s in result)
    Console.WriteLine(""Stock: "" + s.Symbol);
";

    [ObservableProperty]
    string codeAsynchronous3 = @"
var count = await db.ExecuteScalarAsync<int>(""select count(*) from Stock"");

Console.WriteLine(string.Format(""Found '{0}' stock items."", count));
";

    [ObservableProperty]
    string codeManualSQL = @"
db.Execute(""create table Stock(Symbol varchar(100) not null)"");
db.Execute(""insert into Stock(Symbol) values (?)"", ""MSFT"");
var stocks = db.Query<Stock>(""select * from Stock"");
";

    [ObservableProperty]
    string synchronousInsert = "You can insert rows in the database using Insert. If the table contains an auto-incremented primary key, then the value for that key will be available to you after the insert:";

    [ObservableProperty]
    string codeSynchronousInsert = @"
public static void AddStock(SQLiteConnection db, string symbol) {
    var stock = new Stock() {
        Symbol = symbol
    };
    db.Insert(stock);
    Console.WriteLine(""{0} == {1}"", stock.Symbol, stock.Id);
}";

    [ObservableProperty]
    string codeSQLCipher = "var options = new SQLiteConnectionString(databasePath, true,\r\n\tkey: \"password\");\r\nvar encryptedDb = new SQLiteAsyncConnection(options);";

    [ObservableProperty]
    string code2SQLCipher = "var options2 = new SQLiteConnectionString (databasePath, true,\r\n\tkey: \"password\",\r\n\tpreKeyAction: db => db.Execute(\"PRAGMA cipher_default_use_hmac = OFF;\"),\r\n\tpostKeyAction: db => db.Execute (\"PRAGMA kdf_iter = 128000;\"));\r\nvar encryptedDb2 = new SQLiteAsyncConnection (options2);";

    [ObservableProperty]
    string synchronousUpdateAndDelete = "Similar methods exist for Update and Delete.";

    [ObservableProperty]
    string synchronousQuery = "The most straightforward way to query for data is using the Table method. This can take predicates for constraining via WHERE clauses and/or adding ORDER BY clauses:";

    [ObservableProperty]
    string codeSynchronousQuery = @"
var query = db.Table<Stock>().Where(s => s.Symbol.StartsWith(""A""));

var result = await query.ToListAsync();

foreach (var s in result)
    Console.WriteLine(""Stock: "" + s.Symbol);";

    [ObservableProperty]
    string synchronousLowLevelQuery = "You can also query the database at a low-level using the Query method:";

    [ObservableProperty]
    string codeSynchronousLowLevelQuery = "public static IEnumerable<Valuation> QueryValuations (SQLiteConnection db, Stock stock) {\r\n\treturn db.Query<Valuation> (\"select * from Valuation where StockId = ?\", stock.Id);\r\n}";

    [ObservableProperty]
    string genericParameterQuery = "The generic parameter to the Query method specifies the type of object to create for each row. It can be one of your table classes, or any other class whose public properties match the column returned by the query. For instance, we could rewrite the above query as:";

    [ObservableProperty]
    string executeMethod = "You can perform low-level updates of the database using the Execute method.";

    [ObservableProperty]
    string codeGenericParameterQuery = "public class Val\r\n{\r\n\tpublic decimal Money { get; set; }\r\n\tpublic DateTime Date { get; set; }\r\n}\r\n\r\npublic static IEnumerable<Val> QueryVals (SQLiteConnection db, Stock stock) {\r\n\treturn db.Query<Val> (\"select \\\"Price\\\" as \\\"Money\\\", \\\"Time\\\" as \\\"Date\\\" from Valuation where StockId = ?\", stock.Id);\r\n}";

    [ObservableProperty]
    string lowLevelMethods = "There are a number of low-level methods available. You can also query the database directly via the QueryAsync method. Over and above the change operations provided by InsertAsync etc you can issue ExecuteAsync methods to change sets of data directly within the database.";

    [ObservableProperty]
    string executeScalarAsync = "Another helpful method is ExecuteScalarAsync. This allows you to return a scalar value from the database easily:";

    [ObservableProperty]
    string codeExecuteScalarAsync = "var count = await db.ExecuteScalarAsync<int>(\"select count(*) from Stock\");\r\n\r\nConsole.WriteLine(string.Format(\"Found '{0}' stock items.\", count));";
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
