using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;

namespace Application.Contract.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}