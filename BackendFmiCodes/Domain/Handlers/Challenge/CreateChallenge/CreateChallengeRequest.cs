using MediatR;

namespace Domain.Handlers;

public class CreateChallengeRequest : IRequest<string>
{
    public string Email { get; set; }

    public CreateChallengeRequest(string email)
    {
        Email = email;
    }
}