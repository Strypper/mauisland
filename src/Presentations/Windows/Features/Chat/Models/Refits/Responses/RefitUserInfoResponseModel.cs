namespace MAUIsland;

//public record RefitUserInfoResponseModel(string guid,
//                                         string email,
//                                         string userName,
//                                         string bio,
//                                         string former,
//                                         string cardPic,
//                                         string isDisable,
//                                         string specialAward,
//                                         string phoneNumber,
//                                         string profilePic,
//                                         int like,
//                                         int friendly,
//                                         int funny,
//                                         int enthusiastic,
//                                         int relationship,
//                                         int signalRConnectionId)
//{ }
public class RefitUserInfoResponseModel
{
    public string guid { get; set; }
    public string userName { get; set; }
    public string email { get; set; }
    public string profilePic { get; set; }
    public string phoneNumber { get; set; }
}