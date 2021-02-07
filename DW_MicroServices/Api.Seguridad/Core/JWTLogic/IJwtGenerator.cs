using Api.Seguridad.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Seguridad.Core.JWTLogic
{
    public interface IJwtGenerator
    {
        Task<string> CreateToken(User user);
    }
}
