namespace MAUIsland;

public partial class ChatMessage : BaseModel
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
