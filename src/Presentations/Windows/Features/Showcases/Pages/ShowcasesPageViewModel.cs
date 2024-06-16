using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using MAUIsland.GitHubFeatures;
using SkiaSharp;

namespace MAUIsland.Showcases;

public partial class ShowcasesPageViewModel : NavigationAwareBaseViewModel
{
    #region [ Fields ]

    private readonly IGitHubService gitHubService;
    #endregion

    #region [ CTor ]

    public ShowcasesPageViewModel(IAppNavigator appNavigator,
                                  IGitHubService gitHubService) : base(appNavigator)
    {
        this.gitHubService = gitHubService;
    }

    #endregion

    #region [ Overrides ]

    protected override void OnInit(IDictionary<string, object> query)
    {
        LoadBooks();
        LoadDotNetMauiRepoInfoAsync().FireAndForget();
    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string sectionTitle1 = "Books";

    [ObservableProperty]
    List<Item> items = new();

    [ObservableProperty]
    bool isGitHubOpenIssuesChartLoading = false;

    [ObservableProperty]
    ISeries[] gitHubOpenIssuesChart = default!;

    [ObservableProperty]
    LabelVisual gitHubOpenIssuesChartTile =
    new LabelVisual
    {
        Text = ".NET MAUI Open Issues Last 7 Days",
        TextSize = 25,
        Padding = new LiveChartsCore.Drawing.Padding(15),
        Paint = new SolidColorPaint(SKColors.White)
    };

    [ObservableProperty]
    List<Axis> gitHubOpenIssuesChartXAxis = default!;

    [ObservableProperty]
    List<Axis> gitHubOpenIssuesChartYAxis = default!;

    [ObservableProperty]
    int issuesListCount;

    [ObservableProperty]
    string releaseInfo;

    [ObservableProperty]
    int closedIssuesListCount;

    [ObservableProperty]
    int androidIssuesCount;

    [ObservableProperty]
    int iosIssuesCount;

    [ObservableProperty]
    int windowsIssueCount;

    [ObservableProperty]
    int tizenIssuesCount;

    [ObservableProperty]
    List<BookItem> items2 = new();

    [ObservableProperty]
    BookItem selectedItem2 = default!;

    [ObservableProperty]
    List<Item> items3 = new();

    [ObservableProperty]
    List<Item> items6 = new();
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion

    #region [ Methods ]

    async Task LoadDotNetMauiRepoInfoAsync()
    {
        IsGitHubOpenIssuesChartLoading = true;

        string repositoryAuthor = "dotnet";
        string repositoryName = "maui";

        var openIssues = await gitHubService.GetGitHubIssues(repositoryAuthor, repositoryName);

        if (openIssues.IsT1)
            return;

        var latestRelease = await gitHubService.GetLatestRelease(repositoryAuthor, repositoryName);

        if (openIssues.IsT1)
            return;

        var issuesList = openIssues.AsT0.AttachedData as IEnumerable<GitHubIssueModel>;


        IssuesListCount = issuesList.Count();
        AndroidIssuesCount = issuesList.Count(issue => issue.Labels.Any(label => label.Name.Equals("platform/android 🤖", StringComparison.OrdinalIgnoreCase)));
        IosIssuesCount = issuesList.Count(issue => issue.Labels.Any(label => label.Name.Equals("platform/iOS 🍎", StringComparison.OrdinalIgnoreCase)));
        WindowsIssueCount = issuesList.Count(issue => issue.Labels.Any(label => label.Name.Equals("platform/windows 🪟", StringComparison.OrdinalIgnoreCase)));
        TizenIssuesCount = issuesList.Count(issue => issue.Labels.Any(label => label.Name.Equals("platform/tizen", StringComparison.OrdinalIgnoreCase)));

        IsGitHubOpenIssuesChartLoading = false;
        if (issuesList == null || !issuesList.Any())
            return;

        var dates = Enumerable.Range(0, 7)
                      .Select(i => DateTimeOffset.Now.Date.AddDays(-i))
                      .Reverse()
                      .ToList();

        var openIssuesCount = dates.Select(date =>
        {
            return issuesList.Count(issue =>
                issue.IsOpen && issue.CreatedAt.Date == date.Date);
        }).ToList();

        GitHubOpenIssuesChart = new[]{
            new LineSeries<int>
            {
                Values = new ObservableCollection<int>(openIssuesCount),
                Fill = null
            }
        };

        GitHubOpenIssuesChartXAxis = new List<Axis>()
        {
            new Axis
            {
                Name = "Date",
                NamePaint = new SolidColorPaint(SKColors.White),
                Labels = dates.Select(d => d.ToString("MM-dd")).ToArray(),
                LabelsPaint = new SolidColorPaint(SKColors.White)
            }
        };

        GitHubOpenIssuesChartYAxis = new List<Axis>()
        {
            new Axis
            {
                Name = "Open Issues",
                NamePaint = new SolidColorPaint(SKColors.White),
                LabelsPaint = new SolidColorPaint(SKColors.White)
            }
        };

        var releaseInfo = latestRelease.AsT0.AttachedData as GitHubRepositoryReleaseModel;

        ReleaseInfo = releaseInfo.Name;
    }

    Task LoadBooks()
    {
        Items2.Add(new BookItem
        {
            Name = ".NET MAUI in Action",
            Url = "https://www.manning.com/books/dot-net-maui-in-action",
            Description = ".NET MAUI in Action shows you how you can use the cutting-edge MAUI framework to write apps that will run on Windows, Android, macOS, and iOS platforms using your existing .NET development skills. This book reveals essential MAUI development techniques through hands-on example applications in every chapter.",
            Type = ItemType.Book,
            CoverImage = "dotnet_maui_in_action.png"
        });

        Items2.Add(new BookItem
        {
            Name = ".NET MAUI for C# Developers: Build cross-platform mobile and desktop applications",
            Url = "https://www.amazon.com/NET-MAUI-Developers-cross-platform-applications-ebook/dp/B0BX3R3W9V",
            Description = "The book starts with the fundamentals and quickly moves on to intermediate and advanced topics on laying out your pages, navigating between them, and adding controls to gather and display data. You'll explore the key architectural pattern of Model-View-ViewModel: and ways to leverage it. You'll also use xUnit and NSubstitute to create robust and reliable code.",
            Type = ItemType.Book,
            CoverImage = "dotnet_developers_cross_platform_applications_ebook.png"
        });

        Items2.Add(new BookItem
        {
            Name = "Enterprise Application Patterns using .NET MAUI",
            Url = "https://dotnet.microsoft.com/en-us/download/e-book/maui/pdf",
            Description = "This book is for .NET MAUI developers that are already familiar with the framework, but that are looking for guidance on architecture and implementation when building enterprise applications. This book can help developers solve common problems using tried and true patterns.",
            Type = ItemType.Book,
            CoverImage = "enterprise_app_patterns_ebook.png"
        });
        return Task.CompletedTask;
    }

    Task LoadSamples()
    {
        Items3.Add(new Item
        {
            Name = "Official .NET MAUI Samples",
            Url = "https://github.com/dotnet/maui-samples",
            Description = "Official .NET MAUI Samples from the .NET MAUI Team!",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "Official Code Samples",
            Url = "https://docs.microsoft.com/samples/browse/?expanded=dotnet&products=dotnet-maui",
            Description = "Official .NET MAUI Code Samples from documentation and across official repos.",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = ".NET Podcasts",
            Url = "https://github.com/microsoft/dotnet-podcasts/",
            Description = ".NET Conf 2021 and Microsoft Build 2022 showcase app.",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "AStore App",
            Url = "https://github.com/akv3sic/MAUI-store-app",
            Description = "AStore is a simple e-commerce app built with .NET MAUI. Uses MVVM architecture. UI built with XAML.",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "BMI Calculator",
            Url = "https://github.com/naweed/MauiBMICalculator",
            Description = "A simple and gorgeous BMI Calculator built using .NET MAUI and Skia Sharp. Inspired by Dribble design.",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "HackerNews",
            Url = "https://github.com/brminnick/HackerNews",
            Description = "A .NET MAUI app for displaying the top posts on Hacker News that demonstrates text sentiment analysis gathered using artificial intelligence.",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "Maui Planets",
            Url = "https://github.com/naweed/MauiPlanets",
            Description = "Planets Mobile App UI built using .Net Maui. Implements the Dribbble design.",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "Maui Premier League",
            Url = "https://github.com/jameslee214/maui-premierleague",
            Description = ".NET Conf 2022 Korea by [.NET Dev](https://forum.dotnetdev.kr/t/maui-premier-league-app/4691) showcase app. CollectionView and simple UI design.",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "MauiSamples",
            Url = "https://github.com/VladislavAntonyuk/MauiSamples",
            Description = ".NET MAUI samples (.NET MAUI Paint, .NET MAUI Blazor Photo gallery, Kanban board and more).",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "MauiScientificCalculator",
            Url = "https://github.com/naweed/MauiScientificCalculator",
            Description = "A simple scientific calculator built using .NET MAUI.",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "Maui Tube Player",
            Url = "https://github.com/naweed/MauiTubePlayer",
            Description = "A REAL and BEAUTIFUL Youtube Clone app built using .Net Maui. Lots of features such as connecting to real Youtube API, Search and Playback functionality, Download Video for Offline Viewing and amazing UI design.",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "More .NET MAUI Samples",
            Url = "https://github.com/jsuarezruiz/dotnet-maui-samples",
            Description = ".NET MAUI samples.",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "MyFinance App",
            Url = "https://github.com/gonultasmf/MyFinance",
            Description = "It is a beautifully designed Finance application for .NET MAUI Markup(No XAML) enthusiasts. Made with FmgLib.MauiMarkup.",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "NightClub",
            Url = "https://github.com/Kapusch/blog-dotnet-maui/tree/main/Samples/NightClub",
            Description = "Build a highly colorful music application [step-by-step](https://www.mauicestclair.fr/en/posts/tutos/my-first-app/)! 💃🏾🕺🏻🪩 Uses C# Markup (i.e. no XAML), MVVM & MediaElement.",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "Sharing.WebBlazor.MauiHybrid",
            Url = "https://github.com/Hona/Sharing.WebBlazor.MauiHybrid",
            Description = "This repo is demoing how to code share pages, routes, component branding & most importantly authentication flow/authorization rules (with Auth0). For a web portal for browser access and a native iOS/Android mobile app using MAUI Hybrid",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "SOS App",
            Url = "https://github.com/adityaoberai/SOS-MAUI",
            Description = "A cross-platform app that allows the user to send an SOS message with their location to a saved phone number in times of distress. Uses Appwrite, Twilio, and Radar.",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "Soferity: Game Portal",
            Url = "https://github.com/Soferity/GamePortal",
            Description = "Soferity: Game Portal is a game hub. It allows you to have a fun and good time with the various Types of games it offers.",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "Swashbuckler Diary",
            Url = "https://github.com/Yu-Core/SwashbucklerDiary",
            Description = "An open source cross-platform local diary app using MAUI Blazor.",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "V2ex.MAUI",
            Url = "https://github.com/rwecho/V2ex.MAUI",
            Description = "A multi-platform, user-friendly, and feature-rich V2ex native application made by MAUI.",
            Type = ItemType.Sample
        });

        Items3.Add(new Item
        {
            Name = "WeatherTwentyOne",
            Url = "https://github.com/davidortinau/WeatherTwentyOne/",
            Description = "Microsoft Build 2021 showcase app.",
            Type = ItemType.Sample
        });

        return Task.CompletedTask;
    }

    Task LoadTools()
    {
        Items.Add(new Item
        {
            Name = ".NET MAUI Check tool",
            Url = "https://github.com/Redth/dotnet-maui-check",
            Description = "NET MAUI Check tool.",
            Type = ItemType.Tool
        });

        Items.Add(new Item
        {
            Name = ".NET MAUI UI Testing",
            Url = "https://github.com/Redth/Maui.UITesting",
            Description = "NET MAUI UI Testing tool.",
            Type = ItemType.Tool
        });

        Items.Add(new Item
        {
            Name = "DotNet.Meteor",
            Url = "https://github.com/JaneySprings/DotNet.Meteor",
            Description = ".NET Meteor allows you to build, debug .NET 6 / .NET 7 apps and deploy them to devices or emulators.",
            Type = ItemType.Tool
        });

        Items.Add(new Item
        {
            Name = "MAUI App Accelerator",
            Url = "https://github.com/mrlacey/MauiAppAccelerator",
            Description = "A Visual Studio extension to accelerate the creation of new .NET MAUI apps using a wizard-based UI.",
            Type = ItemType.Tool
        });

        Items.Add(new Item
        {
            Name = "MemoryToolkit.Maui",
            Url = "https://github.com/AdamEssenmacher/MemoryToolkit.Maui",
            Description = "A developer toolkit for detecting, diagnosing, and mitigating memory leaks in .NET MAUI applications.",
            Type = ItemType.Tool
        });

        Items.Add(new Item
        {
            Name = "Shiny Templates",
            Url = "https://github.com/shinyorg/templates",
            Description = "A dotnet new template for .NET MAUI that helps wireup over 60 community plugins and libraries.",
            Type = ItemType.Tool
        });

        return Task.CompletedTask;
    }

    Task LoadBlazors()
    {
        Items.Add(new Item
        {
            Name = "Bit Platform",
            Url = "https://github.com/bitfoundation/bitplatform",
            Description = "Ready to use project templates plus UI components focused on Blazor WASM/Hybrid(MAUI) that are extremely fast yet lightweight.",
            Type = ItemType.Blazor
        });

        Items.Add(new Item
        {
            Name = "BlazorBindings.Maui",
            Url = "https://github.com/Dreamescaper/BlazorBindings.Maui",
            Description = "Use Blazor syntax to build native MAUI applications.",
            Type = ItemType.Blazor
        });

        Items.Add(new Item
        {
            Name = "BlazorUI",
            Url = "https://github.com/StoicDreams/BlazorUI",
            Description = "UI Framework and component library for Blazor based Websites and Maui projects.",
            Type = ItemType.Blazor
        });

        Items.Add(new Item
        {
            Name = "Cropper.Blazor",
            Url = "https://github.com/CropperBlazor/Cropper.Blazor",
            Description = "Cropper.Blazor is a component that wraps around Cropper.js for cropping images in Blazor. Support Blazor Server, Blazor WebAssembly, Blazor Server Hybrid with MVC and MAUI Blazor Hybrid.",
            Type = ItemType.Blazor
        });

        Items.Add(new Item
        {
            Name = "MASA.Blazor",
            Url = "https://github.com/BlazorComponent/MASA.Blazor",
            Description = "Blazor component library based on Material Design. Support Blazor Server and Blazor WebAssembly.",
            Type = ItemType.Blazor
        });

        Items.Add(new Item
        {
            Name = "Radzen.Blazor",
            Url = "https://github.com/radzenhq/radzen-blazor",
            Description = "Robust Blazor component library supporting WASM and Server and multiple themes. Also available is a WYSIWYG desktop application (Radzen Blazor Studio) with auto-CRUD builders. Freemium options for additional themes and functionality.",
            Type = ItemType.Blazor
        });

        Items.Add(new Item
        {
            Name = "Taiizor.Essentials.Blazor",
            Url = "https://github.com/Taiizor/Taiizor.Essentials.Blazor",
            Description = "Taiizor.Essentials.Blazor is an essentials library for projects using .NET Blazor. It provides convenience with various functions it offers.",
            Type = ItemType.Blazor
        });

        return Task.CompletedTask;
    }
    #endregion
}