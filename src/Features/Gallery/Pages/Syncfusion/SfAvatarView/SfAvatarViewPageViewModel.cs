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
        CollectionImages.Add(new Employee { Name = "Teddy", ImageSource = "https://i.imgur.com/fixi8ti.jpg", Colors = Colors.Gray });
        CollectionImages.Add(new Employee { Name = "Wolf", ImageSource = "https://i.imgur.com/mauGXij.png", Colors = Colors.Bisque });
        CollectionImages.Add(new Employee { Name = "Monkey", ImageSource = "https://i.imgur.com/O9SgXez.jpg", Colors = Colors.LightCoral });
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
