using Application.Contract.Authentication;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
public class TestGenerateToken : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public TestGenerateToken(IMediator mediator , IJwtTokenGenerator jwtTokenGenerator)

    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _mediator = mediator;
    }
    [HttpPost]
    public Task<IActionResult> TestToken ([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            throw new ArgumentException("Model error login", nameof(user));
        }
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        return Task.FromResult<IActionResult>(Ok(token));
    }
}