using CommunityToolkit.Mvvm.ComponentModel;
namespace MAUIsland;

public partial class ChatMessageModel : BaseModel
{
    [ObservableProperty]
    string chatMessageContent;

    [ObservableProperty]
    ImageSource authorImage;

    [ObservableProperty]
    string authorName;

    [ObservableProperty]
    string authorFullName;

    [ObservableProperty]
    DateTime sentTime;
}
