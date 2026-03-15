using Domain.Login.Dtos;
using MediatR;

namespace Domain.Handlers.Login;

public class LoginRequest : IRequest<LoginDto>
{
    public String Email { get; set; }
}