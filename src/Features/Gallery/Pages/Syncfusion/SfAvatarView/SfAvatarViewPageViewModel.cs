using System.ComponentModel;

namespace MAUIsland;
public partial class SfAvatarViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public SfAvatarViewPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IControlInfo controlInformation;

    [ObservableProperty]
    ObservableCollection<Employee> collectionImages;

    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();
        CollectionImages = new ObservableCollection<Employee>();
        CollectionImages.Add(new Employee { Name = "Charlie", ImageSource = "https://i.imgur.com/UPKRRWz.jpg", Colors = Colors.Gray });
        CollectionImages.Add(new Employee { Name = "John", ImageSource = "https://i.imgur.com/wYB5zD1.jpg", Colors = Colors.Bisque });
        CollectionImages.Add(new Employee { Name = "Justin", ImageSource = "https://i.imgur.com/yi64vKP.jpg", Colors = Colors.LightCoral });
    }
    #endregion
}
public class Employee
{

    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string imagesource;

    public string ImageSource
    {
        get { return imagesource; }
        set { imagesource = value; }
    }

    private Color colors;

    public Color Colors
    {
        get { return colors; }
        set { colors = value; }
    }

}
