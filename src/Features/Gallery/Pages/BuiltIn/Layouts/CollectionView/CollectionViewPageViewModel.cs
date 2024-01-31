using CommunityToolkit.Maui.Core.Extensions;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUIsland;

public partial class CollectionViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IControlsService MauiControlsService;
    private readonly IMrIncreadibleMemeService MemeService;
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    string currentSingleSelectedItemLabel = string.Empty;

    [ObservableProperty]
    string previousSingleSelectedItemLabel = string.Empty;

    [ObservableProperty]
    string currentMultipleSelectedItemLabel = string.Empty;

    [ObservableProperty]
    string previousMultipleSelectedItemLabel = string.Empty;

    [ObservableProperty]
    string currentMultipleSelectedListItemLabel = string.Empty;

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    ObservableCollection<string> filterPickerItems;

    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    IGalleryCardInfo singleSelectedControlInformation;

    [ObservableProperty]
    IEnumerable<object> multipleSelectedControlInformationList = new List<object>();

    [ObservableProperty]
    ObservableCollection<MrIncreadible> mrIncreadibles;

    [ObservableProperty]
    ObservableCollection<IGalleryCardInfo> controlGroupList;

    [ObservableProperty]
    int spanningNumber = 1;

    [ObservableProperty]
    string cSharpBasicCollectionModel =
        "public interface IGalleryCardInfo\r\n" +
        "{\r\n" +
        "    ImageSource ControlIcon { get; }\r\n" +
        "    string ControlName { get; }\r\n" +
        "    string ControlDetail { get; }\r\n" +
        "    GalleryCardType CardType { get; }\r\n" +
        "    GalleryCardStatus CardStatus { get; }\r\n" +
        "}";

    [ObservableProperty]
    string cSharpBasicCollectionViewModel =
        "[ObservableProperty]\r\n" +
        "ObservableCollection<IGalleryCardInfo> controlGroupList;; // How data is loaded up to you";

    [ObservableProperty]
    string xamlBasicCollectionViewTemplate =
        "<ContentPage>\r\n" +
        "   <ContentPage.Resources>\r\n" +
        "       <DataTemplate x:Key=\"ControllInfoCollectionTemplate\" \r\n" +
        "                   x:DataType=\"app:IGalleryCardInfo\">\r\n" +
        "           <Border Padding=\"5\"\r\n" +
        "                   BackgroundColor=\"{x:Static app:AppColors.BlackGrey}\">\r\n" +
        "               <Border.StrokeShape>\r\n" +
        "                   <RoundRectangle CornerRadius=\"5\" />\r\n" +
        "               </Border.StrokeShape>\r\n" +
        "               <Grid ColumnDefinitions=\"0.2*, 0.2*, 0.6*\" \r\n" +
        "                     HeightRequest=\"40\">\r\n" +
        "                   <Image Grid.Column=\"0\"\r\n" +
        "                          Source=\"{x:Binding ControlIcon}\"\r\n" +
        "                          VerticalOptions=\"Center\"/>\r\n" +
        "                   <Label Grid.Column=\"1\"\r\n" +
        "                          FontAttributes=\"Bold\"\r\n" +
        "                          LineBreakMode=\"TailTruncation\"\r\n" +
        "                          FontSize=\"14\"\r\n" +
        "                          Text=\"{x:Binding ControlName}\"\r\n" +
        "                          VerticalTextAlignment=\"Center\"/>\r\n" +
        "                   <Label Grid.Column=\"2\"\r\n" +
        "                          FontAttributes=\"Italic\"\r\n" +
        "                          LineBreakMode=\"TailTruncation\"\r\n" +
        "                          FontSize=\"12\"\r\n" +
        "                          VerticalTextAlignment=\"Center\"\r\n" +
        "                          Text=\"{x:Binding ControlDetail}\"/>\r\n" +
        "               </Grid>\r\n" +
        "           </Border>\r\n" +
        "       </DataTemplate>\r\n" +
        "   </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlBasicCollectionView =
        "<CollectionView ItemTemplate=\"{x:StaticResource ControllInfoCollectionTemplate}\"\r\n" +
        "                ItemsSource=\"{x:Binding ControlGroupList}\"\r\n" +
        "                HeightRequest=\"400\"/>\r\n" +
        "<!-- You can make it Scroll by set HeightRequest if it is a Vertical CollectionView and WidthRequest if it is a Horizontal CollectionView -->";

    [ObservableProperty]
    string cSharpSwipeCollectionModel =
        "public class MrIncreadible\r\n" +
        "{\r\n" +
        "    public double Age { get; set; }\r\n" +
        "    public string Title { get; set; }\r\n" +
        "    public ImageSource Image { get; set; }\r\n" +
        "    public bool IsFavorite { get; set; }" +
        "\r\n}";

    [ObservableProperty]
    string xamlSwipeCollectionViewTemplate =
        "<ContentPage>\r\n" +
        "    <ContentPage.Resources>\r\n" +
        "        <DataTemplate x:Key=\"MrIncreadibleCollectionTemplateWithSwipe\">\r\n" +
        "            <SwipeView Margin=\"5\" WidthRequest=\"400\">\r\n" +
        "                <SwipeView.LeftItems>\r\n" +
        "                    <SwipeItems>\r\n" +
        "                        <SwipeItem BackgroundColor=\"{x:Static app:AppColors.Green}\" \r\n" +
        "                                   Command=\"{x:Binding CollectionSwipeViewFavoriteCommand}\"\r\n" +
        "                                   CommandParameter=\"{x:Binding}\"\r\n" +
        "                                   IconImageSource=\"{x:Static app:FluentUIIcon.Ic_fluent_heart_24_regular}\"\r\n" +
        "                                   Text=\"Favorite\" />\r\n" +
        "                        <SwipeItem BackgroundColor=\"{x:Static app:AppColors.LightBlue}\"\r\n" +
        "                                   Command=\"{x:Binding CollectionSwipeViewDeleteCommand}\"\r\n" +
        "                                   CommandParameter=\"{x:Binding}\"\r\n" +
        "                                   IconImageSource=\"{x:Static app:FluentUIIcon.Ic_fluent_delete_24_regular}\"\r\n" +
        "                                   Text=\"Delete\" />\r\n" +
        "                    </SwipeItems>\r\n" +
        "                </SwipeView.LeftItems>\r\n" +
        "                <Frame Style=\"{x:StaticResource DocumentContentFrameStyle}\">\r\n" +
        "                    <Grid x:DataType=\"app:MrIncreadible\"\r\n" +
        "                          ColumnDefinitions=\"0.1*, 0.2*, 0.6*\">\r\n" +
        "                        <Label Grid.Column=\"0\"\r\n" +
        "                               FontAttributes=\"Bold\"\r\n" +
        "                               Text=\"{x:Binding Age}\"\r\n" +
        "                               VerticalOptions=\"Center\"/>\r\n" +
        "                        <toolkit:AvatarView Grid.Column=\"1\" \r\n" +
        "                                            HeightRequest=\"50\"\r\n" +
        "                                            WidthRequest=\"50\"\r\n" +
        "                                            ImageSource=\"{x:Binding Image, Mode=OneWay}\"\r\n" +
        "                                            Text=\"{x:Binding Age, Mode=OneWay}\"/>\r\n" +
        "                        <Label Grid.Column=\"2\"\r\n" +
        "                               FontAttributes=\"Italic\"\r\n" +
        "                               Text=\"{x:Binding Title}\"\r\n" +
        "                               VerticalOptions=\"Center\"/>\r\n" +
        "                    </Grid>\r\n" +
        "                </Frame>\r\n" +
        "            </SwipeView>\r\n" +
        "        </DataTemplate>\r\n" +
        "    </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlSwipeCollectionView =
        "<CollectionView ItemsSource=\"{x:Binding MrIncreadibles}\"\r\n" +
        "                ItemTemplate=\"{x:StaticResource MrIncreadibleCollectionTemplateWithSwipe}\"\r\n" +
        "                HeightRequest=\"400\"/>";

    [ObservableProperty]
    string cSharpSwipeCollectionViewViewModel =
        "[ObservableProperty]\r\n" +
        "ObservableCollection<MrIncreadible> mrIncreadibles;\r\n" +
        "[RelayCommand]\r\n" +
        "void CollectionSwipeViewDelete(MrIncreadible mrIncreadible)\r\n" +
        "{\r\n" +
        "    if (MrIncreadibles.Contains(mrIncreadible))\r\n" +
        "       MrIncreadibles.Remove(mrIncreadible);\r\n" +
        "}\r\n\r\n" +
        "[RelayCommand]\r\n" +
        "void CollectionSwipeViewFavorite(MrIncreadible mrIncreadible)\r\n" +
        "{\r\n" +
        "    mrIncreadible.IsFavorite = !mrIncreadible.IsFavorite;\r\n" +
        "}";

    [ObservableProperty]
    string cSharpRefreshCollectionViewViewModel =
        "[ObservableProperty]\r\n" +
        "bool isRefreshing;\r\n\r\n" +
        "[RelayCommand]\r\n" +
        "void Refresh()\r\n" +
        "{\r\n" +
        "    IsRefreshing = true;\r\n\r\n" +
        "    LoadDataAsync();// Load anything you want\r\n\r\n" +
        "    IsRefreshing = false;\r\n" +
        "}";

    [ObservableProperty]
    string xamlRefreshCollectionView =
        "<RefreshView x:Name=\"RefreshView\"\r\n" +
        "             IsRefreshing=\"{Binding IsRefreshing}\"\r\n" +
        "             Command=\"{Binding RefreshCommand}\"\r\n" +
        "             HeightRequest=\"400\">\r\n" +
        "   <CollectionView ItemsSource=\"{x:Binding ControlGroupList}\"\r\n" +
        "                   ItemTemplate=\"{x:StaticResource ControllInfoCollectionTemplate}\"/>\r\n" +
        "</RefreshView>";

    [ObservableProperty]
    string xamlVerticalListCollectionView =
        "<CollectionView ItemsSource=\"{x:Binding MrIncreadibles}\"\r\n" +
        "                ItemTemplate=\"{x:StaticResource MrIncreadibleItemVerticalTemplate}\"\r\n" +
        "                ItemsLayout=\"VerticalList\"\r\n" +
        "                HeightRequest=\"400\"/>";

    [ObservableProperty]
    string xamlVerticalListCollectionViewTemplate =
        "<ContentPage>\r\n" +
        "    <ContentPage.Resources>\r\n" +
        "        <DataTemplate x:Key=\"MrIncreadibleItemVerticalTemplate\" \r\n" +
        "                      x:DataType=\"app:MrIncreadible\">\r\n" +
        "            <Frame Style=\"{x:StaticResource DocumentContentFrameStyle}\"\r\n" +
        "                   Margin=\"5\">\r\n" +
        "                <Grid x:DataType=\"app:MrIncreadible\"\r\n" +
        "                      ColumnDefinitions=\"0.1*, 0.2*, 0.7*\"\r\n" +
        "                      ColumnSpacing=\"2\">\r\n" +
        "                    <Label Grid.Column=\"0\"\r\n" +
        "                           FontAttributes=\"Bold\"\r\n" +
        "                           Text=\"{x:Binding Age}\"\r\n" +
        "                           VerticalOptions=\"Center\"/>\r\n" +
        "                    <toolkit:AvatarView Grid.Column=\"1\" \r\n" +
        "                                        HeightRequest=\"40\"\r\n" +
        "                                        WidthRequest=\"40\"\r\n" +
        "                                        ImageSource=\"{x:Binding Image, Mode=OneWay}\"/>\r\n" +
        "                    <Label Grid.Column=\"2\"\r\n" +
        "                           FontAttributes=\"Italic\"\r\n" +
        "                           Text=\"{x:Binding Title}\"\r\n" +
        "                           VerticalOptions=\"Center\"/>\r\n" +
        "                </Grid>\r\n" +
        "            </Frame>\r\n" +
        "        </DataTemplate>\r\n" +
        "    </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlHorizontalListCollectionView =
        "<CollectionView ItemsSource=\"{x:Binding MrIncreadibles}\"\r\n" +
        "                ItemTemplate=\"{x:StaticResource MrIncreadibleItemHorizontalTemplate}\"\r\n" +
        "                ItemsLayout=\"HorizontalList\"/>";

    [ObservableProperty]
    string xamlHorizontalListCollectionViewTemplate =
        "<ContentPage>\r\n" +
        "    <ContentPage.Resources>\r\n" +
        "        <DataTemplate x:Key=\"MrIncreadibleItemHorizontalTemplate\" \r\n" +
        "                      x:DataType=\"app:MrIncreadible\">\r\n" +
        "            <Frame Style=\"{x:StaticResource DocumentContentFrameStyle}\"\r\n" +
        "                   Margin=\"5\" WidthRequest=\"300\">\r\n" +
        "                <Grid x:DataType=\"app:MrIncreadible\"\r\n" +
        "                      ColumnDefinitions=\"0.2*, 0.2*, 0.6*\"\r\n" +
        "                      ColumnSpacing=\"2\">\r\n" +
        "                    <Label Grid.Column=\"0\"\r\n" +
        "                           FontAttributes=\"Bold\"\r\n" +
        "                           Text=\"{x:Binding Age}\"\r\n" +
        "                           VerticalOptions=\"Center\"/>\r\n" +
        "                    <toolkit:AvatarView Grid.Column=\"1\" \r\n" +
        "                                        HeightRequest=\"50\"\r\n" +
        "                                        WidthRequest=\"50\"\r\n" +
        "                                        ImageSource=\"{x:Binding Image, Mode=OneWay}\"/>\r\n" +
        "                    <Label Grid.Column=\"2\"\r\n" +
        "                           FontAttributes=\"Italic\"\r\n" +
        "                           Text=\"{x:Binding Title}\"\r\n" +
        "                           VerticalOptions=\"Center\"/>\r\n" +
        "                </Grid>\r\n" +
        "            </Frame>\r\n" +
        "        </DataTemplate>\r\n" +
        "    </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlVerticalGridCollectionView =
        "<!-- Adding HorizontalOptions=\"CenterAndExpand\" can help the Span in ItemsLayout to do it job -->\r\n" +
        "<CollectionView ItemsSource=\"{x:Binding MrIncreadibles}\"\r\n" +
        "                ItemTemplate=\"{x:StaticResource MrIncreadibleItemVerticalSpan2Template}\"\r\n" +
        "                ItemsLayout=\"VerticalGrid, 2\"\r\n" +
        "                HorizontalOptions=\"CenterAndExpand\"\r\n" +
        "                HeightRequest=\"400\"/>";

    [ObservableProperty]
    string xamlVerticalGridCollectionViewTemplate =
        "<ContentPage>\r\n" +
        "    <ContentPage.Resources>\r\n" +
        "        <DataTemplate x:Key=\"MrIncreadibleItemVerticalSpan2Template\" \r\n" +
        "                      x:DataType=\"app:MrIncreadible\">\r\n" +
        "            <Frame Style=\"{x:StaticResource DocumentContentFrameStyle}\"\r\n" +
        "                   Margin=\"5\">\r\n" +
        "                <Grid x:DataType=\"app:MrIncreadible\"\r\n" +
        "                      ColumnDefinitions=\"0.1*, 0.2*, 0.7*\"\r\n" +
        "                      WidthRequest=\"200\"\r\n" +
        "                      ColumnSpacing=\"2\"\r\n" +
        "                      Padding=\"10\"\r\n" +
        "                      Margin=\"5\">\r\n" +
        "                    <Label Grid.Column=\"0\"\r\n" +
        "                           FontAttributes=\"Bold\"\r\n" +
        "                           Text=\"{x:Binding Age}\"\r\n" +
        "                           VerticalOptions=\"Center\"/>\r\n" +
        "                    <toolkit:AvatarView Grid.Column=\"1\" \r\n" +
        "                                        HeightRequest=\"40\"\r\n" +
        "                                        WidthRequest=\"40\"\r\n" +
        "                                        ImageSource=\"{x:Binding Image, Mode=OneWay}\"/>\r\n" +
        "                    <Label Grid.Column=\"2\"\r\n" +
        "                           FontAttributes=\"Italic\"\r\n" +
        "                           Text=\"{x:Binding Title}\"\r\n" +
        "                           VerticalOptions=\"Center\"/>\r\n" +
        "                </Grid>\r\n" +
        "            </Frame>\r\n" +
        "        </DataTemplate>\r\n" +
        "    </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlHeaderFooterCollectionView =
        "<CollectionView ItemsSource=\"{x:Binding MrIncreadibles}\"\r\n" +
        "                ItemTemplate=\"{x:StaticResource MrIncreadibleItemTemplate}\"\r\n" +
        "                Header=\"{x:StaticResource CollectionViewHeader}\"\r\n" +
        "                Footer=\"{x:StaticResource CollectionViewFooter}\"\r\n" +
        "                HeightRequest=\"400\"\r\n" +
        "                HorizontalOptions=\"StartAndExpand\"/>";

    [ObservableProperty]
    string xamlHeaderFooterCollectionViewTemplate =
        "<ContentPage>\r\n" +
        "    <ContentPage.Resources>\r\n" +
        "        <DataTemplate x:Key=\"MrIncreadibleItemTemplate\" \r\n" +
        "                      x:DataType=\"app:MrIncreadible\">\r\n" +
        "            <Frame Style=\"{x:StaticResource DocumentContentFrameStyle}\"\r\n" +
        "                   Margin=\"5\" WidthRequest=\"400\">\r\n" +
        "                <Grid x:DataType=\"app:MrIncreadible\"\r\n" +
        "                      ColumnDefinitions=\"0.1*, 0.2*, 0.8*\"\r\n" +
        "                      ColumnSpacing=\"5\">\r\n" +
        "                    <Label Grid.Column=\"0\"\r\n" +
        "                           FontAttributes=\"Bold\"\r\n" +
        "                           Text=\"{x:Binding Age}\"\r\n" +
        "                           VerticalOptions=\"Center\"/>\r\n" +
        "                    <toolkit:AvatarView Grid.Column=\"1\" \r\n" +
        "                                        HeightRequest=\"50\"\r\n" +
        "                                        WidthRequest=\"50\"\r\n" +
        "                                        ImageSource=\"{x:Binding Image, Mode=OneWay}\"/>\r\n" +
        "                    <Label Grid.Column=\"2\"\r\n" +
        "                           FontAttributes=\"Italic\"\r\n" +
        "                           Text=\"{x:Binding Title}\"\r\n" +
        "                           VerticalOptions=\"Center\"/>\r\n" +
        "                </Grid>\r\n" +
        "            </Frame>\r\n" +
        "        </DataTemplate>\r\n" +
        "    </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlHeaderFooterCollectionViewSource =
        "<ContentPage>\r\n" +
        "    <ContentPage.Resources>\r\n" +
        "        <x:String x:Key=\"CollectionViewHeader\">\r\n" +
        "            What types of women do you like?\r\n" +
        "        </x:String>\r\n\r\n" +
        "        <x:String x:Key=\"CollectionViewFooter\">\r\n" +
        "            Hope you like what you choose !!!\r\n" +
        "        </x:String>\r\n" +
        "    </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlReverseCollectionView =
        "<CollectionView ItemsSource=\"{x:Binding MrIncreadibles}\"\r\n" +
        "                ItemTemplate=\"{x:StaticResource MrIncreadibleItemTemplate}\"\r\n" +
        "                FlowDirection=\"RightToLeft\"\r\n" +
        "                HeightRequest=\"400\"/>";

    [ObservableProperty]
    string xamlLayoutsChangeNormalCollectionViewTemplate =
        "<ContentPage>\r\n" +
        "    <ContentPage.Resources>\r\n" +
        "        <DataTemplate x:Key=\"ControllInfoCollectionTemplate\" \r\n" +
        "                      x:DataType=\"app:IGalleryCardInfo\">\r\n" +
        "            <Border Padding=\"5\"\r\n" +
        "                    BackgroundColor=\"{x:Static app:AppColors.BlackGrey}\">\r\n" +
        "                <Border.StrokeShape>\r\n" +
        "                    <RoundRectangle CornerRadius=\"5\" />\r\n" +
        "                </Border.StrokeShape>\r\n" +
        "                <Grid ColumnDefinitions=\"0.2*, 0.2*, 0.6*\" \r\n" +
        "                      HeightRequest=\"40\">\r\n" +
        "                    <Image Grid.Column=\"0\"\r\n" +
        "                           Source=\"{x:Binding ControlIcon}\"\r\n" +
        "                           VerticalOptions=\"Center\"/>\r\n" +
        "                    <Label Grid.Column=\"1\"\r\n" +
        "                           FontAttributes=\"Bold\"\r\n" +
        "                           LineBreakMode=\"TailTruncation\"\r\n" +
        "                           FontSize=\"14\"\r\n" +
        "                           Text=\"{x:Binding ControlName}\"\r\n" +
        "                           VerticalTextAlignment=\"Center\" \r\n" +
        "                           Style=\"{x:StaticResource ReverseTheme}\"/>\r\n" +
        "                    <Label Grid.Column=\"2\"\r\n" +
        "                           FontAttributes=\"Italic\"\r\n" +
        "                           LineBreakMode=\"TailTruncation\"\r\n" +
        "                           FontSize=\"12\"\r\n" +
        "                           VerticalTextAlignment=\"Center\"\r\n" +
        "                           Text=\"{x:Binding ControlDetail}\"\r\n" +
        "                           Style=\"{x:StaticResource ReverseTheme}\"/>\r\n" +
        "                </Grid>\r\n" +
        "            </Border>\r\n" +
        "        </DataTemplate>\r\n" +
        "    </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlLayoutsChangeCollectionViewTemplate =
         "<ContentPage>\r\n" +
         "    <ContentPage.Resources>\r\n" +
         "        <DataTemplate x:Key=\"ControllInfoCollectionTwoItemRowTemplate\" \r\n" +
         "                      x:DataType=\"app:IGalleryCardInfo\">\r\n" +
         "            <Border Padding=\"5\"\r\n" +
         "                    BackgroundColor=\"{x:Static app:AppColors.BlackGrey}\">\r\n" +
         "                <Border.StrokeShape>\r\n" +
         "                    <RoundRectangle CornerRadius=\"5\" />\r\n" +
         "                </Border.StrokeShape>\r\n" +
         "                <Grid ColumnDefinitions=\"0.2*, 0.8*\"\r\n" +
         "                      RowDefinitions=\"0.3*, 0.7*\"\r\n" +
         "                      HeightRequest=\"100\">\r\n" +
         "                    <Image Grid.Column=\"0\"\r\n" +
         "                           Grid.Row=\"0\"\r\n" +
         "                           Source=\"{x:Binding ControlIcon}\"\r\n" +
         "                           VerticalOptions=\"Center\"/>\r\n" +
         "                    <Label Grid.Column=\"1\"\r\n" +
         "                           Grid.Row=\"0\"\r\n" +
         "                           FontAttributes=\"Bold\"\r\n" +
         "                           LineBreakMode=\"TailTruncation\"\r\n" +
         "                           FontSize=\"14\"\r\n" +
         "                           VerticalTextAlignment=\"Center\" \r\n" +
         "                           HorizontalOptions=\"Center\"\r\n" +
         "                           Text=\"{x:Binding ControlName}\"\r\n" +
         "                           Style=\"{x:StaticResource ReverseTheme}\"/>\r\n" +
         "                    <Border Padding=\"2\"\r\n" +
         "                            Grid.Column=\"0\"\r\n" +
         "                            Grid.Row=\"1\"\r\n" +
         "                            Grid.ColumnSpan=\"2\"\r\n" +
         "                            BackgroundColor=\"{x:Static app:AppColors.BlackGrey}\">\r\n" +
         "                        <Border.StrokeShape>\r\n" +
         "                            <RoundRectangle CornerRadius=\"5\" />\r\n" +
         "                        </Border.StrokeShape>\r\n" +
         "                        <Label FontAttributes=\"Italic\"\r\n" +
         "                               FontSize=\"12\"\r\n" +
         "                               Background=\"{x:Static app:AppColors.BlackGrey}\"\r\n" +
         "                               Text=\"{x:Binding ControlDetail}\"\r\n" +
         "                               Style=\"{x:StaticResource ReverseTheme}\"/>\r\n" +
         "                    </Border>\r\n" +
         "                </Grid>\r\n" +
         "            </Border>\r\n" +
         "        </DataTemplate>\r\n\r\n" +
         "        <DataTemplate x:Key=\"ControllInfoCollectionThreeItemRowTemplate\" \r\n" +
         "                      x:DataType=\"app:IGalleryCardInfo\">\r\n" +
         "            <Border Padding=\"5\"\r\n" +
         "                    BackgroundColor=\"{x:Static app:AppColors.BlackGrey}\">\r\n" +
         "                <Border.StrokeShape>\r\n" +
         "                    <RoundRectangle CornerRadius=\"5\" />\r\n" +
         "                </Border.StrokeShape>\r\n" +
         "                <Grid ColumnDefinitions=\"0.2*, 0.8*\" \r\n" +
         "                      HeightRequest=\"60\">\r\n" +
         "                    <Image Grid.Column=\"0\"\r\n" +
         "                           Source=\"{x:Binding ControlIcon}\"\r\n" +
         "                           VerticalOptions=\"Center\"/>\r\n" +
         "                    <Label Grid.Column=\"1\"\r\n" +
         "                           FontAttributes=\"Bold\"\r\n" +
         "                           LineBreakMode=\"TailTruncation\"\r\n" +
         "                           FontSize=\"14\"\r\n" +
         "                           VerticalTextAlignment=\"Center\" \r\n" +
         "                           HorizontalOptions=\"Center\"\r\n" +
         "                           Text=\"{x:Binding ControlName}\"\r\n" +
         "                           Style=\"{x:StaticResource ReverseTheme}\"/>\r\n" +
         "                </Grid>\r\n" +
         "            </Border>\r\n" +
         "        </DataTemplate>\r\n\r\n" +
         "        <DataTemplate x:Key=\"ControllInfoCollectionFourItemRowTemplate\" \r\n" +
         "                      x:DataType=\"app:IGalleryCardInfo\">\r\n" +
         "            <Border Padding=\"5\"\r\n" +
         "                    BackgroundColor=\"{x:Static app:AppColors.BlackGrey}\">\r\n" +
         "                <Border.StrokeShape>\r\n" +
         "                    <RoundRectangle CornerRadius=\"5\" />\r\n" +
         "                </Border.StrokeShape>\r\n" +
         "                <Grid RowDefinitions=\"0.4*, 0.6*\" \r\n" +
         "                      HeightRequest=\"60\">\r\n" +
         "                    <Image Grid.Row=\"0\"\r\n" +
         "                           Source=\"{x:Binding ControlIcon}\"\r\n" +
         "                           VerticalOptions=\"Center\"/>\r\n" +
         "                    <Label Grid.Row=\"1\"\r\n" +
         "                           FontAttributes=\"Bold\"\r\n" +
         "                           LineBreakMode=\"TailTruncation\"\r\n" +
         "                           FontSize=\"14\"\r\n" +
         "                           VerticalTextAlignment=\"Center\" \r\n" +
         "                           HorizontalOptions=\"Center\"\r\n" +
         "                           Text=\"{x:Binding ControlName}\"\r\n" +
         "                           Style=\"{x:StaticResource ReverseTheme}\"/>\r\n" +
         "                </Grid>\r\n" +
         "            </Border>\r\n" +
         "        </DataTemplate>\r\n" +
         "    </ContentPage.Resources>\r\n" +
         "</ContentPage>";

    [ObservableProperty]
    string xamlLayoutsChangingCollectionView =
        "<HorizontalStackLayout VerticalOptions=\"Center\" \r\n" +
        "                       Spacing=\"5\">\r\n" +
        "   <Label VerticalOptions=\"Center\">\r\n" +
        "       <Label.FormattedText>\r\n" +
        "           <FormattedString>\r\n" +
        "               <Span Text=\"Number of Span: \"/>\r\n" +
        "               <Span Text=\"{x:Binding SpanningNumber, Mode=OneWay}\" FontAttributes=\"Bold\" />\r\n" +
        "           </FormattedString>\r\n" +
        "       </Label.FormattedText>\r\n" +
        "   </Label>\r\n" +
        "   <Stepper Minimum=\"1\" \r\n" +
        "            Maximum=\"4\" \r\n" +
        "            Value=\"{x:Binding SpanningNumber, Mode=TwoWay}\"\r\n" +
        "            Background=\"Black\"\r\n" +
        "            VerticalOptions=\"Center\"/>\r\n" +
        "</HorizontalStackLayout>\r\n" +
        "<!-- Adding HorizontalOptions=\"CenterAndExpand\" can help the Span in ItemsLayout to do it job -->\r\n" +
        "<CollectionView x:Name=\"CollectionViewSpanningChange\"\r\n" +
        "                ItemTemplate=\"{x:StaticResource ControllInfoCollectionTemplate}\"\r\n" +
        "                ItemsSource=\"{x:Binding ControlGroupList, Mode=OneWay}\"\r\n" +
        "                HorizontalOptions=\"CenterAndExpand\"\r\n" +
        "                HeightRequest=\"400\">\r\n" +
        "   <CollectionView.ItemsLayout>\r\n" +
        "       <GridItemsLayout Orientation=\"Vertical\"\r\n" +
        "                        Span=\"{x:Binding SpanningNumber, Mode=TwoWay}\"\r\n" +
        "                        HorizontalItemSpacing=\"5\"\r\n" +
        "                        VerticalItemSpacing=\"5\"/>\r\n" +
        "   </CollectionView.ItemsLayout>\r\n" +
        "</CollectionView>";

    [ObservableProperty]
    string cSharpLayoutsChangingCollectionViewCodeBehind =
        "#region [ Service ]\r\n" +
        "protected readonly CollectionViewPageViewModel ViewModel;\r\n" +
        "#endregion\r\n\r\n" +
        "#region [ CTor ]\r\n" +
        "public CollectionViewPage(CollectionViewPageViewModel vm)\r\n" +
        "{\r\n" +
        "    InitializeComponent();\r\n\r\n" +
        "    BindingContext = ViewModel = vm;\r\n" +
        "}\r\n" +
        "#endregion\r\n\r\n" +
        "#region [ Override ]\r\n" +
        "protected override void OnAppearing()\r\n" +
        "{\r\n" +
        "    base.OnAppearing();\r\n" +
        "    ViewModel.SpanningNumberChanged += ViewModelSpanningNumberPropertyChanged;\r\n" +
        "}\r\n\r\n" +
        "protected override void OnDisappearing()\r\n" +
        "{\r\n" +
        "    base.OnDisappearing();\r\n" +
        "    ViewModel.SpanningNumberChanged -= ViewModelSpanningNumberPropertyChanged;\r\n" +
        "}\r\n" +
        "#endregion\r\n\r\n" +
        "#region [ Event Handler ]\r\n" +
        "private void ViewModelSpanningNumberPropertyChanged(object sender, PropertyChangedEventArgs e)\r\n" +
        "{\r\n" +
        "    if (e.PropertyName == \"SpanningNumber\")\r\n" +
        "    {\r\n" +
        "        switch (ViewModel.SpanningNumber)\r\n" +
        "        {\r\n" +
        "            case 1:\r\n" +
        "                 CollectionViewSpanningChange.ItemTemplate = (DataTemplate)Resources[\"ControllInfoCollectionTemplate\"];\r\n" +
        "                 break;\r\n" +
        "            case 2:\r\n" +
        "                 CollectionViewSpanningChange.ItemTemplate = (DataTemplate)Resources[\"ControllInfoCollectionTwoItemRowTemplate\"];\r\n" +
        "                 break;\r\n" +
        "            case 3:\r\n" +
        "                 CollectionViewSpanningChange.ItemTemplate = (DataTemplate)Resources[\"ControllInfoCollectionThreeItemRowTemplate\"];\r\n" +
        "                 break;\r\n" +
        "            case 4:\r\n" +
        "                 CollectionViewSpanningChange.ItemTemplate = (DataTemplate)Resources[\"ControllInfoCollectionFourItemRowTemplate\"];\r\n" +
        "                 break;\r\n" +
        "        }\r\n" +
        "    }\r\n" +
        "}\r\n" +
        "#endregion";

    [ObservableProperty]
    string cSharpLayoutsChangingCollectionViewViewModel =
        "#region [ Properties ]\r\n" +
        "[ObservableProperty]\r\n" +
        "int spanningNumber = 1;\r\n" +
        "#endregion\r\n\r\n" +
        "#region [ Event ]\r\n" +
        "public event PropertyChangedEventHandler SpanningNumberChanged;\r\n\r\n" +
        "protected virtual void OnSpanningNumberChangedEvent([CallerMemberName] string propertyName = null)\r\n" +
        "{\r\n" +
        "    SpanningNumberChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));\r\n" +
        "}\r\n\r\n" +
        "#endregion\r\n\r\n" +
        "#region [ Methods ]\r\n" +
        "partial void OnSpanningNumberChanged(int value)\r\n" +
        "{\r\n" +
        "    OnSpanningNumberChangedEvent(nameof(SpanningNumber));\r\n" +
        "}\r\n\r\n" +
        "#endregion";

    [ObservableProperty]
    string xamlSingleSelectionCollectionView =
        "<Label>\r\n" +
        "   <Label.FormattedText>\r\n" +
        "       <FormattedString>\r\n" +
        "           <Span Text=\"Current selected item: \" />\r\n" +
        "           <Span Text=\"{x:Binding CurrentSingleSelectedItemLabel}\"\r\n" +
        "                 TextDecorations=\"Underline\" />\r\n" +
        "       </FormattedString>\r\n" +
        "   </Label.FormattedText>\r\n" +
        "</Label>\r\n" +
        "<Label>\r\n" +
        "   <Label.FormattedText>\r\n" +
        "       <FormattedString>\r\n" +
        "           <Span Text=\"Previous selected item: \" />\r\n" +
        "           <Span Text=\"{x:Binding PreviousSingleSelectedItemLabel}\"\r\n" +
        "                 TextDecorations=\"Underline\" />\r\n" +
        "       </FormattedString>\r\n" +
        "   </Label.FormattedText>\r\n" +
        "</Label>\r\n" +
        "<CollectionView ItemTemplate=\"{x:StaticResource ControllInfoCollectionFourItemRowTemplate}\"\r\n" +
        "                ItemsLayout=\"VerticalGrid, 4\"\r\n" +
        "                ItemsSource=\"{x:Binding ControlGroupList}\"\r\n" +
        "                SelectedItem=\"{x:Binding SingleSelectedControlInformation}\"\r\n" +
        "                SelectionChangedCommand=\"{x:Binding SingleSelectCollectionViewCommand}\"\r\n" +
        "                HorizontalOptions=\"CenterAndExpand\"\r\n" +
        "                SelectionMode=\"Single\"\r\n" +
        "                HeightRequest=\"400\"/>";

    [ObservableProperty]
    string xamlSingleSelectionCollectionViewTemplate =
        "<ContentPage>\r\n" +
        "    <ContentPage.Resources>\r\n" +
        "        <DataTemplate x:Key=\"ControllInfoCollectionFourItemRowTemplate\" \r\n" +
        "                      x:DataType=\"app:IGalleryCardInfo\">\r\n" +
        "            <Border Padding=\"5\"\r\n" +
        "                    BackgroundColor=\"{x:Static app:AppColors.BlackGrey}\">\r\n" +
        "                <Border.StrokeShape>\r\n" +
        "                    <RoundRectangle CornerRadius=\"5\" />\r\n" +
        "                </Border.StrokeShape>\r\n" +
        "                <Grid RowDefinitions=\"0.4*, 0.6*\" \r\n" +
        "                      HeightRequest=\"60\">\r\n" +
        "                    <Image Grid.Row=\"0\"\r\n" +
        "                           Source=\"{x:Binding ControlIcon}\"\r\n" +
        "                           VerticalOptions=\"Center\"/>\r\n" +
        "                    <Label Grid.Row=\"1\"\r\n" +
        "                           FontAttributes=\"Bold\"\r\n" +
        "                           LineBreakMode=\"TailTruncation\"\r\n" +
        "                           FontSize=\"14\"\r\n" +
        "                           VerticalTextAlignment=\"Center\" \r\n" +
        "                           HorizontalOptions=\"Center\"\r\n" +
        "                           Text=\"{x:Binding ControlName}\"\r\n" +
        "                           Style=\"{x:StaticResource ReverseTheme}\"/>\r\n" +
        "                </Grid>\r\n" +
        "            </Border>\r\n" +
        "        </DataTemplate>\r\n" +
        "    </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string cSharpSingleSelectionCollectionViewViewModel =
        "#region [ Properties ]\r\n" +
        "[ObservableProperty]\r\n" +
        "string currentSingleSelectedItemLabel = string.Empty;\r\n\r\n" +
        "[ObservableProperty]\r\n" +
        "string previousSingleSelectedItemLabel = string.Empty;\r\n\r\n" +
        "[ObservableProperty]\r\n" +
        "IGalleryCardInfo singleSelectedControlInformation;\r\n\r\n" +
        "[ObservableProperty]\r\n" +
        "ObservableCollection<IGalleryCardInfo> controlGroupList;\r\n\r\n" +
        "#endregion\r\n" +
        "[RelayCommand]\r\n" +
        "void SingleSelectCollectionView()\r\n\r\n" +
        "#region [ Relay Commands ]\r\n" +
        "{\r\n" +
        "    if (CurrentSingleSelectedItemLabel is not null)\r\n" +
        "       PreviousSingleSelectedItemLabel = CurrentSingleSelectedItemLabel;\r\n" +
        "    CurrentSingleSelectedItemLabel = SingleSelectedControlInformation.ControlName;\r\n" +
        "}\r\n" +
        "#endregion";

    [ObservableProperty]
    string xamlMultipleSelectionCollectionView =
        "<Label LineBreakMode=\"HeadTruncation\">\r\n" +
        "   <Label.FormattedText>\r\n" +
        "       <FormattedString>\r\n" +
        "           <Span Text=\"Selected items: \" />\r\n" +
        "           <Span Text=\"{x:Binding CurrentMultipleSelectedListItemLabel}\"\r\n" +
        "                 TextDecorations=\"Underline\" />\r\n" +
        "       </FormattedString>\r\n" +
        "   </Label.FormattedText>\r\n" +
        "</Label>\r\n" +
        "<Label>\r\n" +
        "   <Label.FormattedText>\r\n" +
        "       <FormattedString>\r\n" +
        "           <Span Text=\"Current selected item: \" />\r\n" +
        "           <Span Text=\"{x:Binding CurrentMultipleSelectedItemLabel}\"\r\n" +
        "                 TextDecorations=\"Underline\" />\r\n" +
        "       </FormattedString>\r\n" +
        "   </Label.FormattedText>\r\n" +
        "</Label>\r\n" +
        "<Label>\r\n" +
        "   <Label.FormattedText>\r\n" +
        "       <FormattedString>\r\n" +
        "           <Span Text=\"Previous selected item: \" />\r\n" +
        "           <Span Text=\"{x:Binding PreviousMultipleSelectedItemLabel}\"\r\n" +
        "                 TextDecorations=\"Underline\" />\r\n" +
        "       </FormattedString>\r\n" +
        "   </Label.FormattedText>\r\n" +
        "</Label>\r\n" +
        "<CollectionView ItemTemplate=\"{x:StaticResource ControllInfoCollectionFourItemRowTemplate}\"\r\n" +
        "                ItemsLayout=\"VerticalGrid, 4\"\r\n" +
        "                ItemsSource=\"{x:Binding ControlGroupList}\"\r\n" +
        "                SelectedItems=\"{x:Binding MultipleSelectedControlInformationList, Mode=TwoWay}\"\r\n" +
        "                SelectionChangedCommand=\"{x:Binding MultipleSelectCollectionViewCommand}\"\r\n" +
        "                HorizontalOptions=\"CenterAndExpand\"\r\n" +
        "                SelectionMode=\"Multiple\"\r\n" +
        "                HeightRequest=\"400\"/>";

    [ObservableProperty]
    string xamlMultipleSelectionCollectionViewTemplate =
        "<ContentPage>\r\n" +
        "    <ContentPage.Resources>\r\n" +
        "        <DataTemplate x:Key=\"ControllInfoCollectionFourItemRowTemplate\" \r\n" +
        "              x:DataType=\"app:IGalleryCardInfo\">\r\n" +
        "            <Border Padding=\"5\"\r\n" +
        "                    BackgroundColor=\"{x:Static app:AppColors.BlackGrey}\">\r\n" +
        "                <Border.StrokeShape>\r\n" +
        "                    <RoundRectangle CornerRadius=\"5\" />\r\n" +
        "                </Border.StrokeShape>\r\n" +
        "                <Grid RowDefinitions=\"0.4*, 0.6*\" \r\n" +
        "                       HeightRequest=\"60\">\r\n" +
        "                    <Image Grid.Row=\"0\"\r\n" +
        "                  Source=\"{x:Binding ControlIcon}\"\r\n" +
        "                  VerticalOptions=\"Center\"/>\r\n" +
        "                    <Label Grid.Row=\"1\"\r\n" +
        "                           FontAttributes=\"Bold\"\r\n" +
        "                           LineBreakMode=\"TailTruncation\"\r\n" +
        "                           FontSize=\"14\"\r\n" +
        "                           VerticalTextAlignment=\"Center\" \r\n" +
        "                           HorizontalOptions=\"Center\"\r\n" +
        "                           Text=\"{x:Binding ControlName}\"\r\n" +
        "                           Style=\"{x:StaticResource ReverseTheme}\"/>\r\n" +
        "                </Grid>\r\n" +
        "            </Border>\r\n" +
        "        </DataTemplate>\r\n" +
        "    </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string cSharpMultipleSelectionCollectionViewViewModel =
        "#region [ Properties ]\r\n" +
        "[ObservableProperty]\r\n" +
        "string currentMultipleSelectedItemLabel = string.Empty;\r\n\r\n" +
        "[ObservableProperty]\r\n" +
        "string previousMultipleSelectedItemLabel = string.Empty;\r\n\r\n" +
        "[ObservableProperty]\r\n" +
        "string currentMultipleSelectedListItemLabel = string.Empty;\r\n\r\n" +
        "[ObservableProperty]\r\n" +
        "IEnumerable<object> multipleSelectedControlInformationList = new List<object>();\r\n\r\n" +
        "#endregion\r\n" +
        "[RelayCommand]\r\n" +
        "void MultipleSelectCollectionView()\r\n" +
        "{\r\n" +
        "     if (CurrentMultipleSelectedItemLabel is not null)\r\n" +
        "       PreviousMultipleSelectedItemLabel = CurrentMultipleSelectedItemLabel;\r\n" +
        "     if (MultipleSelectedControlInformationList is not null)\r\n" +
        "     {\r\n" +
        "         ObservableCollection<IGalleryCardInfo> itemList = new();\r\n" +
        "         foreach (var item in MultipleSelectedControlInformationList)\r\n" +
        "         {\r\n" +
        "             if (item is IGalleryCardInfo galleryCardInfo)\r\n" +
        "             {\r\n" +
        "                 itemList.Add(galleryCardInfo);\r\n" +
        "             }\r\n" +
        "         }\r\n" +
        "         CurrentMultipleSelectedListItemLabel = string.Join(\", \", itemList.Select(item => item.ControlName.ToString()));\r\n\r\n" +
        "         if (MultipleSelectedControlInformationList.Count() != 0)\r\n" +
        "         {\r\n" +
        "             CurrentMultipleSelectedItemLabel = itemList.Last().ControlName;\r\n" +
        "         }\r\n" +
        "     }\r\n" +
        "}\r\n" +
        "#endregion";

    [ObservableProperty]
    string cSharpTemplateSelectorCollectionViewEventHandler =
        "void OnFilterItemChanged(object sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    var picker = (Picker)sender;\r\n" +
        "    var selectedFilter = picker.SelectedItem.ToString();\r\n\r\n" +
        "    var collectionView = CollectionViewItemLayoutChanged;\r\n" +
        "    var itemsSource = ViewModel.ControlGroupList;\r\n\r\n" +
        "    var filteredItems = new ObservableCollection<IGalleryCardInfo>(itemsSource.Where(x => x.CardType.ToString() == selectedFilter));\r\n\r\n" +
        "    var itemsToSelect = itemsSource.Where(x => x.CardType.ToString() == selectedFilter).ToList();\r\n\r\n" +
        "    collectionView.SelectedItems.Clear();\r\n" +
        "    foreach (var item in itemsToSelect)\r\n" +
        "    {\r\n" +
        "        collectionView.SelectedItems.Add(item);\r\n" +
        "    }\r\n\r\n" +
        "    // Refresh the CollectionView\r\n" +
        "    collectionView.ItemsSource = null;\r\n" +
        "    collectionView.ItemsSource = itemsSource;\r\n" +
        "}";

    [ObservableProperty]
    string cSharpTemplateSelector =
        "public class TemplateSelector : DataTemplateSelector\r\n" +
        "{\r\n" +
        "    #region [ Properties ]\r\n" +
        "    public DataTemplate NormalTemplate { get; set; }\r\n" +
        "    public DataTemplate SelectedTemplate { get; set; }\r\n" +
        "    // Add more templates as needed\r\n" +
        "    #endregion\r\n\r\n" +
        "    #region [ CTor ]\r\n" +
        "    public TemplateSelector()\r\n" +
        "    {\r\n" +
        "    }\r\n" +
        "    #endregion\r\n\r\n" +
        "    #region [ Override ]\\r\\n\" +" +
        "    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)\r\n" +
        "    {\r\n" +
        "        var collectionView = (CollectionView)container;\r\n" +
        "        var selectedItems = collectionView.SelectedItems;\r\n\r\n" +
        "        return selectedItems.Contains(item) ? SelectedTemplate : NormalTemplate;\r\n" +
        "    }\r\n" +
        "    #endregion\r\n" +
        "}";

    [ObservableProperty]
    string cSharpTemplateSelectorCollectionViewViewModel =
        "[ObservableProperty]\r\n" +
        "ObservableCollection<string> filterPickerItems;";

    [ObservableProperty]
    string xamlTemplateSelectorCollectionViewTemplate =
        "<ContentPage>\r\n" +
        "    <ContentPage.Resources>\r\n" +
        "        <DataTemplate x:Key=\"NormalItemTemplate\" \r\n" +
        "                      x:DataType=\"app:IGalleryCardInfo\">\r\n" +
        "            <Border Padding=\"5\"\r\n" +
        "                    BackgroundColor=\"{x:Static app:AppColors.BlackGrey}\"\r\n" +
        "                    Margin=\"5\">\r\n" +
        "                <Border.StrokeShape>\r\n" +
        "                    <RoundRectangle CornerRadius=\"5\" />\r\n" +
        "                </Border.StrokeShape>\r\n" +
        "                <Grid ColumnDefinitions=\"0.2*, 0.2*, 0.6*\" \r\n" +
        "                      HeightRequest=\"40\">\r\n" +
        "                    <Image Grid.Column=\"0\"\r\n" +
        "                           Source=\"{x:Binding ControlIcon}\"\r\n" +
        "                           VerticalOptions=\"Center\"/>\r\n" +
        "                    <Label Grid.Column=\"1\"\r\n" +
        "                           FontAttributes=\"Bold\"\r\n" +
        "                           LineBreakMode=\"TailTruncation\"\r\n" +
        "                           FontSize=\"14\"\r\n" +
        "                           Text=\"{x:Binding ControlName}\"\r\n" +
        "                           VerticalTextAlignment=\"Center\" \r\n" +
        "                           Style=\"{x:StaticResource ReverseTheme}\"/>\r\n" +
        "                    <Label Grid.Column=\"2\"\r\n" +
        "                           FontAttributes=\"Italic\"\r\n" +
        "                           LineBreakMode=\"TailTruncation\"\r\n" +
        "                           FontSize=\"12\"\r\n" +
        "                           VerticalTextAlignment=\"Center\"\r\n" +
        "                           Text=\"{x:Binding ControlDetail}\"\r\n" +
        "                           Style=\"{x:StaticResource ReverseTheme}\"/>\r\n" +
        "                </Grid>\r\n" +
        "            </Border>\r\n" +
        "        </DataTemplate>\r\n\r\n" +
        "        <DataTemplate x:Key=\"SelectedItemTemplate\" \r\n" +
        "                      x:DataType=\"app:IGalleryCardInfo\">\r\n" +
        "            <Border Padding=\"10\"\r\n" +
        "                    BackgroundColor=\"{x:Static app:AppColors.MauilandPrimary}\"\r\n" +
        "                    Margin=\"5\">\r\n" +
        "                <Border.StrokeShape>\r\n" +
        "                    <RoundRectangle CornerRadius=\"5\" />\r\n" +
        "                </Border.StrokeShape>\r\n" +
        "                <Grid ColumnDefinitions=\"0.2*, 0.2*, 0.6*\" \r\n" +
        "                      HeightRequest=\"60\">\r\n" +
        "                    <Image Grid.Column=\"0\"\r\n" +
        "                           Source=\"{x:Binding ControlIcon}\"\r\n" +
        "                           VerticalOptions=\"Center\"/>\r\n" +
        "                    <Label Grid.Column=\"1\"\r\n" +
        "                           FontAttributes=\"Bold\"\r\n" +
        "                           LineBreakMode=\"TailTruncation\"\r\n" +
        "                           FontSize=\"16\"\r\n" +
        "                           Text=\"{x:Binding ControlName}\"\r\n" +
        "                           VerticalTextAlignment=\"Center\" \r\n" +
        "                           Style=\"{x:StaticResource ReverseTheme}\"/>\r\n" +
        "                    <Label Grid.Column=\"2\"\r\n" +
        "                           FontAttributes=\"Italic\"\r\n" +
        "                           LineBreakMode=\"TailTruncation\"\r\n" +
        "                           FontSize=\"14\"\r\n" +
        "                           VerticalTextAlignment=\"Center\"\r\n" +
        "                           Text=\"{x:Binding ControlDetail}\"\r\n" +
        "                           Style=\"{x:StaticResource ReverseTheme}\"/>\r\n" +
        "                </Grid>\r\n" +
        "            </Border>\r\n" +
        "        </DataTemplate>\r\n\r\n" +
        "        <app:TemplateSelector x:Key=\"TemplateSelector\"\r\n" +
        "                              NormalTemplate=\"{StaticResource NormalItemTemplate}\"\r\n" +
        "                              SelectedTemplate=\"{StaticResource SelectedItemTemplate}\" />" +
        "    </ContentPage.Resources>\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string xamlTemplateSelectorCollectionView =
        "<Picker Title=\"Filter\" \r\n" +
        "        TitleColor=\"Blue\"\r\n" +
        "        ItemsSource=\"{x:Binding FilterPickerItems}\"\r\n" +
        "        SelectedIndexChanged=\"OnFilterItemChanged\"\r\n" +
        "        BackgroundColor=\"LightGray\"/>\r\n" +
        "<CollectionView x:Name=\"CollectionViewItemLayoutChanged\" \r\n" +
        "                ItemTemplate=\"{x:StaticResource TemplateSelector}\"\r\n" +
        "                ItemsSource=\"{x:Binding ControlGroupList, Mode=OneWay}\"\r\n" +
        "                SelectionMode=\"None\"\r\n" +
        "                HeightRequest=\"400\"/>";
    #endregion

    #region [ CTor ]
    public CollectionViewPageViewModel(IAppNavigator appNavigator,
                                       IControlsService mauiControlsService,
                                       IMrIncreadibleMemeService memeService)
                                    : base(appNavigator)
    {
        this.MauiControlsService = mauiControlsService;
        this.MemeService = memeService;
    }
    #endregion

    #region [ Override ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

        LoadDataAsync().FireAndForget();
    }
    #endregion

    #region [ Relay Commands ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    void CollectionSwipeViewDelete(MrIncreadible mrIncreadible)
    {
        if (MrIncreadibles.Contains(mrIncreadible))
            MrIncreadibles.Remove(mrIncreadible);
    }

    [RelayCommand]
    void CollectionSwipeViewFavorite(MrIncreadible mrIncreadible)
    {
        mrIncreadible.IsFavorite = !mrIncreadible.IsFavorite;
    }

    [RelayCommand]
    void Refresh()
    {
        IsRefreshing = true;

        LoadDataAsync().FireAndForget();

        IsRefreshing = false;
    }

    [RelayCommand]
    void SingleSelectCollectionView()
    {
        if (CurrentSingleSelectedItemLabel is not null)
            PreviousSingleSelectedItemLabel = CurrentSingleSelectedItemLabel;
        CurrentSingleSelectedItemLabel = SingleSelectedControlInformation.ControlName;
    }

    [RelayCommand]
    void MultipleSelectCollectionView()
    {
        if (CurrentMultipleSelectedItemLabel is not null)
            PreviousMultipleSelectedItemLabel = CurrentMultipleSelectedItemLabel;
        if (MultipleSelectedControlInformationList is not null)
        {
            ObservableCollection<IGalleryCardInfo> itemList = new();
            foreach (var item in MultipleSelectedControlInformationList)
            {
                if (item is IGalleryCardInfo galleryCardInfo)
                {
                    itemList.Add(galleryCardInfo);
                }
            }
            CurrentMultipleSelectedListItemLabel = string.Join(", ", itemList.Select(item => item.ControlName.ToString()));

            if (MultipleSelectedControlInformationList.Count() != 0)
            {
                CurrentMultipleSelectedItemLabel = itemList.Last().ControlName;
            }
        }
    }
    #endregion

    #region [ Event ]
    public event PropertyChangedEventHandler SpanningNumberChanged;

    protected virtual void OnSpanningNumberChangedEvent([CallerMemberName] string propertyName = null)
    {
        SpanningNumberChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion

    #region [ Methods ]
    partial void OnSpanningNumberChanged(int value)
    {
        OnSpanningNumberChangedEvent(nameof(SpanningNumber));
    }
    #endregion

    #region [ Data ]
    private async Task LoadDataAsync()
    {
        ControlGroupList = new ObservableCollection<IGalleryCardInfo>();
        ControlGroupList.Clear();
        FilterPickerItems = Enum.GetNames(typeof(GalleryCardType)).ToObservableCollection();

        var items = await MauiControlsService.GetControlsAsync(ControlInformation.GroupName);
        foreach (var item in items)
        {
            ControlGroupList.Add(item);
        }

        IDictionary<double, ImageSource> images = MemeService.GetAllMemeImage();
        IDictionary<double, string> titles = MemeService.GetAllMemeTitle();

        MrIncreadibles = new ObservableCollection<MrIncreadible>();

        foreach (var key in titles.Keys)
        {
            if (images.ContainsKey(key))
            {
                MrIncreadibles.Add(new MrIncreadible
                {
                    Age = key,
                    Title = titles[key],
                    Image = images[key],
                    IsFavorite = false
                });
            }
        }
        return;
    }
    #endregion

}