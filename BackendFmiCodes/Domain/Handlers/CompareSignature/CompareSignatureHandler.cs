using Domain.Entities;
using Domain.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Domain.Handlers;

public class CompareSignatureHandler : IRequestHandler<CompareSignatureRequest, bool>
{
    private readonly FmiDatabaseConfig _context;

    public CompareSignatureHandler(FmiDatabaseConfig context)
    {
        _context = context;
    }
    public async Task<bool> Handle(CompareSignatureRequest request, CancellationToken cancellationToken)
    {
        var isValid = HelperFunctions.CheckIsValidSignature(request.ChallengeId, request.Signature);
        await _context.Challenges
            .Where(c => c.ChallengeId == request.ChallengeId)
            .ExecuteUpdateAsync(s => s.SetProperty(c => c.Status, 
                    c => isValid ? "approved" : "rejected"),
                cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return isValid;
    }
}