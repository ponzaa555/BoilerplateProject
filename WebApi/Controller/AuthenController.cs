using Application.Features.Authentication.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Handler;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthenController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("version")]
        public async Task<IActionResult> GetVersion()
        {
            string version = "8.1.0";
            return await Task.FromResult(Ok(version));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommandRequest request)
        {
            if(!ModelState.IsValid)
            {   
                throw new CustomValidation("Model error login" , ModelState);
            }
            var command = new LoginCommand(request.Username , request.Password);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("throw")]
        public IActionResult ThrowException()
        {
            throw new Exception("This is a test exception from controller.");
        }
    }
}