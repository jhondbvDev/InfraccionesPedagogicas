using AutoMapper;
using InfraccionesPedagogicas.Application.DTOs;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace InfraccionesPedagogicas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfraccionesController : ControllerBase
    {
        private readonly IInfraccionService _infraccionesService;
        private readonly IMapper _mapper;

        public InfraccionesController(IInfraccionService infraccionesService, IMapper mapper)
        {
            _infraccionesService = infraccionesService;
            _mapper = mapper;
        }

        [HttpGet("{Documento}")]
        public async Task<IActionResult> GetInfracciones(string Documento)
        {
            var infracciones = await _infraccionesService.GetByDocumentoInfractor(Documento);
            var infraccionesDto = _mapper.Map<List<InfraccionDTO>>(infracciones);
            return Ok(infraccionesDto);
        }
    }
}
