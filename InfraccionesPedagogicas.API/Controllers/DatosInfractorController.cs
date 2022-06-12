using AutoMapper;
using InfraccionesPedagogicas.Application.DTOs;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InfraccionesPedagogicas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosInfractorController : Controller
    {
        private readonly IDatosInfractorService _datosInfractorService;
        private readonly IMapper _mapper;

        public DatosInfractorController(IDatosInfractorService datosInfractorService, IMapper mapper)
        {
            _datosInfractorService = datosInfractorService;
            _mapper = mapper;
        }

        [HttpGet("{Documento}")]
        public async Task<IActionResult> GetDatosInfractor(string Documento)
        {
            var datosInfractor = await _datosInfractorService.GetByDocumentoInfractor(Documento);
            var datosInfractorDto = _mapper.Map<DatosInfractorDTO>(datosInfractor);
            return Ok(datosInfractorDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSala(CreateDatosInfractorDTO dto)
        {
            var datosInfractor = _mapper.Map<DatosInfractor>(dto);
            await _datosInfractorService.Add(datosInfractor);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSala(UpdateDatosInfractorDTO dto)
        {
            var datosInfractor = _mapper.Map<DatosInfractor>(dto);
            await _datosInfractorService.Update(datosInfractor);
            return Ok();
        }
    }
}
