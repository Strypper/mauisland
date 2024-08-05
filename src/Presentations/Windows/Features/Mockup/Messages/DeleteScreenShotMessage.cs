using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MAUIsland.Mockup;

public class DeleteScreenShotMessage : ValueChangedMessage<PreviewImageModel>
{
    public DeleteScreenShotMessage(PreviewImageModel value) : base(value)
    {

    }
}
