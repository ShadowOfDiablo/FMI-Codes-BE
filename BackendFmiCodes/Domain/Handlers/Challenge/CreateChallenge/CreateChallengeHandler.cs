using MediatR;

namespace Domain.Handlers;

public class CreateChallengeHandler : IRequestHandler<CreateChallengeRequest, string>
{
    public Task<string> Handle(CreateChallengeRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}