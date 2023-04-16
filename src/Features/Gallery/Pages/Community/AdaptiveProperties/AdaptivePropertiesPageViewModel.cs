namespace MAUIsland;
public partial class AdaptivePropertiesPageViewModel : NavigationAwareBaseViewModel
{
    #region [Fields]
    public List<Shelf> ShelfList { get; set; } = new();
    #endregion

    #region [CTor]
    public AdaptivePropertiesPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
        List<Product> productList = new();
        productList.Add(new Product { Name = "Product1", Description = "none", ImageUrl = "none", Price = "NotMuch" });
        productList.Add(new Product { Name = "Product2", Description = "none", ImageUrl = "none", Price = "NotMuch" });
        productList.Add(new Product { Name = "Product3", Description = "none", ImageUrl = "none", Price = "NotMuch" });
        productList.Add(new Product { Name = "Product4", Description = "none", ImageUrl = "none", Price = "NotMuch" });
        productList.Add(new Product { Name = "Product5", Description = "none", ImageUrl = "none", Price = "NotMuch" });

        ShelfList.Add(new Shelf(1) { Name = "cover1", ImageUrl = "none", ProductList = productList });
        ShelfList.Add(new Shelf(2) { Name = "cover2", ImageUrl = "none", ProductList = productList });
        ShelfList.Add(new Shelf(3) { Name = "cover3", ImageUrl = "none", ProductList = productList });
        ShelfList.Add(new Shelf(4) { Name = "cover4", ImageUrl = "none", ProductList = productList });

    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

    }
    #endregion

    #region [Model]
    public class Shelf
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<Product> ProductList { get; internal set; } = new List<Product>();

        public Shelf(int id)
        {
            Id = id;
        }
    }

    public class Product
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Price { get; set; }
    }
    #endregion
}