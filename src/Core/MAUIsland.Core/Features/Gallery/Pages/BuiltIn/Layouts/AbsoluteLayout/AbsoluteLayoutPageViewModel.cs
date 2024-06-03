using DiscordRPC;
using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland.Core;
public partial class AbsoluteLayoutPageViewModel : BaseBuiltInPageControlViewModel
{
    #region [ Fields ]

    #endregion

    #region [ CTor ]
    public AbsoluteLayoutPageViewModel(IAppNavigator appNavigator,
                                       IGitHubService gitHubService,
                                       DiscordRpcClient discordRpcClient,
                                       IGitHubIssueLocalDbService gitHubIssueLocalDbService)
                                        : base(appNavigator,
                                                gitHubService,
                                                discordRpcClient,
                                                gitHubIssueLocalDbService)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    string srpLink = "https://learn.microsoft.com/en-us/archive/msdn-magazine/2014/may/csharp-best-practices-dangers-of-violating-solid-principles-in-csharp#the-single-responsibility-principle";

    [ObservableProperty]
    string ocpLink = "https://learn.microsoft.com/en-us/archive/msdn-magazine/2014/may/csharp-best-practices-dangers-of-violating-solid-principles-in-csharp#the-open-closed-principle";

    [ObservableProperty]
    string lspLink = "https://learn.microsoft.com/en-us/archive/msdn-magazine/2014/may/csharp-best-practices-dangers-of-violating-solid-principles-in-csharp#the-liskov-substitution-principle";

    [ObservableProperty]
    string ispLink = "https://learn.microsoft.com/en-us/archive/msdn-magazine/2014/may/csharp-best-practices-dangers-of-violating-solid-principles-in-csharp#the-interface-segregation-principle";

    [ObservableProperty]
    string dipLink = "https://learn.microsoft.com/en-us/archive/msdn-magazine/2014/may/csharp-best-practices-dangers-of-violating-solid-principles-in-csharp#the-dependency-inversion-principle";

    [ObservableProperty]
    string mvcminimalAPIsLink = "https://learn.microsoft.com/en-us/aspnet/core/fundamentals/apis?view=aspnetcore-8.0";

    [ObservableProperty]
    string positionAndSizeChildren = "The position and size of children in an AbsoluteLayout is defined by setting the AbsoluteLayout.LayoutBounds attached property of each child, using absolute values or proportional values. Absolute and proportional values can be mixed for children when the position should scale, but the size should stay fixed, or vice versa. For information about absolute values, see Absolute positioning and sizing. For information about proportional values, see Proportional positioning and sizing.";

    [ObservableProperty]
    string positionAndSizeChildren1 = "The AbsoluteLayout.LayoutBounds attached property can be set using two formats, regardless of whether absolute or proportional values are used:";

    [ObservableProperty]
    string positionAndSizeChildren2 = "To specify that a child sizes itself horizontally or vertically, or both, set the width and/or height values to the AbsoluteLayout.AutoSize property. However, overuse of this property can harm application performance, as it causes the layout engine to perform additional layout calculations.";

    [ObservableProperty]
    string positionAndSizeChildrenImportant = "The HorizontalOptions and VerticalOptions properties have no effect on children of an AbsoluteLayout.";

    [ObservableProperty]
    List<string> positionAndSizeChildrenList = new()
    {
        "x, y. With this format, the x and y values indicate the position of the upper-left corner of the child relative to its parent. The child is unconstrained and sizes itself.",
        "x, y, width, height. With this format, the x and y values indicate the position of the upper-left corner of the child relative to its parent, while the width and height values indicate the child's size."
    };

    [ObservableProperty]
    string absolutePositioningAndSizing = "By default, an AbsoluteLayout positions and sizes children using absolute values, specified in device-independent units, which explicitly define where children should be placed in the layout. This is achieved by adding children to an AbsoluteLayout and setting the AbsoluteLayout.LayoutBounds attached property on each child to absolute position and/or size values.";

    [ObservableProperty]
    string absolutePositioningAndSizingWarning = "Using absolute values for positioning and sizing children can be problematic, because different devices have different screen sizes and resolutions. Therefore, the coordinates for the center of the screen on one device may be offset on other devices.";

    [ObservableProperty]
    string absolutePositioningAndSizing1 = "The following XAML shows an AbsoluteLayout whose children are positioned using absolute values:";

    [ObservableProperty]
    string absolutePositioningAndSizing2 = "In this example, the position of each BoxView object is defined using the first two absolute values that are specified in the AbsoluteLayout.LayoutBounds attached property. The size of each BoxView is defined using the third and forth values. The position of the Label object is defined using the two absolute values that are specified in the AbsoluteLayout.LayoutBounds attached property. Size values are not specified for the Label, and so it's unconstrained and sizes itself. In all cases, the absolute values represent device-independent units.";

    [ObservableProperty]
    string absolutePositioningAndSizing3 = "The equivalent C# code is shown below:";

    [ObservableProperty]
    string absolutePositioningAndSizing4 = "In this example, the position and size of each BoxView is defined using a Rect object. The position of the Label is defined using a Point object. The C# example uses the following Add extension methods to add children to the AbsoluteLayout:";

    [ObservableProperty]
    string absolutePositioningAndSizing5 = "In C#, it's also possible to set the position and size of a child of an AbsoluteLayout after it has been added to the layout, using the <span style=\"color:red;\"><strong>AbsoluteLayout.SetLayoutBounds</strong></span> method. The first argument to this method is the child, and the second is a <span style=\"color:red;\"><strong>Rect</strong></span> object.";

    [ObservableProperty]
    string absolutePositioningAndSizingNote = "An AbsoluteLayout that uses absolute values can position and size children so that they don't fit within the bounds of the layout.";

    [ObservableProperty]
    string absolutePositioningAndSizingXamlCode =
    "<ContentPage xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
    "             xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
    "             x:Class=\"AbsoluteLayoutDemos.Views.XAML.StylishHeaderDemoPage\"\r\n" +
    "             Title=\"Stylish header demo\">\r\n" +
    "    <AbsoluteLayout Margin=\"20\">\r\n" +
    "        <BoxView Color=\"Silver\"\r\n" +
    "                 AbsoluteLayout.LayoutBounds=\"0, 10, 200, 5\" />\r\n" +
    "        <BoxView Color=\"Silver\"\r\n" +
    "                 AbsoluteLayout.LayoutBounds=\"0, 20, 200, 5\" />\r\n" +
    "        <BoxView Color=\"Silver\"\r\n" +
    "                 AbsoluteLayout.LayoutBounds=\"10, 0, 5, 65\" />\r\n" +
    "        <BoxView Color=\"Silver\"\r\n" +
    "                 AbsoluteLayout.LayoutBounds=\"20, 0, 5, 65\" />\r\n" +
    "        <Label Text=\"Stylish Header\"\r\n" +
    "               FontSize=\"24\"\r\n" +
    "               AbsoluteLayout.LayoutBounds=\"30, 25\" />\r\n" +
    "    </AbsoluteLayout>\r\n" +
    "</ContentPage>";

    [ObservableProperty]
    string absolutePositioningAndSizingCSharpCode =
    "public class StylishHeaderDemoPage : ContentPage\r\n" +
    "{\r\n" +
    "    public StylishHeaderDemoPage()\r\n" +
    "    {\r\n" +
    "        AbsoluteLayout absoluteLayout = new AbsoluteLayout\r\n" +
    "        {\r\n" +
    "            Margin = new Thickness(20)\r\n" +
    "        };\r\n" +
    "\r\n" +
    "        absoluteLayout.Add(new BoxView\r\n" +
    "        {\r\n" +
    "            Color = Colors.Silver\r\n" +
    "        }, new Rect(0, 10, 200, 5));\r\n" +
    "        absoluteLayout.Add(new BoxView\r\n" +
    "        {\r\n" +
    "            Color = Colors.Silver\r\n" +
    "        }, new Rect(0, 20, 200, 5));\r\n" +
    "        absoluteLayout.Add(new BoxView\r\n" +
    "        {\r\n" +
    "            Color = Colors.Silver\r\n" +
    "        }, new Rect(10, 0, 5, 65));\r\n" +
    "        absoluteLayout.Add(new BoxView\r\n" +
    "        {\r\n" +
    "            Color = Colors.Silver\r\n" +
    "        }, new Rect(20, 0, 5, 65));\r\n" +
    "\r\n" +
    "        absoluteLayout.Add(new Label\r\n" +
    "        {\r\n" +
    "            Text = \"Stylish Header\",\r\n" +
    "            FontSize = 24\r\n" +
    "        }, new Point(30, 25));\r\n" +
    "\r\n" +
    "        Title = \"Stylish header demo\";\r\n" +
    "        Content = absoluteLayout;\r\n" +
    "    }\r\n" +
    "}";

    [ObservableProperty]
    string absolutePositioningAndSizingCSharpCode1 =
    "using Microsoft.Maui.Layouts;\r\n" +
    "\r\n" +
    "namespace Microsoft.Maui.Controls\r\n" +
    "{\r\n" +
    "    public static class AbsoluteLayoutExtensions\r\n" +
    "    {\r\n" +
    "        public static void Add(this AbsoluteLayout absoluteLayout, IView view, Rect bounds, AbsoluteLayoutFlags flags = AbsoluteLayoutFlags.None)\r\n" +
    "        {\r\n" +
    "            if (view == null)\r\n" +
    "                throw new ArgumentNullException(nameof(view));\r\n" +
    "            if (bounds.IsEmpty)\r\n" +
    "                throw new ArgumentNullException(nameof(bounds));\r\n" +
    "\r\n" +
    "            absoluteLayout.Add(view);\r\n" +
    "            absoluteLayout.SetLayoutBounds(view, bounds);\r\n" +
    "            absoluteLayout.SetLayoutFlags(view, flags);\r\n" +
    "        }\r\n" +
    "\r\n" +
    "        public static void Add(this AbsoluteLayout absoluteLayout, IView view, Point position)\r\n" +
    "        {\r\n" +
    "            if (view == null)\r\n" +
    "                throw new ArgumentNullException(nameof(view));\r\n" +
    "            if (position.IsEmpty)\r\n" +
    "                throw new ArgumentNullException(nameof(position));\r\n" +
    "\r\n" +
    "            absoluteLayout.Add(view);\r\n" +
    "            absoluteLayout.SetLayoutBounds(view, new Rect(position.X, position.Y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));\r\n" +
    "        }\r\n" +
    "    }\r\n" +
    "}";

    [ObservableProperty]
    string proportionalPositioningAndSizingHeader = "Proportional positioning and sizing";

    [ObservableProperty]
    string proportionalPositioningAndSizing = "An AbsoluteLayout can position and size children using proportional values. This is achieved by adding children to the AbsoluteLayout and by setting the <span style=\"color:red;\"><strong>AbsoluteLayout.LayoutBounds</strong></span> attached property on each child to proportional position and/or size values in the range 0-1. Position and size values are made proportional by setting the <span style=\"color:red;\"><strong>AbsoluteLayout.LayoutFlags</strong></span> attached property on each child.";

    [ObservableProperty]
    string proportionalPositioningAndSizing1 = "The <span style=\"color:red;\"><strong>AbsoluteLayout.LayoutFlags</strong></span> attached property, of type <span style=\"color:red;\"><strong>AbsoluteLayoutFlags</strong></span>, allows you to set a flag that indicates that the layout bounds position and size values for a child are proportional to the size of the AbsoluteLayout. When laying out a child, AbsoluteLayout scales the position and size values appropriately, to any device size.";

    [ObservableProperty]
    string proportionalPositioningAndSizing2 = "The <span style=\"color:red;\"><strong>AbsoluteLayoutFlags</strong></span> enumeration defines the following members:";

    [ObservableProperty]
    List<string> proportionalPositioningAndSizingList = new()
    {
        "<span style=\"color:red;\"><strong>None</strong></span>, indicates that values will be interpreted as absolute. This is the default value of the <span style=\"color:red;\"><strong>AbsoluteLayout.LayoutFlags</strong></span> attached property.",
        "<span style=\"color:red;\"><strong>XProportional</strong></span>, indicates that the <span style=\"color:red;\"><strong>x</strong></span> value will be interpreted as proportional, while treating all other values as absolute.",
        "<span style=\"color:red;\"><strong>YProportional</strong></span>, indicates that the <span style=\"color:red;\"><strong>y</strong></span> value will be interpreted as proportional, while treating all other values as absolute.",
        "<span style=\"color:red;\"><strong>WidthProportional</strong></span>, indicates that the <span style=\"color:red;\"><strong>width</strong></span> value will be interpreted as proportional, while treating all other values as absolute.",
        "<span style=\"color:red;\"><strong>HeightProportional</strong></span>, indicates that the <span style=\"color:red;\"><strong>height</strong></span> value will be interpreted as proportional, while treating all other values as absolute.",
        "<span style=\"color:red;\"><strong>PositionProportional</strong></span>, indicates that the <span style=\"color:red;\"><strong>x</strong></span> and <span style=\"color:red;\"><strong>y</strong></span> values will be interpreted as proportional, while the size values are interpreted as absolute.",
        "<span style=\"color:red;\"><strong>SizeProportional</strong></span>, indicates that the <span style=\"color:red;\"><strong>width</strong></span> and <span style=\"color:red;\"><strong>height</strong></span> values will be interpreted as proportional, while the position values are interpreted as absolute.",
        "<span style=\"color:red;\"><strong>All</strong></span>, indicates that all values will be interpreted as proportional."

    };

    [ObservableProperty]
    string proportionalPositioningAndSizingTip = "The <span style=\"color:red;\"><strong>AbsoluteLayoutFlags</strong></span> enumeration is a <span style=\"color:red;\"><strong>Flags</strong></span> enumeration, which means that enumeration members can be combined. This is accomplished in XAML with a comma-separated list, and in C# with the bitwise OR operator.";

    [ObservableProperty]
    string proportionalPositioningAndSizing3 = "For example, if you use the <span style=\"color:red;\"><strong><a href=\"https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.absolutelayout?view=net-maui-8.0\" target=\"_blank\">SizeProportional</a></strong></span> flag and set the width of a child to 0.25 and the height to 0.1, the child will be one-quarter of the width of the <a href=\"https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.absolutelayout?view=net-maui-8.0\" target=\"_blank\">AbsoluteLayout</a> and one-tenth the height. The <span style=\"color:red;\"><strong>PositionProportional</strong></span> flag is similar. A position of (0,0) puts the child in the upper-left corner, while a position of (1,1) puts the child in the lower-right corner, and a position of (0.5,0.5) centers the child within the <a href=\"https://learn.microsoft.com/en-us/dotnet/api/microsoft.maui.controls.absolutelayout?view=net-maui-8.0\" target=\"_blank\">AbsoluteLayout</a>.\r\n";

    [ObservableProperty]
    string proportionalPositioningAndSizing4 = "The following XAML shows an AbsoluteLayout whose children are positioned using proportional values:";

    [ObservableProperty]
    string proportionalPositioningAndSizingXamlCode =
    "<ContentPage xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
    "             xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
    "             x:Class=\"AbsoluteLayoutDemos.Views.XAML.ProportionalDemoPage\"\r\n" +
    "             Title=\"Proportional demo\">\r\n" +
    "    <AbsoluteLayout>\r\n" +
    "        <BoxView Color=\"Blue\"\r\n" +
    "                 AbsoluteLayout.LayoutBounds=\"0.5,0,100,25\"\r\n" +
    "                 AbsoluteLayout.LayoutFlags=\"PositionProportional\" />\r\n" +
    "        <BoxView Color=\"Green\"\r\n" +
    "                 AbsoluteLayout.LayoutBounds=\"0,0.5,25,100\"\r\n" +
    "                 AbsoluteLayout.LayoutFlags=\"PositionProportional\" />\r\n" +
    "        <BoxView Color=\"Red\"\r\n" +
    "                 AbsoluteLayout.LayoutBounds=\"1,0.5,25,100\"\r\n" +
    "                 AbsoluteLayout.LayoutFlags=\"PositionProportional\" />\r\n" +
    "        <BoxView Color=\"Black\"\r\n" +
    "                 AbsoluteLayout.LayoutBounds=\"0.5,1,100,25\"\r\n" +
    "                 AbsoluteLayout.LayoutFlags=\"PositionProportional\" />\r\n" +
    "        <Label Text=\"Centered text\"\r\n" +
    "               AbsoluteLayout.LayoutBounds=\"0.5,0.5,110,25\"\r\n" +
    "               AbsoluteLayout.LayoutFlags=\"PositionProportional\" />\r\n" +
    "    </AbsoluteLayout>\r\n" +
    "</ContentPage>";

    [ObservableProperty]
    string proportionalPositioningAndSizing5 = "In this example, each child is positioned using proportional values but sized using absolute values. This is accomplished by setting the <span style=\"color:red;\"><strong>AbsoluteLayout.LayoutFlags</strong></span> attached property of each child to <span style=\"color:red;\"><strong>PositionProportional</strong></span>. The first two values that are specified in the <span style=\"color:red;\"><strong>AbsoluteLayout.LayoutBounds</strong></span> attached property, for each child, define the position using proportional values. The size of each child is defined with the third and forth absolute values, using device-independent units.";

    [ObservableProperty]
    string proportionalPositioningAndSizing6 = "The equivalent C# code is shown below:";

    [ObservableProperty]
    string proportionalPositioningAndSizingCSharpCode =
        "public class ProportionalDemoPage : ContentPage\r\n" +
        "{\r\n" +
        "    public ProportionalDemoPage()\r\n" +
        "    {\r\n" +
        "        BoxView blue = new BoxView { Color = Colors.Blue };\r\n" +
        "        AbsoluteLayout.SetLayoutBounds(blue, new Rect(0.5, 0, 100, 25));\r\n" +
        "        AbsoluteLayout.SetLayoutFlags(blue, AbsoluteLayoutFlags.PositionProportional);\r\n" +
        "\r\n" +
        "        BoxView green = new BoxView { Color = Colors.Green };\r\n" +
        "        AbsoluteLayout.SetLayoutBounds(green, new Rect(0, 0.5, 25, 100));\r\n" +
        "        AbsoluteLayout.SetLayoutFlags(green, AbsoluteLayoutFlags.PositionProportional);\r\n" +
        "\r\n" +
        "        BoxView red = new BoxView { Color = Colors.Red };\r\n" +
        "        AbsoluteLayout.SetLayoutBounds(red, new Rect(1, 0.5, 25, 100));\r\n" +
        "        AbsoluteLayout.SetLayoutFlags(red, AbsoluteLayoutFlags.PositionProportional);\r\n" +
        "\r\n" +
        "        BoxView black = new BoxView { Color = Colors.Black };\r\n" +
        "        AbsoluteLayout.SetLayoutBounds(black, new Rect(0.5, 1, 100, 25));\r\n" +
        "        AbsoluteLayout.SetLayoutFlags(black, AbsoluteLayoutFlags.PositionProportional);\r\n" +
        "\r\n" +
        "        Label label = new Label { Text = \"Centered text\" };\r\n" +
        "        AbsoluteLayout.SetLayoutBounds(label, new Rect(0.5, 0.5, 110, 25));\r\n" +
        "        AbsoluteLayout.SetLayoutFlags(label, AbsoluteLayoutFlags.PositionProportional);\r\n" +
        "\r\n" +
        "        Title = \"Proportional demo\";\r\n" +
        "        Content = new AbsoluteLayout\r\n" +
        "        {\r\n" +
        "            Children = { blue, green, red, black, label }\r\n" +
        "        };\r\n" +
        "    }\r\n" +
        "}";

    [ObservableProperty]
    string proportionalPositioningAndSizing7 = "In this example, the position and size of each child is set with the <span style=\"color:red;\"><strong>AbsoluteLayout.SetLayoutBounds</strong></span> method. The first argument to the method is the child, and the second is a <span style=\"color:red;\"><strong>Rect</strong></span> object. The position of each child is set with proportional values, while the size of each child is set with absolute values, using device-independent units.";

    [ObservableProperty]
    string proportionalPositioningAndSizingNote = "An <span style=\"color:red;\"><strong>AbsoluteLayout</strong></span> that uses proportional values can position and size children so that they don't fit within the bounds of the layout by using values outside the 0-1 range.";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IBuiltInGalleryCardInfo>();

    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();
        await RefreshAsync();
    }
    #endregion

    #region [ Relay Commands ]

    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    async Task RefreshAsync()
    {
        if (ControlInformation is null)
            return;

        await RefreshControlIssues(true,
                                   ControlInformation.ControlName,
                                   ControlInformation.GitHubAuthorIssueName,
                                   ControlInformation.GitHubRepositoryIssueName,
                                   ControlInformation.GitHubIssueLabels);
    }
    #endregion
}