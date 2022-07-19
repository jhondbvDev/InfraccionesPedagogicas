using InfraccionesPedagogicas.Application.DTOs;
using InfraccionesPedagogicas.Application.Exceptions;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Application.Pagination;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace InfraccionesPedagogicas.API.Controllers
{
    [EnableCors("InfraccionesCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        private const string emailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$";

        public UsuarioController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]

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
                if (!await _identityService.IsUniqueEmail(dto.Email))
                {
                    throw new BadRequestException("El nombre de usuario y/o correo ya existe");
                }

                var roles = new List<string>();
                roles.Add(dto.Rol);
                var result = await _identityService.CreateUserAsync(dto.Email, dto.Password, dto.Email, dto.UserName, roles);

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

        [HttpGet("{userId}")]

        public async Task<List<GetUsersDTO>> GetUsers([FromQuery] PaginationFilter pagination,string userId)
        {
            var userDetails = await _identityService.GetAllUsersDetailsExceptLoggedUserAsync(pagination,userId);

            var userDetailsDTO = userDetails.Select(u => new GetUsersDTO
            {
                Id = u.id,
                Name = u.userName,
                Email = u.email,
                Rol = u.role
            }).ToList();

            return userDetailsDTO;
        }

        [HttpDelete("{userId}")]

        public async Task<IActionResult> DeleteUser(string userId)
        {
            var result = await _identityService.DeleteUserAsync(userId);

            if (result)
            {
                return Ok("Usuario eliminado con exito");
            }
            else
            {
                return BadRequest("Error al eliminar el usuario, intente nuevamente");
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
