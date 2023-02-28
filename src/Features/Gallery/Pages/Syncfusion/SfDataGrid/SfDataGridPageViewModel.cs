namespace MAUIsland;
public partial class SfDataGridPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public SfDataGridPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    ObservableCollection<SfDataGridMockData> orderInfo;

    [ObservableProperty]
    string simpleDataGridXamlCode = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n<ContentPage xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n             xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n              xmlns:syncfusion=\"clr-namespace:Syncfusion.Maui.DataGrid;assembly=Syncfusion.Maui.DataGrid\"\r\n              xmlns:local=\"clr-namespace:GettingStarted\"\r\n             x:Class=\"GettingStarted.MainPage\">\r\n\r\n    <ContentPage.BindingContext>\r\n        <local:OrderInfoRepository x:Name=\"viewModel\" />\r\n    </ContentPage.BindingContext>\r\n\r\n    <ContentPage.Content>\r\n        <syncfusion:SfDataGrid x:Name=\"dataGrid\"\r\n                               ItemsSource=\"{Binding OrderInfoCollection}\">\r\n        </syncfusion:SfDataGrid>\r\n    </ContentPage.Content>\r\n</ContentPage>";

    [ObservableProperty]
    string definingColumnsXamlCode = "<syncfusion:SfDataGrid x:Name=\"dataGrid\"\r\n            ColumnWidthMode=\"Fill\"\r\n            AutoGenerateColumnsMode=\"None\"\r\n            ItemsSource=\"{Binding OrderInfoCollection}\">\r\n\r\n    <syncfusion:SfDataGrid.Columns>\r\n        <syncfusion:DataGridTextColumn HeaderText=\"ID\"\r\n                                   MappingName=\"OrderID\"/>\r\n        <syncfusion:DataGridTextColumn HeaderText=\"Customer\"\r\n                                   MappingName=\"CustomerID\"/>\r\n        <syncfusion:DataGridTextColumn MappingName=\"Customer\"/>\r\n        <syncfusion:DataGridTextColumn HeaderText=\"Country\"\r\n                                   MappingName=\"ShipCountry\"/>\r\n    </syncfusion:SfDataGrid.Columns>\r\n</syncfusion:SfDataGrid>";
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

        OrderInfo = new();

        GenerateOrders();

    }
    #endregion

    #region [Methods]
    public void GenerateOrders()
    {
        OrderInfo.Add(new SfDataGridMockData() { OrderId = "1001", CustomerId = "Maria Anders", Customer = "Germany", ShipCity = "ALFKI", ShipCountry = "Berlin" });
        OrderInfo.Add(new SfDataGridMockData() { OrderId = "1002", CustomerId = "Ana Trujillo", Customer = "Mexico", ShipCity = "ANATR", ShipCountry = "Mexico D}F." });
        OrderInfo.Add(new SfDataGridMockData() { OrderId = "1003", CustomerId = "Ant Fuller", Customer = "Mexico", ShipCity = "ANTON", ShipCountry = "Mexico D}F." });
        OrderInfo.Add(new SfDataGridMockData() { OrderId = "1004", CustomerId = "Thomas Hardy", Customer = "UK", ShipCity = "AROUT", ShipCountry = "London" });
        OrderInfo.Add(new SfDataGridMockData() { OrderId = "1005", CustomerId = "Tim Adams", Customer = "Sweden", ShipCity = "BERGS", ShipCountry = "London" });
        OrderInfo.Add(new SfDataGridMockData() { OrderId = "1006", CustomerId = "Hanna Moos", Customer = "Germany", ShipCity = "BLAUS", ShipCountry = "Mannheim" });
        OrderInfo.Add(new SfDataGridMockData() { OrderId = "1007", CustomerId = "Andrew Fuller", Customer = "France", ShipCity = "BLONP", ShipCountry = "Strasbourg" });
        OrderInfo.Add(new SfDataGridMockData() { OrderId = "1008", CustomerId = "Martin King", Customer = "Spain", ShipCity = "BOLID", ShipCountry = "Madrid" });
        OrderInfo.Add(new SfDataGridMockData() { OrderId = "1009", CustomerId = "Lenny Lin", Customer = "France", ShipCity = "BONAP", ShipCountry = "Marsiella" });
        OrderInfo.Add(new SfDataGridMockData() { OrderId = "1010", CustomerId = "John Carter", Customer = "Canada", ShipCity = "BOTTM", ShipCountry = "Lenny Lin" });
        OrderInfo.Add(new SfDataGridMockData() { OrderId = "1011", CustomerId = "Laura King", Customer = "UK", ShipCity = "AROUT", ShipCountry = "London" });
        OrderInfo.Add(new SfDataGridMockData() { OrderId = "1012", CustomerId = "Anne Wilson", Customer = "Germany", ShipCity = "BLAUS", ShipCountry = "Mannheim" });
        OrderInfo.Add(new SfDataGridMockData() { OrderId = "1013", CustomerId = "Martin King", Customer = "France", ShipCity = "BLONP", ShipCountry = "Strasbourg" });
        OrderInfo.Add(new SfDataGridMockData() { OrderId = "1014", CustomerId = "Gina Irene", Customer = "UK", ShipCity = "AROUT", ShipCountry = "London" });
    }
    #endregion
}

public partial class SfDataGridMockData : BaseModel
{
    [ObservableProperty]
    string orderId;

    [ObservableProperty]
    string customerId;

    [ObservableProperty]
    string customer;

    [ObservableProperty]
    string shipCity;

    [ObservableProperty]
    string shipCountry;
}