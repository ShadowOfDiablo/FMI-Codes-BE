using Domain.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Features;

[ApiController]
[Route("api/[controller]")]
public class PublicController : ControllerBase
{
    private readonly IMediator _mediator;

    public PublicController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("checkChallengeStatus")]
    public async Task<IActionResult> CheckChallengeStatus([FromQuery] int id)
    {
        try
        {
            var challenge = await _mediator.Send(new CheckChallengeStatusRequest(id));
            return Ok(challenge);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }   
    }

    [HttpGet("createChallenge")]
    public async Task<IActionResult> CreateChallenge([FromQuery] string email)
    {
        try
        {
            var user = await _mediator.Send(new CreateChallengeRequest(email));
            return Ok(user);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}