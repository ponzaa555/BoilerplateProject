using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Authentication.Commands.Login
{
    public record LoginCommand(string username , string password):IRequest<LoginCommandResponse>;
}