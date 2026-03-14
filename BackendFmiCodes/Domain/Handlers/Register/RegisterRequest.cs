using MediatR;

namespace Domain.Handlers;

public class RegisterRequest : IRequest<bool>
{
    public string Email { get; set; }
    public string PushToken { get; set; }
    public string PublicKey { get; set; }

    public RegisterRequest(string email, string pushToken, string publicKey)
    {
        Email = email;
        PushToken = pushToken;
        PublicKey = publicKey;
    }
}