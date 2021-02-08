using Api.Seguridad.Core.Dto;
using Api.Seguridad.Core.Entities;
using Api.Seguridad.Core.JWTLogic;
using Api.Seguridad.Core.Persistence;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Seguridad.Core.Application
{
    public class Register
    {
        public class UserRegisterCommand : IRequest<UserDto>
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class UserRegisterValidation : AbstractValidator<UserRegisterCommand>
        {
            public UserRegisterValidation()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Surname).NotEmpty();
                RuleFor(x => x.Username).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class UserRegisterHandler : IRequestHandler<UserRegisterCommand, UserDto>
        {
            private readonly SecurityContext _context;
            private readonly UserManager<User> _userManager;
            private readonly IMapper _mapper;
            private readonly IJwtGenerator _jwtRegister;

            public UserRegisterHandler(SecurityContext context, UserManager<User> userManager, IMapper mapper, IJwtGenerator jwtRegister)
            {
                _context = context;
                _userManager = userManager;
                _mapper = mapper;
                _jwtRegister = jwtRegister;
            }

            public async Task<UserDto> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
            {
                var existe = await _context.Users.Where(x => x.Email == request.Email).AnyAsync();
                if (existe)
                {
                    throw new Exception("El Email del usuario ya existe");
                }

                existe = await _context.Users.Where(x => x.UserName == request.Username).AnyAsync();
                if (existe)
                {
                    throw new Exception("El Username del usuario ya existe");
                }

                var user = new User
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    Email = request.Email,
                    UserName = request.Username
                };

                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    var UsuarioDto = _mapper.Map<User, UserDto>(user);
                    UsuarioDto.Token = await _jwtRegister.CreateToken(user);
                    return UsuarioDto;
                }

                throw new Exception("No se pudo registrar el usuario");
            }
        }
    }
}
