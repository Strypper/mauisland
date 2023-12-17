using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUIsland;


public partial class CollectionViewPageViewModel : NavigationAwareBaseViewModel
{
    readonly IList<Incredible> source;
    Incredible selectedIncredible;
    int selectionCount = 1;

    public IList<Incredible> EmptyIncredibles { get; private set; }

    public Incredible SelectedIncredible
    {
        get
        {
            return selectedIncredible;
        }
        set
        {
            if (selectedIncredible != value)
            {
                selectedIncredible = value;
            }
        }
    }

    #region [ Properties ]

    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    ObservableCollection<Incredible> incredibles;

    [ObservableProperty]
    ObservableCollection<object> selectedIncredibles;

    [ObservableProperty]
    int spanNumber = 1;

    [ObservableProperty]
    string collectionViewGridLayoutType = "<CollectionView\r\n x:Name=\"CollectionViewExample\"\r\n Grid.Row=\"1\"\r\n ItemTemplate=\"{x:StaticResource CollectionViewItemTemplate}\"\r\n ItemsSource=\"{x:Binding Incredibles,\r\n Mode=OneWay}\">\r\n <CollectionView.ItemsLayout>\r\n <GridItemsLayout\r\n HorizontalItemSpacing=\"30\"\r\n   Orientation=\"Vertical\"\r\n  Span=\"{x:Binding SpanNumber,\r\n                                                     Mode=OneWay}\"\r\n                                    VerticalItemSpacing=\"20\" />\r\n                            </CollectionView.ItemsLayout>\r\n                        </CollectionView>";

    [ObservableProperty]
    string collectionViewQuickLayoutConfigXAMLCode = "<CollectionView\r\n    ItemTemplate=\"{x:StaticResource CollectionViewItemTemplate}\"\r\n    ItemsLayout=\"VerticalGrid, 2\"\r\n    ItemsSource=\"{Binding Incredibles}\" />";

    public string SelectedIncredibleMessage { get; private set; }
    #endregion

    public ICommand DeleteCommand => new Command<Incredible>(RemoveIncredible);
    public ICommand FavoriteCommand => new Command<Incredible>(FavoriteIncredible);
    public ICommand FilterCommand => new Command<string>(FilterItems);
    public ICommand IncredibleSelectionChangedCommand => new Command(IncredibleSelectionChanged);

    #region [ CTor ]
    public CollectionViewPageViewModel(IAppNavigator appNavigator)
                                    : base(appNavigator)
    {
        source = new List<Incredible>();
    }
    #endregion

    #region [ Override ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

        CreateIncredibleCollection();

        selectedIncredible = Incredibles.Skip(3).FirstOrDefault();
        IncredibleSelectionChanged();

        SelectedIncredibles = new ObservableCollection<object>()
        {
            Incredibles[1], Incredibles[3], Incredibles[4]
        };
    }


    #endregion

    void CreateIncredibleCollection()
    {
        source.Add(new()
        {
            Name = "Baboon",
            Details = "Baboons are African and Arabian Old World incredibles belonging to the genus Papio, part of the subfamily Cercopithecinae.",
            ImageUrl = "mrincredibleblackwhite.png"
        });

        source.Add(new()
        {
            Name = "Capuchin Incredible",
            Details = "The capuchin incredibles are New World incredibles of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.",
            ImageUrl = "mrincredibleblackwhite1.png"
        });

        source.Add(new()
        {
            Name = "Blue Incredible",
            Details = "The blue incredible or diademed incredible is a species of Old World incredible native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia",
            ImageUrl = "mrincredibleblackwhite2.png"
        });

        source.Add(new()
        {
            Name = "Squirrel Incredible",
            Details = "The squirrel incredibles are the New World incredibles of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers.",
            ImageUrl = "mrincredibleblackwhite3.png"
        });

        source.Add(new()
        {
            Name = "Golden Lion Tamarin",
            Details = "The golden lion tamarin also known as the golden marmoset, is a small New World incredible of the family Callitrichidae.",
            ImageUrl = "mrincredibleblackwhite4.png"
        });

        source.Add(new()
        {
            Name = "Howler Incredible",
            Details = "Howler incredibles are among the largest of the New World incredibles. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae.",
            ImageUrl = "mrincredibleblackwhite5.png"
        });

        source.Add(new()
        {
            Name = "Japanese Macaque",
            Details = "The Japanese macaque, is a terrestrial Old World incredible species native to Japan. They are also sometimes known as the snow incredible because they live in areas where snow covers the ground for months each",
            ImageUrl = "mrincrediblesmile5.png"
        });

        source.Add(new()
        {
            Name = "Mandrill",
            Details = "The mandrill is a primate of the Old World incredible family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Gabon, Equatorial Guinea, and Congo.",
            ImageUrl = "mrincrediblesmile4.png"
        });

        source.Add(new()
        {
            Name = "Proboscis Incredible",
            Details = "The proboscis incredible or long-nosed incredible, known as the bekantan in Malay, is a reddish-brown arboreal Old World incredible that is endemic to the south-east Asian island of Borneo.",
            ImageUrl = "mrincrediblesmile3.png"
        });

        source.Add(new()
        {
            Name = "Red-shanked Douc",
            Details = "The red-shanked douc is a species of Old World incredible, among the most colourful of all primates. This incredible is sometimes called the \"costumed ape\" for its extravagant appearance. From its knees to its ankles it sports maroon-red \"stockings\", and it appears to wear white forearm length gloves. Its attire is finished with black hands and feet. The golden face is framed by a white ruff, which is considerably fluffier in males. The eyelids are a soft powder blue. The tail is white with a triangle of white hair at the base. Males of all ages have a white spot on both sides of the corners of the rump patch, and red and white genitals.",
            ImageUrl = "mrincrediblesmile2.png"
        });

        source.Add(new()
        {
            Name = "Gray-shanked Douc",
            Details = "The gray-shanked douc langur is a douc species native to the Vietnamese provinces of Quảng Nam, Quảng Ngãi, Bình Định, Kon Tum, and Gia Lai. The total population is estimated at 550 to 700 individuals. In 2016, Dr Benjamin Rawson, Country Director of Fauna & Flora International - Vietnam Programme, announced a discovery of an additional population of more than 500 individuals found in Central Vietnam, bringing the total population up to approximately 1000 individuals.",
            ImageUrl = "mrincrediblesmile1.png"
        });

        source.Add(new()
        {
            Name = "Golden Snub-nosed Incredible",
            Details = "The golden snub-nosed incredible is an Old World incredible in the Colobinae subfamily. It is endemic to a small area in temperate, mountainous forests of central and Southwest China. They inhabit these mountainous forests of Southwestern China at elevations of 1,500-3,400 m above sea level. The Chinese name is Sichuan golden hair incredible. It is also widely referred to as the Sichuan snub-nosed incredible. Of the three species of snub-nosed incredibles in China, the golden snub-nosed incredible is the most widely distributed throughout China.",
            ImageUrl = "mrincrediblesmile.png"
        });

        Incredibles = new ObservableCollection<Incredible>(source);
    }

    void FilterItems(string filter)
    {
        var filteredItems = source.Where(incredible => incredible.Name.ToLower().Contains(filter.ToLower())).ToList();
        foreach (var incredible in source)
        {
            if (!filteredItems.Contains(incredible))
            {
                Incredibles.Remove(incredible);
            }
            else
            {
                if (!Incredibles.Contains(incredible))
                {
                    Incredibles.Add(incredible);
                }
            }
        }
    }

    void IncredibleSelectionChanged()
    {
        SelectedIncredibleMessage = $"Selection {selectionCount}: {SelectedIncredible.Name}";
        OnPropertyChanged("SelectedIncredibleMessage");
        selectionCount++;
    }

    void RemoveIncredible(Incredible incredible)
    {
        if (Incredibles.Contains(incredible))
        {
            Incredibles.Remove(incredible);
        }
    }

    void FavoriteIncredible(Incredible incredible)
    {
        incredible.IsFavorite = !incredible.IsFavorite;
    }

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}


public class Incredible
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string Details { get; set; }
    public string ImageUrl { get; set; }
    public bool IsFavorite { get; set; }
}