using Api.Seguridad.Core.Application;
using Api.Seguridad.Core.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Seguridad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _meadiator;

        public UserController(IMediator meadiator)
        {
            _meadiator = meadiator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(Register.UserRegisterCommand parameters)
        {
            return await _meadiator.Send(parameters);
        }
    }
}
