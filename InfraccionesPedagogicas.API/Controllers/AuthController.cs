
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
        private readonly IInfractorService _infractorService;

        public AuthController(IIdentityService identityService,
            ITokenService tokenService,
            IInfractorService infractorService)
        {
            _identityService = identityService;
            _tokenService = tokenService;
            _infractorService = infractorService;
        }

        [HttpPost("generateToken")]
        public async Task<IActionResult> GenerateToken(string document)
        {
            var infractor = await _infractorService.GetById(document);
            if (infractor != null)
            {
                //generate token
                var token = _tokenService
                    .GenerateJWTToken(infractor.Id, 
                    string.Format("{0} {1}",
                    infractor.Nombre, string.Empty),
                    infractor.Nombre, new List<string>(),Application.Enums.UserType.Public);
                return Ok(new { access_token = token });
            }
            else
            {
                return NotFound("Documento no existe");
            }
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn(LogInUserDTO userDto)
        {
            if(await _identityService.SigninUserAsync(userDto.UserName, userDto.Password))
            {
                var user = await _identityService.GetUserDetailsByUserNameAsync(userDto.UserName);
                var token =  _tokenService.GenerateJWTToken(user.userId, user.fullName,user.UserName, user.roles,Application.Enums.UserType.Private);
                return Ok(new { access_token= token });
            }
            else
            {
                return NotFound("El usuario no existe");
            }
        }
    }
}
