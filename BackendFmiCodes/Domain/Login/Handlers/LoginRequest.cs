using MediatR;

namespace Domain.Handlers.Login;

public class LoginRequest : IRequest<bool>
{
    public String Email { get; set; }
}