using MediatR;

namespace Domain.Handlers;

public class CheckChallengeStatusRequest : IRequest<string>
{
    public int Id { get; set; }

    public CheckChallengeStatusRequest(int id)
    {
        Id = id;
    }
}