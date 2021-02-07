using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Seguridad.Core.JWTLogic
{
    public class UserSesion : IUserSesion
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserSesion(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Task<string> GetUserSesion()
        {
            var userName = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == "username")?.Value;
            return Task.Run(() => userName);
        }
    }
}
