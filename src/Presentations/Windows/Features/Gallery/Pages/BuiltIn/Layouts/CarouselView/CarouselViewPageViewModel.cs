using MAUIsland.Features.LocalDbFeatures.GitHub;
using MAUIsland.GitHubFeatures;

namespace MAUIsland;

public partial class CarouselViewPageViewModel : BaseBuiltInPageControlViewModel
{

    #region [ CTor ]
    public CarouselViewPageViewModel(IAppNavigator appNavigator,
                                     IGitHubService gitHubService,
                                     IGitHubIssueLocalDbService gitHubIssueLocalDbService)
                                    : base(appNavigator,
                                            gitHubService,
                                            gitHubIssueLocalDbService)
    {
    }
    #endregion

    #region [ Properties ]

    [ObservableProperty]
    IBuiltInGalleryCardInfo controlInformation;

    [ObservableProperty]
    int commandCurrentSelectedItemPositionSpan = 0;

    [ObservableProperty]
    string commandCurrentSelectedItemSpan;

    [ObservableProperty]
    CarouselItem commandCurrentSelectedItem;

    [ObservableProperty]
    ObservableCollection<CarouselItem> items;

    [ObservableProperty]
    ObservableCollection<CarouselItem> itemEmptyList;

    [ObservableProperty]
    string xamlCarouselViewBasic =
        "<CarouselView ItemTemplate=\"{x:StaticResource NormalDataTemplate}\"\r\n" +
        "              ItemsSource=\"{x:Binding Items}\" />";

    [ObservableProperty]
    string xamlCarouselViewBasicDataTemplate =
        "<ContentPage x:Class=\"MAUIsland.EditorPage\"\r\n" +
        "             xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
        "             xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
        "             xmlns:app=\"clr-namespace:MAUIsland\"\r\n" +
        "             xmlns:core=\"clr-namespace:MAUIsland.Core;assembly=MAUIsland.Core\"\r\n" +
        "             x:DataType=\"app:EditorPageViewModel\">\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <ResourceDictionary>\r\n" +
        "           <DataTemplate x:Key=\"NormalDataTemplate\"\r\n" +
        "                         x:DataType=\"app:CarouselItem\">\r\n" +
        "               <StackLayout>\r\n" +
        "                   <Frame BorderColor=\"DarkGray\"\r\n" +
        "                          CornerRadius=\"5\"\r\n" +
        "                          HasShadow=\"True\"\r\n" +
        "                          HeightRequest=\"300\"\r\n" +
        "                          HorizontalOptions=\"Center\"\r\n" +
        "                          VerticalOptions=\"Center\">\r\n" +
        "                       <StackLayout>\r\n" +
        "                           <Label FontAttributes=\"Bold\"\r\n" +
        "                                  FontSize=\"20\"\r\n" +
        "                                  HorizontalOptions=\"Center\"\r\n" +
        "                                  Text=\"{Binding Title}\"\r\n" +
        "                                  VerticalOptions=\"Center\" />\r\n" +
        "                           <Image Aspect=\"AspectFill\"\r\n" +
        "                                  HeightRequest=\"150\"\r\n" +
        "                                  HorizontalOptions=\"Center\"\r\n" +
        "                                  Source=\"microsoft.png\"\r\n" +
        "                                  WidthRequest=\"150\" />\r\n" +
        "                           <Label HorizontalOptions=\"Center\"\r\n " +
        "                                  Text=\"{Binding Content}\" />\r\n" +
        "                       </StackLayout>\r\n" +
        "                   </Frame>\r\n" +
        "               </StackLayout>\r\n" +
        "           </DataTemplate>\r\n" +
        "       </ResourceDictionary>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string cSharpCarouselViewBasicViewModel =
        "[ObservableProperty]\r\n" +
        "ObservableCollection<CarouselItem> items;";

    [ObservableProperty]
    string cSharpCarouselItemModel =
        "public class CarouselItem\r\n" +
        "{\r\n" +
        "    public string Id { get; set; }\r\n" +
        "    public string Title { get; set; }\r\n" +
        "    public string ImageUrl { get; set; }\r\n" +
        "    public string Content { get; set; }\r\n" +
        "    public bool IsFavorite { get; set; }\r\n" +
        "}";

    [ObservableProperty]
    string xamlCarouselViewDataTemplateSelector =
        "<CarouselView x:Name=\"TemplateSelectorCarouselView\" \r\n" +
        "              ItemsSource=\"{x:Binding Items}\" \r\n" +
        "              ItemTemplate=\"{x:StaticResource CarouselViewItemDataTemplateSelector}\"\r\n" +
        "              Loop=\"False\"/>";

    [ObservableProperty]
    string cSharpCarouselViewDataTemplateSelector =
        "public class CarouselViewItemDataTemplateSelector : DataTemplateSelector\r\n" +
        "{\r\n" +
        "    public DataTemplate HighlightedTemplate { get; set; }\r\n" +
        "    public DataTemplate NormalTemplate { get; set; }\r\n\r\n" +
        "    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)\r\n" +
        "    {\r\n" +
        "        var selectedItem = (CarouselItem)item;\r\n" +
        "        return selectedItem.Id.Equals(\"1\") ? HighlightedTemplate : NormalTemplate;\r\n" +
        "    }\r\n" +
        "}";

    [ObservableProperty]
    string xamlCarouselViewDataTemplateSelectorSetup =
        "<ContentPage x:Class=\"MAUIsland.EditorPage\"\r\n" +
        "             xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
        "             xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
        "             xmlns:app=\"clr-namespace:MAUIsland\"\r\n" +
        "             xmlns:core=\"clr-namespace:MAUIsland.Core;assembly=MAUIsland.Core\"\r\n" +
        "             x:DataType=\"app:EditorPageViewModel\">\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <ResourceDictionary>\r\n" +
        "           <DataTemplate x:Key=\"NormalDataTemplate\"\r\n" +
        "                         x:DataType=\"app:CarouselItem\">\r\n" +
        "               <StackLayout>\r\n" +
        "                   <Frame BorderColor=\"DarkGray\"\r\n" +
        "                          CornerRadius=\"5\"\r\n" +
        "                          HasShadow=\"True\"\r\n" +
        "                          HeightRequest=\"300\"\r\n" +
        "                          HorizontalOptions=\"Center\"\r\n" +
        "                          VerticalOptions=\"Center\">\r\n" +
        "                       <StackLayout>\r\n" +
        "                           <Label FontAttributes=\"Bold\"\r\n" +
        "                                  FontSize=\"20\"\r\n" +
        "                                  HorizontalOptions=\"Center\"\r\n" +
        "                                  VerticalOptions=\"Center\" />\r\n" +
        "                                  Text=\"{Binding Title}\"\r\n" +
        "                           <Image Aspect=\"AspectFill\"\r\n" +
        "                                  HeightRequest=\"150\"\r\n" +
        "                                  HorizontalOptions=\"Center\"\r\n" +
        "                                  Source=\"microsoft.png\"\r\n" +
        "                                  WidthRequest=\"150\" />\r\n" +
        "                           <Label HorizontalOptions=\"Center\"\r\n" +
        "                                  Text=\"{Binding Content}\" />\r\n" +
        "                       </StackLayout>\r\n" +
        "                   </Frame>\r\n" +
        "               </StackLayout>\r\n        " +
        "           </DataTemplate>\r\n\r\n" +
        "           <DataTemplate x:Key=\"HighlightedDataTemplate\"\r\n" +
        "                         x:DataType=\"app:CarouselItem\">\r\n" +
        "               <StackLayout>\r\n" +
        "                   <Frame Margin=\"20\"\r\n" +
        "                          BackgroundColor=\"GreenYellow\"\r\n" +
        "                          BorderColor=\"Black\"\r\n" +
        "                          CornerRadius=\"5\"\r\n" +
        "                          HasShadow=\"True\"\r\n" +
        "                          HeightRequest=\"300\"\r\n" +
        "                          HorizontalOptions=\"Center\"\r\n" +
        "                          VerticalOptions=\"Center\">\r\n" +
        "                       <StackLayout>\r\n" +
        "                           <Label FontAttributes=\"Bold\"\r\n" +
        "                                  FontSize=\"20\"\r\n" +
        "                                  HorizontalOptions=\"Center\"\r\n" +
        "                                  Text=\"{Binding Title}\"\r\n" +
        "                                  VerticalOptions=\"Center\" />\r\n" +
        "                           <Image Aspect=\"AspectFill\"\r\n" +
        "                                  HeightRequest=\"150\"\r\n" +
        "                                  HorizontalOptions=\"Center\"\r\n" +
        "                                  Source=\"microsoft.png\"\r\n" +
        "                                  WidthRequest=\"150\" />\r\n" +
        "                           <Label HorizontalOptions=\"Center\" \r\n" +
        "                                  Text=\"{Binding Content}\" />\r\n" +
        "                       </StackLayout>\r\n" +
        "                   </Frame>\r\n" +
        "               </StackLayout>\r\n" +
        "           </DataTemplate>\r\n\r\n" +
        "           <app:CarouselViewItemDataTemplateSelector x:Key=\"CarouselViewItemDataTemplateSelector\"\r\n" +
        "                                                     HighlightedTemplate =\"{x:StaticResource HighlightedDataTemplate}\"\r\n" +
        "                                                     NormalTemplate =\"{x:StaticResource NormalDataTemplate}\"\r\n/>" +
        "       </ResourceDictionary>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string cSharpCarouselViewDataTemplateSelectorViewModel =
        "[ObservableProperty]\r\n" +
        "ObservableCollection<CarouselItem> items;";

    [ObservableProperty]
    string xamlCarouselViewIndicatorView =
        "<CarouselView IndicatorView=\"IndicatorView\"\r\n" +
        "              ItemsSource=\"{x:Binding Items}\" \r\n" +
        "              ItemTemplate=\"{x:StaticResource NormalDataTemplate}\"/>\r\n" +
        "<IndicatorView x:Name=\"IndicatorView\"\r\n" +
        "               IndicatorColor=\"LightGray\"\r\n" +
        "               SelectedIndicatorColor=\"Aqua\"\r\n" +
        "               HorizontalOptions=\"Center\" />";

    [ObservableProperty]
    string xamlCarouselViewSwipeView =
        "<CarouselView ItemsSource=\"{x:Binding Items}\" \r\n" +
        "              ItemTemplate=\"{x:StaticResource CarouselSwipeViewItemTemplate}\"/>";

    [ObservableProperty]
    string xamlCarouselViewSwipeViewDataTemplate =
        "<ContentPage x:Class=\"MAUIsland.EditorPage\"\r\n" +
        "             xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
        "             xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
        "             xmlns:app=\"clr-namespace:MAUIsland\"\r\n" +
        "             xmlns:core=\"clr-namespace:MAUIsland.Core;assembly=MAUIsland.Core\"\r\n" +
        "             x:DataType=\"app:EditorPageViewModel\">\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <ResourceDictionary>\r\n" +
        "           <DataTemplate x:Key=\"CarouselSwipeViewItemTemplate\">\r\n" +
        "               <StackLayout>\r\n                " +
        "                   <Frame Margin=\"20\"\r\n" +
        "                          HeightRequest=\"300\"\r\n" +
        "                          HorizontalOptions=\"Center\"\r\n" +
        "                          VerticalOptions=\"CenterAndExpand\" >\r\n" +
        "                       <SwipeView>\r\n" +
        "                           <SwipeView.TopItems>\r\n" +
        "                               <SwipeItems>\r\n" +
        "                                   <SwipeItem Text=\"Favorite\"\r\n" +
        "                                              IconImageSource=\"{x:Static core:FluentUIIcon.Ic_fluent_heart_24_regular}\"\r\n" +
        "                                              BackgroundColor=\"LightGreen\"\r\n" +
        "                                              Command=\"{x:Binding Path=BindingContext.SwipeViewFavoriteCommand, Source={x:RelativeSource AncestorType={x:Type ContentPage}}}\"\r\n" +
        "                                              CommandParameter=\"{Binding}\" />\r\n" +
        "                               </SwipeItems>\r\n" +
        "                           </SwipeView.TopItems>\r\n" +
        "                           <SwipeView.BottomItems>\r\n" +
        "                               <SwipeItems>\r\n" +
        "                                   <SwipeItem Text=\"Delete\"\r\n" +
        "                                              BackgroundColor=\"LightPink\"\r\n" +
        "                                              IconImageSource=\"{x:Static core:FluentUIIcon.Ic_fluent_delete_24_regular}\"\r\n" +
        "                                              Command=\"{x:Binding Path=BindingContext.SwipeViewDeleteCommand, Source={x:RelativeSource AncestorType={x:Type ContentPage}}}\"\r\n" +
        "                                              CommandParameter=\"{Binding}\"/>\r\n" +
        "                               </SwipeItems>\r\n" +
        "                           </SwipeView.BottomItems>\r\n" +
        "                           <StackLayout x:DataType=\"app:CarouselItem\">\r\n" +
        "                               <Label FontAttributes=\"Bold\"\r\n" +
        "                                      FontSize=\"20\"\r\n" +
        "                                      HorizontalOptions=\"Center\"\r\n" +
        "                                      Text=\"{Binding Title}\"\r\n" +
        "                                      VerticalOptions=\"Center\" />\r\n" +
        "                               <Image Aspect=\"AspectFill\"\r\n" +
        "                                      HeightRequest=\"150\"\r\n" +
        "                                      HorizontalOptions=\"Center\"\r\n" +
        "                                      Source=\"microsoft.png\"\r\n" +
        "                                      WidthRequest=\"150\" />\r\n" +
        "                               <Label HorizontalOptions=\"Center\" \r\n" +
        "                                      Text=\"{Binding Content}\" />\r\n" +
        "                           </StackLayout>\r\n" +
        "                       </SwipeView>\r\n" +
        "                   </Frame>\r\n" +
        "               </StackLayout>\r\n" +
        "           </DataTemplate\r\n>" +
        "       </ResourceDictionary>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlCarouselViewRefreshView =
        "<RefreshView IsRefreshing=\"{Binding IsRefreshing}\"\r\n" +
        "             Command=\"{Binding RefreshCommand}\">\r\n" +
        "   <CarouselView ItemsSource=\"{x:Binding Items}\" \r\n" +
        "                 ItemTemplate=\"{x:StaticResource NormalDataTemplate}\"/>\r\n" +
        "</RefreshView>";

    [ObservableProperty]
    string cSharpCarouselViewRefreshViewViewModel =
        "[ObservableProperty]\r\n" +
        "bool isRefreshing;\r\n\r\n" +
        "[RelayCommand]\r\n" +
        "void Refresh()\r\n" +
        "{\r\n" +
        "     IsRefreshing = true;\r\n\r\n" +
        "     LoadDataAsync(true);\r\n\r\n" +
        "     IsRefreshing = false;\r\n" +
        "}";

    [ObservableProperty]
    string xamlCarouselViewHorizontalLayout =
        "<CarouselView ItemsSource=\"{x:Binding Items}\" \r\n" +
        "              ItemTemplate=\"{x:StaticResource NormalDataTemplate}\"\r\n" +
        "              HorizontalOptions=\"FillAndExpand\">\r\n" +
        "   <CarouselView.ItemsLayout>\r\n" +
        "       <LinearItemsLayout Orientation=\"Horizontal\"/>\r\n" +
        "   </CarouselView.ItemsLayout>\r\n" +
        "</CarouselView>";

    [ObservableProperty]
    string xamlCarouselViewRightToLeftLayout =
        "<CarouselView ItemsSource=\"{x:Binding Items}\" \r\n" +
        "              ItemTemplate=\"{x:StaticResource NormalDataTemplate}\"\r\n" +
        "              HorizontalOptions=\"FillAndExpand\"\r\n" +
        "              FlowDirection=\"RightToLeft\"/>";

    [ObservableProperty]
    string xamlCarouselViewItemChangingEvent =
        "<Label>\r\n" +
        "   <Label.FormattedText>\r\n" +
        "       <FormattedString>\r\n" +
        "           <Span Text=\"This is the Current Item Content that you selected: \"/>\r\n" +
        "           <Span x:Name=\"ItemChangingEventHandlerLabelSpan\"/>\r\n" +
        "       </FormattedString>\r\n" +
        "   </Label.FormattedText>\r\n" +
        "</Label>\r\n" +
        "<Label>\r\n" +
        "   <Label.FormattedText>\r\n" +
        "       <FormattedString>\r\n" +
        "           <Span Text=\"And its Position: \"/>\r\n" +
        "           <Span x:Name=\"PositionItemChangingEventHandlerLabelSpan\"/>\r\n" +
        "       </FormattedString>\r\n" +
        "   </Label.FormattedText>\r\n" +
        "</Label>\r\n" +
        "<CarouselView Grid.Column=\"1\"\r\n" +
        "              ItemsSource=\"{x:Binding Items}\" \r\n" +
        "              ItemTemplate=\"{x:StaticResource NormalDataTemplate}\"\r\n" +
        "              CurrentItemChanged=\"CarouselViewCurrentItemChanged\"\r\n" +
        "              VerticalOptions=\"Center\"/>";

    [ObservableProperty]
    string cSharpCarouselViewItemChangingEventCodeBehind =
        "private void CarouselViewCurrentItemChanged(object sender, CurrentItemChangedEventArgs e)\r\n" +
        "{\r\n" +
        "    var carouselItem = (CarouselItem)e.CurrentItem;\r\n" +
        "    var carouselView = (CarouselView)sender;\r\n" +
        "    ItemChangingEventHandlerLabelSpan.Text = carouselItem.Content;\r\n" +
        "    PositionItemChangingEventHandlerLabelSpan.Text = carouselView.Position.ToString();\r\n" +
        "}";

    [ObservableProperty]
    string xamlCarouselViewItemChangingCommand =
        "<Label>\r\n" +
        "   <Label.FormattedText>\r\n" +
        "       <FormattedString>\r\n" +
        "           <Span Text=\"This is the Current Item Content that you selected: \"/>\r\n" +
        "           <Span Text=\"{x:Binding CommandCurrentSelectedItemSpan}\"/>\r\n" +
        "       </FormattedString>\r\n" +
        "   </Label.FormattedText>\r\n" +
        "</Label>\r\n" +
        "<Label>\r\n" +
        "   <Label.FormattedText>\r\n" +
        "       <FormattedString>\r\n" +
        "           <Span Text=\"And its Position: \"/>\r\n" +
        "           <Span Text=\"{x:Binding CommandCurrentSelectedItemPositionSpan}\"/>\r\n" +
        "       </FormattedString>\r\n" +
        "   </Label.FormattedText>\r\n" +
        "</Label>\r\n" +
        "<CarouselView x:Name=\"CarouselViewCommandItemChanging\" Grid.Column=\"1\"\r\n" +
        "              ItemsSource=\"{x:Binding Items}\" \r\n" +
        "              ItemTemplate=\"{x:StaticResource NormalDataTemplate}\"\r\n" +
        "              CurrentItem=\"{x:Binding CommandCurrentSelectedItem}\"\r\n" +
        "              CurrentItemChangedCommand=\"{x:Binding CarouselViewCurrentItemChangedCommand}\"\r\n" +
        "              CurrentItemChangedCommandParameter=\"{x:Binding Path=CurrentItem.Content, Source={x:Reference CarouselViewCommandItemChanging}}\"\r\n" +
        "              Position=\"{x:Binding CommandCurrentSelectedItemPositionSpan, Mode=TwoWay}\"\r\n" +
        "              VerticalOptions=\"Center\"/>";

    [ObservableProperty]
    string cSharpCarouselViewItemChangingCommandViewModel =
        "[ObservableProperty]\r\n" +
        "int commandCurrentSelectedItemPositionSpan = 0;\r\n\r\n" +
        "[ObservableProperty]\r\n" +
        "string commandCurrentSelectedItemSpan;\r\n\r\n" +
        "[RelayCommand]\r\n" +
        "void CarouselViewCurrentItemChanged(string value)\r\n" +
        "{\r\n" +
        "     CommandCurrentSelectedItemSpan = value;\r\n" +
        "}";

    [ObservableProperty]
    string xamlCarouselViewEmptyView =
        "<CarouselView ItemsSource=\"{x:Binding ItemEmptyList}\" \r\n" +
        "              ItemTemplate=\"{x:StaticResource NormalDataTemplate}\"\r\n" +
        "              EmptyView=\"Nothing to show here !!!.\"/>";
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
    void SwipeViewFavorite(CarouselItem carouselItem)
        => carouselItem.IsFavorite = !carouselItem.IsFavorite;

    [RelayCommand]
    void SwipeViewDelete(CarouselItem carouselItem)
    {
        if (Items.Contains(carouselItem))
            Items.Remove(carouselItem);
    }

    [RelayCommand]
    void CarouselViewCurrentItemChanged(string value)
    {
        CommandCurrentSelectedItemSpan = value;
    }
    #endregion

    #region [ Methods ]
    private async Task LoadDataAsync(bool forced)
    {
        var items = new List<CarouselItem>()
        {
            new()
            {
                Id = "1",
                Title = "CarouselView Item",
                Content = "Number 1"

            },

            new()
            {
                Id = "2",
                Title = "CarouselView Item",
                Content = "Number 2"

            },

            new()
            {
                Id = "3",
                Title = "CarouselView Item",
                Content = "Number 3"

            },

            new()
            {
                Id = "4",
                Title = "CarouselView Item",
                Content = "Number 4"

            },

            new()
            {
                Id = "5",
                Title = "CarouselView Item",
                Content = "Number 5"

            }
        };

        if (forced || Items is null || ItemEmptyList is null)
        {
            Items = new();
            ItemEmptyList = new();
        }

        foreach (var item in items)
        {
            Items.Add(item);
        }

        CommandCurrentSelectedItem = Items.First();
    }

    [RelayCommand]
    async Task RefreshAsync()
    {
        await LoadDataAsync(true);
        await RefreshControlIssues(true,
                                   ControlInformation.ControlName,
                                   ControlInformation.GitHubAuthorIssueName,
                                   ControlInformation.GitHubRepositoryIssueName,
                                   ControlInformation.GitHubIssueLabels);
    }
    #endregion
}
