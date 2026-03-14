using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Handlers;

public class CompareSignatureRequest : IRequest<bool>
{
    public int ChallengeId { get; set; }
    public string Signature { get; set; }

    public CompareSignatureRequest(int challengeId, string signature)
    {
        ChallengeId = challengeId;
        Signature = signature;
    }
}