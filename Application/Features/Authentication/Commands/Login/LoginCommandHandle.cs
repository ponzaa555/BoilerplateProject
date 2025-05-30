using Application.Contract;
using Application.Contract.Authentication;
using Domain.Entity;
using MediatR;

namespace Application.Features.Authentication.Commands.Login;


public class LoginCommandHandle : IRequestHandler<LoginCommand, LoginCommandResponse>
{
    private readonly IAuthentication _authentication;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public LoginCommandHandle(IAuthentication authentication , IJwtTokenGenerator jwtTokenGenerator)
    {
        _authentication = authentication;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // throw new AuthenError(AuthenError.AU001 , "LoginCommandHandle");
        await Task.CompletedTask;
        string id = Guid.NewGuid().ToString();
        User user = new User
        {
            Id = id,
            FirstName = request.username,
            LastName = request.password,
            Email = "ponpon13173@gmail.com"
        };
        LoginCommandResponse response = new LoginCommandResponse
        {
            Token = _jwtTokenGenerator.GenerateToken(user)
        };
        return response;
    }
}