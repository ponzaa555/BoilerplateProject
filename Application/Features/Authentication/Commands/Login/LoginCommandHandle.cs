using Application.Exceptions;
using MediatR;

namespace  Application.Features.Authentication.Commands.Login;


public class LoginCommandHandle : IRequestHandler<LoginCommand, LoginCommandResponse>
{
    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        throw new AuthenError(AuthenError.AU001 , "LoginCommandHandle");
        LoginCommandResponse res = new();
        res.Token = "Test";
        return await Task.FromResult(res);
    }
}