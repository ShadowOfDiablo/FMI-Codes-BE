using MediatR;

namespace Domain.Handlers;

public class CheckChallengeStatusHandler : IRequestHandler<CheckChallengeStatusRequest,string>
{
    public Task<string> Handle(CheckChallengeStatusRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}