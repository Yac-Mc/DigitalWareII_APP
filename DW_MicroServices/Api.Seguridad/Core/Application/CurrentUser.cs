using Api.Seguridad.Core.Dto;
using Api.Seguridad.Core.Entities;
using Api.Seguridad.Core.JWTLogic;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Seguridad.Core.Application
{
    public class CurrentUser
    {
        public class CurrentUserCommand : IRequest<UserDto> { }

        public class UsuarioActualHandler : IRequestHandler<CurrentUserCommand, UserDto>
        {
            private readonly UserManager<User> _userManager;
            private readonly IUserSesion _userSesion;
            private readonly IJwtGenerator _jwtGenerator;
            private readonly IMapper _mapper;

            public UsuarioActualHandler(UserManager<User> userManager, IUserSesion userSesion, IJwtGenerator jwtGenerator, IMapper mapper)
            {
                _userManager = userManager;
                _userSesion = userSesion;
                _jwtGenerator = jwtGenerator;
                _mapper = mapper;
            }

            public async Task<UserDto> Handle(CurrentUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(await _userSesion.GetUserSesion());
                if (user != null)
                {
                    var userDto = _mapper.Map<User, UserDto>(user);
                    userDto.Token = await _jwtGenerator.CreateToken(user);
                    return userDto;
                }

                throw new Exception("No se encontro el usuario");
            }
        }
    }
}
