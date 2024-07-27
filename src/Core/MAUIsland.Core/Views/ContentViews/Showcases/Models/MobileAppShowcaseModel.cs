namespace MAUIsland.Core;

public partial class MobileAppShowcaseModel : BaseModel
{
    [ObservableProperty]
    PhoneModelEnum phoneModel;

    [ObservableProperty]
    ObservableCollection<MockupImage> images;
}
