using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MAUIsland;

public class LoginMessage : ValueChangedMessage<UserModel>
{
    public LoginMessage(UserModel value) : base(value)
    {

    }
}
