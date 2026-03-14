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
        var challenge = _context.Challenges.FirstOrDefault(c => c.ChallengeId == request.ChallengeId);
        var user = _context.Users.FirstOrDefault(u => challenge != null && u.UserId == challenge.UserId);
        
        var isValid = user != null && challenge != null && HelperFunctions.CheckIsValidSignature(user.PublicKey,challenge.ChallengeCode, request.Signature);
        
        await _context.Challenges
            .Where(c => c.ChallengeId == request.ChallengeId)
            .ExecuteUpdateAsync(s => s.SetProperty(c => c.Status, 
                    c => isValid ? "approved" : "rejected"),
                cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return isValid;
    }
}