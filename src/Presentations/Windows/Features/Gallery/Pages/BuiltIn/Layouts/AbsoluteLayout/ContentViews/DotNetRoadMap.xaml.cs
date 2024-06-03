namespace MAUIsland;

public partial class DotNetRoadMap : ContentView
{
    #region [ Fields ]

    private readonly IAppNavigator appNavigator;
    #endregion

    #region [ CTor ]

    public DotNetRoadMap()
    {
        InitializeComponent();

        appNavigator = ServiceHelper.GetService<IAppNavigator>();
    }

    #endregion

    #region [ Properties ]

    private bool isLabelHidden;
    public bool IsLabelHidden
    {
        get => isLabelHidden;
        set
        {
            if (isLabelHidden != value)
            {
                isLabelHidden = value;
                OnPropertyChanged();
            }
        }
    }

    private bool isToggleElementsVisible;
    public bool IsToggleElementsVisible
    {
        get => isToggleElementsVisible;
        set
        {
            if (isToggleElementsVisible != value)
            {
                isToggleElementsVisible = value;
                OnPropertyChanged();
                OpacityLevel = value ? 1 : 0;
            }
        }
    }


    private double opacityLevel;
    public double OpacityLevel
    {
        get => opacityLevel;
        set
        {
            if (opacityLevel != value)
            {
                opacityLevel = value;
                OnPropertyChanged();
            }
        }
    }
    #endregion

    #region [ Event Handlers ]

    private void root_Loaded(object sender, EventArgs e)
    {
    }

    private void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if (sender is Label tappedLabel)
        {
            string labelName = tappedLabel.StyleId;
            if (string.IsNullOrEmpty(labelName) || string.IsNullOrWhiteSpace(labelName))
                return;

            string link = LinkMatching(labelName);
            if (string.IsNullOrEmpty(link) || string.IsNullOrWhiteSpace(link))
                return;
            appNavigator.OpenUrlAsync(link);
        }
        else return;
    }
    #endregion

    #region [ Methods ]

    string LinkMatching(string labelName)
        => labelName switch
        {
            nameof(CSharpFundamentalLink) => "https://learn.microsoft.com/en-us/shows/csharp-fundamentals-for-absolute-beginners/",
            nameof(CSharpLink) => "https://learn.microsoft.com/en-us/shows/csharp-fundamentals-for-absolute-beginners/",
            nameof(SQLFundamentalsLink) => "https://learn.microsoft.com/en-us/sql/sql-server/educational-sql-resources?view=sql-server-ver16",
            nameof(ASPNETCoreBasicsLink) => "https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-8.0",
            nameof(SOLIDLink) => "https://learn.microsoft.com/en-us/archive/msdn-magazine/2014/may/csharp-best-practices-dangers-of-violating-solid-principles-in-csharp",
            nameof(ORMLink) => "",
            nameof(DILink) => "https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection",
            nameof(DatabasesLink) => "",
            nameof(CachingLink) => "https://learn.microsoft.com/en-us/dotnet/core/extensions/caching"
        };

    #endregion
}