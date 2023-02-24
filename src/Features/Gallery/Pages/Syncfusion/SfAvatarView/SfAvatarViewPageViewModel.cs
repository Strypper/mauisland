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
    SfAvatarViewTestUserModel selectedTotechsMember;

    [ObservableProperty]
    ObservableCollection<Employee> collectionImages;

    [ObservableProperty]
    ObservableCollection<SfAvatarViewTestUserModel> totechsMembers;

    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();
        CollectionImages = new();
        CollectionImages.Add(new Employee { Name = "Teddy", ImageSource = "https://i.imgur.com/fixi8ti.jpg", Colors = Colors.Gray });
        CollectionImages.Add(new Employee { Name = "Wolf", ImageSource = "https://i.imgur.com/mauGXij.png", Colors = Colors.Bisque });
        CollectionImages.Add(new Employee { Name = "Monkey", ImageSource = "https://i.imgur.com/O9SgXez.jpg", Colors = Colors.LightCoral });

        TotechsMembers = new();
        TotechsMembers.Add(new SfAvatarViewTestUserModel() { Name = "Strypper Vandel Jason", AvatarUrl = "https://totechsintranet.blob.core.windows.net/team-members/Me(ver 2019).jpg" });
        TotechsMembers.Add(new SfAvatarViewTestUserModel() { Name = "Tran Tien Dat", AvatarUrl = "https://totechsintranet.blob.core.windows.net/team-members/Dat.png" });
        TotechsMembers.Add(new SfAvatarViewTestUserModel() { Name = "Luanderson Airton", AvatarUrl = "https://totechsintranet.blob.core.windows.net/team-members/Luan.jpg" });
        TotechsMembers.Add(new SfAvatarViewTestUserModel() { Name = "Ho Dac Toan", AvatarUrl = "https://totechsintranet.blob.core.windows.net/team-members/Toan.jpg" });
    }
    #endregion
}
public partial class Employee : BaseModel
{
    [ObservableProperty]
    string name;

    [ObservableProperty]
    string imageSource;

    [ObservableProperty]
    Color colors;
}
