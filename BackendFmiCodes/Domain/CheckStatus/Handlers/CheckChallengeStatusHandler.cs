using Domain.CheckStatus.Helpers;
using Domain.CompareSignature.Dto;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Domain.CheckStatus.JwtServices;

public class CheckChallengeStatusHandler : IRequestHandler<CheckChallengeStatusRequest, JwtStatusDto>
{
    private readonly FmiDatabaseConfig _context;
    private readonly JwtService _jwtService;

    public CheckChallengeStatusHandler(FmiDatabaseConfig context, JwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    public async Task<JwtStatusDto> Handle(CheckChallengeStatusRequest request, CancellationToken cancellationToken)
    {
        var challenge = await _context.Challenges.FirstOrDefaultAsync(c => c.ChallengeId == request.Id, cancellationToken);

        JwtStatusDto dto = new JwtStatusDto();
        dto.status = challenge.Status;

        if (dto.status == "approved")
            dto.jwt = "Bearer " + _jwtService.GenerateToken(challenge.ChallengeCode);
        else
            dto.jwt = "";

        return dto;
    }
}