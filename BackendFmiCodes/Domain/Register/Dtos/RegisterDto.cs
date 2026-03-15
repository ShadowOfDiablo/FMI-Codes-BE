namespace Domain.Register.Dtos;

public class RegisterDto
{
    public string Email { get; set; }
    public string PushToken { get; set; }
    public string PublicKey { get; set; }

    public RegisterDto(string email, string pushToken, string publicKey)
    {
        Email = email;
        PushToken = pushToken;
        PublicKey = publicKey;
    }
}