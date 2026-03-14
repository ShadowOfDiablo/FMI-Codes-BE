using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Handlers;

public class CompareSignatureHandler : IRequestHandler<CompareSignatureRequest, bool>
{
    public Task<bool> Handle(CompareSignatureRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}