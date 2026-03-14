namespace Domain.Entities;

public class User
{
    public int UserId { get; set; }
    public String Email { get; set; }
    public String PushToken { get; set; }
    public String PublicKey { get; set; }

    public List<Challenge> Challenges { get; set; }

    public User(string email, string pushToken, string publicKey)
    {
        Email = email;
        PushToken = pushToken;
        PublicKey = publicKey;
    }
}