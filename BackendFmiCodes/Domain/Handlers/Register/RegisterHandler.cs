using MediatR;

namespace Domain.Handlers;

public class RegisterHandler : IRequestHandler<RegisterRequest,bool>
{
    public Task<bool> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}