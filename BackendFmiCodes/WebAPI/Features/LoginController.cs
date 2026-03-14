using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Features;


[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetFirstRequest")]
    public async Task<IActionResult> firstRequest()
    {
        return Ok("Hello world !!");
    }

}