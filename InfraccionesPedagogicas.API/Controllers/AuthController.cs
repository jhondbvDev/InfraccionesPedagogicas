
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
        private readonly IInfractorService _infractorService;
        private const string emailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$";

        public AuthController(IIdentityService identityService, 
            IConfiguration configuration,
            ITokenService tokenService,
            IInfractorService infractorService)
        {
            _identityService = identityService;
            _configuration = configuration;
            _tokenService = tokenService;
            _infractorService = infractorService;
        }

        [HttpPost("registerUser")]
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
