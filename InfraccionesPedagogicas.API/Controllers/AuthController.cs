
using InfraccionesPedagogicas.Application.DTOs;
using InfraccionesPedagogicas.Application.Exceptions;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace InfraccionesPedagogicas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;

        public AuthController(IIdentityService identityService, ITokenService tokenService)
        {
            _identityService = identityService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("signIn")]
        public async Task<IActionResult> SignIn(LogInUserDTO userDto)
        {
            if(await _identityService.SigninUserAsync(userDto.UserName, userDto.Password))
            {
                var user = await _identityService.GetUserDetailsByUserNameAsync(userDto.UserName);
                var token =  _tokenService.GenerateJWTToken(user.userId, user.fullName,user.UserName, user.roles);
                return Ok(new { access_token= token });
            }
            else
            {
                return NotFound("El usuario no existe");
            }
        }
    }
}
