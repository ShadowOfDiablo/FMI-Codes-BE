namespace Domain.Entities.Dtos;

public class UserIdAndPushToken
{
    public string PushToken { get; set; }
    public int UserId { get; set; }

    public UserIdAndPushToken(string? pushToken, int userId)
    {
        if (pushToken == null)
        {
            throw new Exception("Can't find PushToken");
        }
        PushToken = pushToken;
        UserId = userId;
    }
}