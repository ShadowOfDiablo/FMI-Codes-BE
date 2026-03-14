using Domain.Handlers;
using Domain.Handlers.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Features;
[ApiController]
[Route("[controller]")]
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
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }   
    }

    [HttpGet("login")]
    public async Task<IActionResult> Login([FromQuery] LoginRequest request)
    {
        try
        {
            var res = await _mediator.Send(request);
            return Ok(res); 
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}