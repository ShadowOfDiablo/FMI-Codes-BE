namespace Domain.Entities;

public class User
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string PushToken { get; set; }
    public string PublicKey { get; set; }

    public List<Challenge> Challenges { get; set; }
}