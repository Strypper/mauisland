namespace MAUIsland.Core;

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
