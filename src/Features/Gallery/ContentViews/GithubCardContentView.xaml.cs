using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUIsland;

public partial class GithubCardContentView : ContentView
{
    #region [ CTor ]
    public GithubCardContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [ Delegates ]
    public delegate void DetailEventHandler(IGithubGalleryCardInfo control);

    public delegate void DetailInNewWindowEventHandler(IGithubGalleryCardInfo control);
    #endregion

    #region [ Events ]
    public event DetailEventHandler DetailClicked;

    public event DetailInNewWindowEventHandler DetailInNewWindowClicked;

    public event PropertyChangedEventHandler GithubCardPropertyChanged;
    #endregion

    #region [ Bindable Properties ]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(IGithubGalleryCardInfo),
        typeof(GithubCardContentView),
        default(IGithubGalleryCardInfo)
    );

    public static readonly BindableProperty RepositoryUrlProperty = BindableProperty.Create(
        nameof(RepositoryUrl),
        typeof(string),
        typeof(GithubCardContentView),
        default(string)
    );

    public static readonly BindableProperty AuthorAvatarProperty = BindableProperty.Create(
        nameof(AuthorAvatar),
        typeof(string),
        typeof(GithubCardContentView),
        default(string)
    );

    public static readonly BindableProperty IssuesCountProperty = BindableProperty.Create(
        nameof(Issues),
        typeof(int),
        typeof(GithubCardContentView),
        default(int)
    );

    public static readonly BindableProperty ForksCountProperty = BindableProperty.Create(
        nameof(Forks),
        typeof(int),
        typeof(GithubCardContentView),
        default(int)
    );

    public static readonly BindableProperty StargazersCountProperty = BindableProperty.Create(
        nameof(Stars),
        typeof(int),
        typeof(GithubCardContentView),
        default(int)
    );

    public static readonly BindableProperty LicenseProperty = BindableProperty.Create(
        nameof(License),
        typeof(string),
        typeof(GithubCardContentView),
        default(string)
    );

    public static readonly BindableProperty UpdateAtProperty = BindableProperty.Create(
        nameof(UpdateAt),
        typeof(DateTime),
        typeof(GithubCardContentView),
        default(DateTime)
    );

    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    #endregion

    #region [ Properties ]
    public IGithubGalleryCardInfo ComponentData
    {
        get => (IGithubGalleryCardInfo)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }

    public string RepositoryUrl
    {
        get => (string)GetValue(RepositoryUrlProperty);
        set => SetValue(RepositoryUrlProperty, value);
    }

    public string AuthorAvatar
    {
        get => (string)GetValue(AuthorAvatarProperty);
        set => SetValue(AuthorAvatarProperty, value);
    }
    public int Issues
    {
        get => (int)GetValue(IssuesCountProperty);
        set => SetValue(IssuesCountProperty, value);
    }

    public int Stars
    {
        get => (int)GetValue(StargazersCountProperty);
        set => SetValue(StargazersCountProperty, value);
    }

    public int Forks
    {
        get => (int)GetValue(ForksCountProperty);
        set => SetValue(ForksCountProperty, value);
    }

    public string License
    {
        get => (string)GetValue(LicenseProperty);
        set => SetValue(LicenseProperty, value);
    }
    public DateTime UpdateAt
    {
        get => (DateTime)GetValue(UpdateAtProperty);
        set => SetValue(UpdateAtProperty, value);
    }

    private List<PlatformInfo> supportedPlatformsInfo;
    public List<PlatformInfo> SupportedPlatformsInfo
    {
        get => supportedPlatformsInfo;
        set => GithubCardSetProperty(ref supportedPlatformsInfo, value);
    }
    #endregion

    #region [ Event Handlers ]
    private void Detail_Clicked(object sender, EventArgs e)
        => DetailClicked?.Invoke(ComponentData);

    private void DetailInNewWindow_Clicked(object sender, EventArgs e)
        => DetailInNewWindowClicked?.Invoke(ComponentData);

    private void RaiseGithubCardPropertyChanged(string propertyName)
        => GithubCardPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private void root_Loaded(object sender, EventArgs e)
        => SyncRepoAsync().FireAndForget();
    #endregion

    #region [ Generic Methods ]
    protected bool GithubCardSetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(property, value))
        {
            return false;
        }

        property = value;
        RaiseGithubCardPropertyChanged(propertyName);
        return true;
    }
    #endregion

    #region [ Methods ]
    public async Task SyncRepoAsync()
    {
        //var github = new GitHubClient(new ProductHeaderValue(ComponentData.RepositoryName));
        //var repository = await github.Repository.Get(ComponentData.AuthorName, ComponentData.RepositoryName);

        var syncService = ServiceHelper.GetService<IRepositorySyncService>();

        var repository = await syncService?.GetRepositoryAsync(ComponentData.AuthorName, ComponentData.RepositoryName, ComponentData.RepositoryName);

        if (repository == null) {
            return;
        }

        this.RepositoryUrl = repository.Url;
        this.AuthorAvatar = repository.Owner.AvatarUrl;
        this.Stars = repository.StargazersCount;
        this.Forks = repository.ForksCount;
        this.Issues = repository.OpenIssuesCount;
        this.License = "No License";
        if (repository.License != null) 
        {
            this.License = repository.License.Name;
        }
        this.UpdateAt = repository.UpdatedAt.UtcDateTime;
    }
    #endregion
}