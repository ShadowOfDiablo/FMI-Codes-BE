using Domain.CompareSignature.Dto;
using MediatR;

namespace Domain.CheckStatus.Helpers;

public class CheckChallengeStatusRequest : IRequest<JwtStatusDto>
{
    public int Id { get; set; }

    public CheckChallengeStatusRequest(int id)
    {
        Id = id;
    }
}