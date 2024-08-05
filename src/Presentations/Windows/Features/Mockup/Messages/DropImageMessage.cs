using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MAUIsland.Mockup;

public class DropImageMessage : ValueChangedMessage<DropImageType>
{
    public DropImageMessage(DropImageType value) : base(value)
    {
    }
}

public class DropImageType
{
    public string CollectionViewId { get; set; }
    public Object Sender { get; set; }
    public DropEventArgs Args { get; set; }
    public DroppedImage Payload { get; set; }
}
