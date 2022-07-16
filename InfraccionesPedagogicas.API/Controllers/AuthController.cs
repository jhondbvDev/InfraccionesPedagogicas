
using InfraccionesPedagogicas.Application.DTOs;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InfraccionesPedagogicas.API.Controllers
{
    [EnableCors("InfraccionesCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;
        private readonly IInfractorService _infractorService;
        private readonly IConfiguration _configuration;

        public AuthController(IIdentityService identityService,
            ITokenService tokenService,
            IInfractorService infractorService,
            IConfiguration configuration)
        {
            _identityService = identityService;
            _tokenService = tokenService;
            _infractorService = infractorService;
            _configuration = configuration;
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

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            var connection = this._configuration.GetConnectionString("MySqlConnection");
            var properties = connection.Split(";");
            return Ok(string.Format("connected to : {0} {1} {2} ; environment : {3}", 
                properties[0], properties[1], properties[2],
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")));
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
