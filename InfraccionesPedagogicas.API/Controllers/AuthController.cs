
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
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        private const string emailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$";

        public AuthController(IIdentityService identityService, IConfiguration configuration, ITokenService tokenService)
        {
            _identityService = identityService;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("registerUser")]
        
        public async Task<IActionResult> RegisterUser(UserDTO dto)
        {
            try
            {
                if (!IsValidEmailAddress(dto.Email))
                {
                    throw new BadRequestException("Ingrese un email valido"); 
                }

                if (!PasswordContainsRequiredNonAlphanumericCharacters(dto.Password))
                {
                    throw new BadRequestException("El password debe contener al menos uno de los siguientes caracteres :!, @, #, ? or ]");
                }
                if(!await _identityService.IsUniqueEmail(dto.Email))
                {
                    throw new BadRequestException("El nombre de usuario y/o correo ya existe");
                }

                var roles = new List<string>();
                roles.Add(dto.Rol);
                var result =await _identityService.CreateUserAsync(dto.Email, dto.Password, dto.Email, dto.UserName,roles);
                 
                if (result.isSucceed)
                {
                    return Ok("Usuario creado exitosamente");
                }
                else
                {
                    return BadRequest("El usuario no se pudo crear , intentelo de nuevo .");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
        private bool IsValidEmailAddress(string email)
        {
            return Regex.IsMatch(email, emailRegex);
        }
        private bool PasswordContainsRequiredNonAlphanumericCharacters(string password)
        {
            return password.Contains('!') || password.Contains('.') || password.Contains('@') || password.Contains('#') || password.Contains('?') || password.Contains(']');
        }
    }
}
