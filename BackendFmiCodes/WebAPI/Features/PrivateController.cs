using Domain.Handlers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Features;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PrivateController : ControllerBase
{
    private readonly IMediator _mediator;

    public PrivateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromQuery] string email, [FromQuery] string pushToken, [FromQuery] string publicKey)
    {
            var isSuccess = await _mediator.Send(new RegisterRequest(email,pushToken, publicKey));
            return Ok(isSuccess);
    }
    
    [HttpPut("compareSignature")]
    public async Task<IActionResult> CompareSignature([FromQuery] int challengeId, [FromQuery] string signature)
    {
        try
        {
            var isCorrect = await _mediator.Send(new CompareSignatureRequest(challengeId,signature));
            if (!isCorrect)
                return Unauthorized();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}