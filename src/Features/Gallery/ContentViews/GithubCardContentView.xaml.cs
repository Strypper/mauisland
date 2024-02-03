using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUIsland;

public partial class GithubCardContentView : ContentView, INotifyPropertyChanged
{
    #region [Field]
    public string repositoryUrl;
    string repositoryName;
    string authorName;
    string authorUrl;
    string authorAvatar;
    int stars;
    int forks;
    int issues;
    string license;
    List<PlatformInfo> supportedPlatformsInfo;
    #endregion

    #region [CTor]
    public GithubCardContentView()
    {
        InitializeComponent();
    }
    #endregion

    #region [Delegates]
    public delegate void DetailEventHandler(IGithubGalleryCardInfo control);

    public delegate void DetailInNewWindowEventHandler(IGithubGalleryCardInfo control);
    #endregion

    #region [ Events ]
    public event DetailEventHandler DetailClicked;

    public event DetailInNewWindowEventHandler DetailInNewWindowClicked;

    public event PropertyChangedEventHandler GithubCardPropertyChanged;
    #endregion

    #region [Bindable Properties]
    public static readonly BindableProperty ComponentDataProperty = BindableProperty.Create(
        nameof(ComponentData),
        typeof(IGithubGalleryCardInfo),
        typeof(GithubCardContentView),
        default(IGithubGalleryCardInfo)
    );

    public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    #endregion

    #region [Properties]
    public IGithubGalleryCardInfo ComponentData
    {
        get => (IGithubGalleryCardInfo)GetValue(ComponentDataProperty);
        set => SetValue(ComponentDataProperty, value);
    }

    public string RepositoryName
    {
        get => repositoryName;
        set => GithubCardSetProperty(ref repositoryName, value);
    }

    public string RepositoryUrl
    {
        get => repositoryUrl;
        set => GithubCardSetProperty(ref repositoryUrl, value);
    }
    string AuthorName
    {
        get => authorName;
        set => GithubCardSetProperty(ref authorName, value);
    }

    string AuthorUrl
    {
        get => authorUrl;
        set => GithubCardSetProperty(ref authorUrl, value);
    }

    string AuthorAvatar
    {
        get => authorAvatar;
        set => GithubCardSetProperty(ref authorAvatar, value);
    }

    int Stars
    {
        get => stars;
        set => GithubCardSetProperty(ref stars, value);
    }

    int Forks
    {
        get => forks;
        set => GithubCardSetProperty(ref forks, value);
    }

    int Issues
    {
        get => issues;
        set => GithubCardSetProperty(ref issues, value);
    }

    string License
    {
        get => license;
        set => GithubCardSetProperty(ref license, value);
    }

    List<PlatformInfo> SupportedPlatformsInfo
    {
        get => supportedPlatformsInfo;
        set => GithubCardSetProperty(ref supportedPlatformsInfo, value);
    }
    #endregion

    #region [Event Handlers]
    private void Detail_Clicked(object sender, EventArgs e)
    {
        DetailClicked?.Invoke(ComponentData);
    }

    private void DetailInNewWindow_Clicked(object sender, EventArgs e)
    {
        DetailInNewWindowClicked?.Invoke(ComponentData);
    }

    private void RaiseGithubCardPropertyChanged(string propertyName)
        => GithubCardPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    #endregion

    #region [Generic Methods]
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
}