using Domain.Handlers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Features;

//[Authorize]
[ApiController]
[Route("[controller]")]
public class PrivateController : ControllerBase
{
    private readonly IMediator _mediator;

    public PrivateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
            var isSuccess = await _mediator.Send(request);
            return Ok(isSuccess);
    }
    
    [HttpPost("compareSignature")]
    public async Task<IActionResult> CompareSignature([FromBody] CompareSignatureRequest request)
    {
        try
        {
            var isCorrect = await _mediator.Send(request);
            return Ok(isCorrect);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}