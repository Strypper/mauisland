namespace MAUIsland;

public class ControlsService : IControlsService
{
    private readonly IControlInfo[] controlInfos;

    #region [CTor]
    public ControlsService(IEnumerable<IControlInfo> controlInfos)
    {
        this.controlInfos = controlInfos.ToArray();
    }
    #endregion

    private readonly IList<ControlGroupInfo> controlGroupInfos = new List<ControlGroupInfo>()
    {
        new (){
            Name = ControlGroupInfo.SyncfusionControls,
            Title = "Syncfusion",
            Version = "22.1.36",
            BrandColor = Color.FromArgb("#ff8900"),
            ButtonTextColor = Colors.White,
            IconUrl = "syncfusionlogo.png",
            Author = "Syncfusion Inc.",
            Banner = "syncfusion_banner.png",
            ProviderUrl = "https://help.syncfusion.com/maui/introduction/overview",
            MicrosoftStoreLink="https://www.microsoft.com/store/productId/9P2P4D2BK270",
            Description = "Syncfusion is a company that provides a set of controls for creating beautiful cross-platform, native mobile & desktop apps using .NET Multi-platform App UI (.NET MAUI). They offer a comprehensive collection of .NET MAUI components such as Charts, Gauge, and Tab View. You can add Syncfusion .NET MAUI components to your project by installing them from nuget.org. They also have a Visual Studio extension designed to streamline the creation of .NET MAUI applications."
        },
        new (){
            Name = ControlGroupInfo.DevExpressControls,
            Title = "DevExpress",
            Version = "None",
            BrandColor = Color.FromArgb("#4a4a4a"),
            ButtonTextColor = Colors.White,
            IconUrl = "devexpress_logo.png",
            Author = "DevExpress Inc.",
            Banner = "devexpress_banner.jpg",
            ProviderUrl = "https://help.syncfusion.com/maui/introduction/overview",
            MicrosoftStoreLink="https://www.microsoft.com/store/productId/9P2P4D2BK270",
            Description = "DevExpress is a company that provides a set of high-performance UI components for Android and iOS mobile development using .NET Multi-platform App UI (.NET MAUI). Their .NET MAUI component library includes a Data Grid, Chart, Scheduler, Data Editors, CollectionView, and Tabs components. All DevExpress .NET MAUI controls are available free-of-charge. You can reserve your free copy by registering on their website. Most DevExpress components for Xamarin.Forms have counterparts in .NET MAUI"
        },
        new (){
            Name = ControlGroupInfo.BuiltInControls,
            Title = "Built-in",
            Version = "7.0",
            BrandColor = Color.FromArgb("#ac99ea"),
            ButtonTextColor = Color.FromArgb("#242424"),
            LottieUrl = "island.json",
            Author = "Microsoft",
            Banner = "builtin_banner.png",
            ProviderUrl = "https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui?view=net-maui-7.0",
            Description = ".NET Multi-platform App UI (.NET MAUI) apps use objects that map to the native controls of each target platform to construct the user interface. The main control groups used are pages, layouts, and views. Pages generally occupy the full screen or window and usually contain a layout, which contains views and possibly other layouts. Some of the built-in pages in .NET MAUI include ContentPage, FlyoutPage, NavigationPage, and TabbedPage. Some of the built-in layouts include AbsoluteLayout, BindableLayout, FlexLayout, Grid, and StackLayout. Control templates enable the definition of the visual structure of custom controls and pages."
        },
        new (){
            Name = ControlGroupInfo.CommunityToolkit,
            Title = "Toolkit",
            Version = "5.2.0",
            BrandColor = Color.FromArgb("#000000"),
            ButtonTextColor = Colors.White,
            IconUrl = "communitytoolkitlogo.png",
            Author = "Microsoft",
            Banner = "mauitoolkit_banner.png",
            ProviderUrl = "https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/",
            Description = "The .NET MAUI Community Toolkit is a collection of reusable elements for application development with .NET MAUI, including animations, behaviors, converters, effects, and helpers. It simplifies and demonstrates common developer tasks when building iOS, Android, macOS and WinUI applications using .NET MAUI 1. The toolkit is available as a set of NuGet Packages for new or existing .NET MAUI projects. It is built as a set of open source projects hosted on GitHub by the community."
        },
        new (){
            Name = ControlGroupInfo.GitHubCommunity,
            Title = "Community",
            Version= "None",
            BrandColor = Color.FromArgb("#000000"),
            ButtonTextColor = Colors.White,
            IconUrl = "githublogo.png",
            Author = "Community",
            Banner = "github_banner.png",
            ProviderUrl = "https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/",
            Description = "Explore what the community is building with .NET MAUI. We collect a wide range of repositories and gather them here for you to easily explore and experiment with a variety of controls and capabilities, all in one convenient location. Whether you’re looking to build a new app from scratch or enhance an existing project"
        },
        new() {
            Name = ControlGroupInfo.MaterialComponent,
            Title = "Material",
            Version = "0.1.2-beta",
            BrandColor = Color.FromArgb("#8674b6"),
            ButtonTextColor = Colors.White,
            IconUrl = "materialuilogo.png",
            Author = "yiszza",
            Banner = "materialui_banner.png",
            ProviderUrl = "https://mdc-maui.github.io/",
            Description = "Material design components for .NET MAUI"
        }
    };

    public Task<IEnumerable<ControlGroupInfo>> GetControlGroupsAsync()
    {
        return Task.Run(() =>
        {
            return (IEnumerable<ControlGroupInfo>)controlGroupInfos;
        });
    }

    public Task<IEnumerable<IControlInfo>> GetControlsAsync(string groupName)
    {
        return Task.Run(() =>
        {
            IEnumerable<IControlInfo> result = controlInfos
                .Where(x => x.GroupName == groupName);

            return string.IsNullOrWhiteSpace(groupName)
                    ? controlInfos
                    : controlInfos
                        .Where(x => x.GroupName == groupName);
        });
    }

    public Task<IControlInfo> GetControlByNameAsync(string groupName, string controlName)
    {

        return Task.Run(() =>
        {
            IEnumerable<IControlInfo> result = controlInfos
                .Where(x => x.GroupName == groupName);

            return controlInfos
                        .Where(x => x.GroupName == groupName
                                 && x.ControlName == controlName)
                        .FirstOrDefault();
        });
    }
}
