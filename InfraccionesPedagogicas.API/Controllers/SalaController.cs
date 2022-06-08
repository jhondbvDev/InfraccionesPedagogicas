using InfraccionesPedagogicas.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace InfraccionesPedagogicas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : Controller
    {
        private readonly ISalaService _salaService;
        public SalaController(ISalaService salaService)
        {
            _salaService = salaService;
        }
        [HttpGet]
        public async Task<IActionResult> GetSalas()
        {
            var salas = _salaService.GetAll();
            return Ok(salas);
        }
    }
}
