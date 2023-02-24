namespace MAUIsland;
public partial class SfBadgeViewPageViewModel : NavigationAwareBaseViewModel
{
    #region [CTor]
    public SfBadgeViewPageViewModel(
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

    [ObservableProperty]
    string addingAContent = "<badge:SfBadgeView HorizontalOptions=\"Center\" VerticalOptions=\"Center\">\r\n                        <badge:SfBadgeView.Content>\r\n                            <Button\r\n                                HeightRequest=\"60\"\r\n                                Text=\"Primary\"\r\n                                WidthRequest=\"120\" />\r\n                        </badge:SfBadgeView.Content>\r\n                    </badge:SfBadgeView>";

    [ObservableProperty]
    string addingAContentSecond = "<badge:SfBadgeView HorizontalOptions=\"Center\" VerticalOptions=\"Center\">\r\n                        <badge:SfBadgeView.Content>\r\n                            <Button\r\n                                HeightRequest=\"60\"\r\n                                Text=\"Primary\"\r\n                                WidthRequest=\"120\" />\r\n                        </badge:SfBadgeView.Content>\r\n                    </badge:SfBadgeView>\r\n                    <Label Text=\"The following screenshot illustrates the result of the above code.\" />\r\n                    <badge:SfBadgeView\r\n                        BadgeText=\"20\"\r\n                        HeightRequest=\"85\"\r\n                        HorizontalOptions=\"Center\"\r\n                        VerticalOptions=\"Center\"\r\n                        WidthRequest=\"150\">\r\n                        <badge:SfBadgeView.Content>\r\n                            <Button\r\n                                HeightRequest=\"60\"\r\n                                Text=\"Primary\"\r\n                                WidthRequest=\"120\" />\r\n                        </badge:SfBadgeView.Content>\r\n                    </badge:SfBadgeView>";

    [ObservableProperty]
    string strokeCustomization = "<badge:SfBadgeView\r\n                        BadgeText=\"30\"\r\n                        HeightRequest=\"85\"\r\n                        HorizontalOptions=\"Center\"\r\n                        VerticalOptions=\"Center\"\r\n                        WidthRequest=\"150\">\r\n                        <badge:SfBadgeView.Content>\r\n                            <Button\r\n                                BackgroundColor=\"#d6d8d7\"\r\n                                HeightRequest=\"60\"\r\n                                Text=\"Primary\"\r\n                                TextColor=\"Black\"\r\n                                WidthRequest=\"120\" />\r\n                        </badge:SfBadgeView.Content>\r\n                        <badge:SfBadgeView.BadgeSettings>\r\n                            <badge:BadgeSettings Stroke=\"Orange\" StrokeThickness=\"2\" />\r\n                        </badge:SfBadgeView.BadgeSettings>\r\n                    </badge:SfBadgeView>";

    [ObservableProperty]
    string textCustomization = "<badge:SfBadgeView\r\n                        BadgeText=\"45\"\r\n                        HeightRequest=\"100\"\r\n                        HorizontalOptions=\"Center\"\r\n                        VerticalOptions=\"Center\"\r\n                        WidthRequest=\"170\">\r\n                        <badge:SfBadgeView.Content>\r\n                            <Button\r\n                                BackgroundColor=\"#d6d8d7\"\r\n                                HeightRequest=\"60\"\r\n                                Text=\"Primary\"\r\n                                TextColor=\"Black\"\r\n                                WidthRequest=\"120\" />\r\n                        </badge:SfBadgeView.Content>\r\n                        <badge:SfBadgeView.BadgeSettings>\r\n                            <badge:BadgeSettings TextColor=\"LightYellow\" TextPadding=\"10\" />\r\n                        </badge:SfBadgeView.BadgeSettings>\r\n                    </badge:SfBadgeView>";


    [ObservableProperty]
    string predefinedStyles = "<badge:SfBadgeView\r\n                        BadgeText=\"8\"\r\n                        HeightRequest=\"65\"\r\n                        HorizontalOptions=\"Center\"\r\n                        VerticalOptions=\"Center\"\r\n                        WidthRequest=\"75\">\r\n                        <badge:SfBadgeView.Content>\r\n                            <Image\r\n                                HeightRequest=\"70\"\r\n                                Source=\"https://i.imgur.com/mdBNR5T.png\"\r\n                                WidthRequest=\"60\" />\r\n                        </badge:SfBadgeView.Content>\r\n                        <badge:SfBadgeView.BadgeSettings>\r\n                            <badge:BadgeSettings Type=\"Error\" />\r\n                        </badge:SfBadgeView.BadgeSettings>\r\n                    </badge:SfBadgeView>";


    [ObservableProperty]
    string badgeBackgroundCustomization = "<badge:SfBadgeView\r\n                        BadgeText=\"48\"\r\n                        HeightRequest=\"85\"\r\n                        HorizontalOptions=\"Center\"\r\n                        VerticalOptions=\"Center\"\r\n                        WidthRequest=\"150\">\r\n                        <badge:SfBadgeView.Content>\r\n                            <Button\r\n                                BackgroundColor=\"#d6d8d7\"\r\n                                HeightRequest=\"60\"\r\n                                Text=\"Primary\"\r\n                                TextColor=\"Black\"\r\n                                WidthRequest=\"120\" />\r\n                        </badge:SfBadgeView.Content>\r\n                        <badge:SfBadgeView.BadgeSettings>\r\n                            <badge:BadgeSettings Background=\"Green\" Type=\"None\" />\r\n                        </badge:SfBadgeView.BadgeSettings>\r\n                    </badge:SfBadgeView>";

    [ObservableProperty]
    string cornerRadiusOfTheBadge = "<badge:SfBadgeView\r\n                        BadgeText=\"100\"\r\n                        HeightRequest=\"85\"\r\n                        HorizontalOptions=\"Center\"\r\n                        VerticalOptions=\"Center\"\r\n                        WidthRequest=\"160\">\r\n                        <badge:SfBadgeView.Content>\r\n                            <Button\r\n                                BackgroundColor=\"#d6d8d7\"\r\n                                HeightRequest=\"60\"\r\n                                Text=\"Primary\"\r\n                                TextColor=\"Black\"\r\n                                WidthRequest=\"120\" />\r\n                        </badge:SfBadgeView.Content>\r\n                        <badge:SfBadgeView.BadgeSettings>\r\n                            <badge:BadgeSettings CornerRadius=\"5,5,5,5\" />\r\n                        </badge:SfBadgeView.BadgeSettings>\r\n                    </badge:SfBadgeView>";

    [ObservableProperty]
    string alignmentOfBadge = "<Grid\r\n                        ColumnDefinitions=\"*,*,*\"\r\n                        ColumnSpacing=\"5\"\r\n                        RowDefinitions=\"*\"\r\n                        RowSpacing=\"5\">\r\n                        <badge:SfBadgeView\r\n                            Grid.Row=\"0\"\r\n                            Grid.Column=\"0\"\r\n                            BadgeText=\"20\"\r\n                            HeightRequest=\"113\"\r\n                            HorizontalOptions=\"Center\"\r\n                            VerticalOptions=\"Center\"\r\n                            WidthRequest=\"176\">\r\n                            <badge:SfBadgeView.Content>\r\n                                <Label\r\n                                    Grid.Row=\"1\"\r\n                                    Grid.Column=\"1\"\r\n                                    BackgroundColor=\"LightGray\"\r\n                                    HeightRequest=\"70\"\r\n                                    HorizontalTextAlignment=\"Center\"\r\n                                    Text=\"START\"\r\n                                    TextColor=\"Black\"\r\n                                    VerticalTextAlignment=\"Center\"\r\n                                    WidthRequest=\"120\" />\r\n                            </badge:SfBadgeView.Content>\r\n                            <badge:SfBadgeView.BadgeSettings>\r\n                                <badge:BadgeSettings BadgeAlignment=\"Center\" CornerRadius=\"0\" />\r\n                            </badge:SfBadgeView.BadgeSettings>\r\n                        </badge:SfBadgeView>\r\n                        <badge:SfBadgeView\r\n                            Grid.Row=\"0\"\r\n                            Grid.Column=\"1\"\r\n                            BadgeText=\"20\"\r\n                            HeightRequest=\"80\"\r\n                            HorizontalOptions=\"Center\"\r\n                            VerticalOptions=\"Center\"\r\n                            WidthRequest=\"130\">\r\n                            <badge:SfBadgeView.Content>\r\n                                <Label\r\n                                    Grid.Row=\"1\"\r\n                                    Grid.Column=\"2\"\r\n                                    BackgroundColor=\"LightGray\"\r\n                                    HeightRequest=\"60\"\r\n                                    HorizontalTextAlignment=\"Center\"\r\n                                    Text=\"CENTER\"\r\n                                    TextColor=\"Black\"\r\n                                    VerticalTextAlignment=\"Center\"\r\n                                    WidthRequest=\"100\" />\r\n                            </badge:SfBadgeView.Content>\r\n                            <badge:SfBadgeView.BadgeSettings>\r\n                                <badge:BadgeSettings BadgeAlignment=\"Center\" CornerRadius=\"0\" />\r\n                            </badge:SfBadgeView.BadgeSettings>\r\n                        </badge:SfBadgeView>\r\n                        <badge:SfBadgeView\r\n                            Grid.Row=\"0\"\r\n                            Grid.Column=\"2\"\r\n                            BadgeText=\"20\"\r\n                            HeightRequest=\"60\"\r\n                            HorizontalOptions=\"Center\"\r\n                            VerticalOptions=\"Center\"\r\n                            WidthRequest=\"100\">\r\n                            <badge:SfBadgeView.Content>\r\n                                <Label\r\n                                    Grid.Row=\"1\"\r\n                                    Grid.Column=\"3\"\r\n                                    BackgroundColor=\"LightGray\"\r\n                                    HeightRequest=\"60\"\r\n                                    HorizontalTextAlignment=\"Center\"\r\n                                    Text=\"END\"\r\n                                    TextColor=\"Black\"\r\n                                    VerticalTextAlignment=\"Center\"\r\n                                    WidthRequest=\"100\" />\r\n                            </badge:SfBadgeView.Content>\r\n                            <badge:SfBadgeView.BadgeSettings>\r\n                                <badge:BadgeSettings BadgeAlignment=\"Center\" CornerRadius=\"0\" />\r\n                            </badge:SfBadgeView.BadgeSettings>\r\n                        </badge:SfBadgeView>\r\n                    </Grid>";

    [ObservableProperty]
    string positionCustomization = "<badge:SfBadgeView\r\n                            BadgeText=\"5\"\r\n                            HeightRequest=\"60\"\r\n                            HorizontalOptions=\"Center\"\r\n                            VerticalOptions=\"Center\"\r\n                            WidthRequest=\"140\">\r\n                            <badge:SfBadgeView.Content>\r\n                                <Button\r\n                                    BackgroundColor=\"#d6d8d7\"\r\n                                    HeightRequest=\"60\"\r\n                                    Text=\"Left\"\r\n                                    TextColor=\"Black\"\r\n                                    WidthRequest=\"120\" />\r\n                            </badge:SfBadgeView.Content>\r\n                            <badge:SfBadgeView.BadgeSettings>\r\n                                <badge:BadgeSettings Position=\"Left\" />\r\n                            </badge:SfBadgeView.BadgeSettings>\r\n                        </badge:SfBadgeView>";
    
    [ObservableProperty]
    string settingAbadgeOffset = "<badge:SfBadgeView\r\n                            BadgeText=\"8\"\r\n                            HeightRequest=\"70\"\r\n                            HorizontalOptions=\"Center\"\r\n                            VerticalOptions=\"Center\"\r\n                            WidthRequest=\"60\">\r\n                            <badge:SfBadgeView.Content>\r\n                                <Image\r\n                                    HeightRequest=\"70\"\r\n                                    Source=\"https://i.imgur.com/mdBNR5T.png\"\r\n                                    WidthRequest=\"60\" />\r\n                            </badge:SfBadgeView.Content>\r\n                            <badge:SfBadgeView.BadgeSettings>\r\n                                <badge:BadgeSettings\r\n                                    Position=\"BottomRight\"\r\n                                    Type=\"Success\"\r\n                                    Offset=\"0,-1\" />\r\n                            </badge:SfBadgeView.BadgeSettings>\r\n                        </badge:SfBadgeView>";

    [ObservableProperty]
    string predefindedSymbols = "<badge:SfBadgeView HorizontalOptions=\"Center\" VerticalOptions=\"Center\">\r\n                            <badge:SfBadgeView.Content>\r\n                                <Image\r\n                                    HeightRequest=\"70\"\r\n                                    Source=\"https://i.imgur.com/mdBNR5T.png\"\r\n                                    WidthRequest=\"60\" />\r\n                            </badge:SfBadgeView.Content>\r\n                            <badge:SfBadgeView.BadgeSettings>\r\n                                <badge:BadgeSettings\r\n                                    Icon=\"Available\"\r\n                                    Position=\"BottomRight\"\r\n                                    Type=\"Success\"\r\n                                    Offset=\"-2, -2\" />\r\n                            </badge:SfBadgeView.BadgeSettings>\r\n                        </badge:SfBadgeView>";

    [ObservableProperty]
    string animationBasic = "";

    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IControlInfo>();

        TotechsMembers = new();
        TotechsMembers.Add(new SfAvatarViewTestUserModel() { Name = "Strypper Vandel Jason", AvatarUrl = "https://totechsintranet.blob.core.windows.net/team-members/Me(ver 2019).jpg" });
        TotechsMembers.Add(new SfAvatarViewTestUserModel() { Name = "Tran Tien Dat", AvatarUrl = "https://totechsintranet.blob.core.windows.net/team-members/Dat.png" });
        TotechsMembers.Add(new SfAvatarViewTestUserModel() { Name = "Luanderson Airton", AvatarUrl = "https://totechsintranet.blob.core.windows.net/team-members/Luan.jpg" });
        TotechsMembers.Add(new SfAvatarViewTestUserModel() { Name = "Ho Dac Toan", AvatarUrl = "https://totechsintranet.blob.core.windows.net/team-members/Toan.jpg" });


    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}