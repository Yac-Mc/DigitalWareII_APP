using Api.Seguridad.Core.Dto;
using Api.Seguridad.Core.Entities;
using Api.Seguridad.Core.JWTLogic;
using Api.Seguridad.Core.Persistence;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Seguridad.Core.Application
{
    public class Login
    {
        public class UserLoginCommand : IRequest<UserDto>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class UsuarioLoginValidation : AbstractValidator<UserLoginCommand>
        {
            public UsuarioLoginValidation()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class UsuarioLoginHandler : IRequestHandler<UserLoginCommand, UserDto>
        {
            private readonly SecurityContext _context;
            private readonly UserManager<User> _userManager;
            private readonly IMapper _mapper;
            private readonly IJwtGenerator _jwtGenerator;
            private readonly SignInManager<User> _signInManager;

            public UsuarioLoginHandler(SecurityContext context, UserManager<User> userManager, IMapper mapper, IJwtGenerator jwtGenerator, SignInManager<User> signInManager)
            {
                _context = context;
                _userManager = userManager;
                _mapper = mapper;
                _jwtGenerator = jwtGenerator;
                _signInManager = signInManager;
            }

            public async Task<UserDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);

                if (user == null)
                {
                    throw new Exception("El usuario no existe");
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (result.Succeeded)
                {
                    var userDto = _mapper.Map<User, UserDto>(user);
                    userDto.Token = await _jwtGenerator.CreateToken(user);
                    return userDto;
                }

                throw new Exception("Login incorrecto");

            }
        }
    }
}
