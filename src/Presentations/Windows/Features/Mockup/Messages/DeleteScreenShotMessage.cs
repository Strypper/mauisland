using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MAUIsland.Mockup;

public class DeleteScreenShotMessage : ValueChangedMessage<ScreenshotModel>
{
    public DeleteScreenShotMessage(ScreenshotModel value) : base(value)
    {

    }
}
