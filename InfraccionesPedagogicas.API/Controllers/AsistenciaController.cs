using AutoMapper;
using InfraccionesPedagogicas.Application.DTOs;
using InfraccionesPedagogicas.Application.Exceptions;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfraccionesPedagogicas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AsistenciaController : ControllerBase
    {
        private readonly IAsistenciaService _asistenciaService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        public AsistenciaController(IAsistenciaService asistenciaService, IEmailService emailService, IMapper mapper)
        {
            _asistenciaService = asistenciaService;
            _emailService = emailService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsistencia()
        {
            var salas = await _asistenciaService.GetAll();
            var salasDto = _mapper.Map<List<AsistenciaDTO>>(salas);
            return Ok(salasDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsistencia(int id)
        {
            var asistencia = await _asistenciaService.GetById(id);
            var asistenciaDto = _mapper.Map<AsistenciaDTO>(asistencia);
            return Ok(asistenciaDto);
        }
        [HttpGet("getAsistenciaByInfractor/{infractorId}")]
        public async Task<IActionResult> GetAsistenciaByInfractor(string infractorId)
        {
            var asistencia = await _asistenciaService.GetAsistenciaByInfractor(infractorId);
            var asistenciaDto = _mapper.Map<AsistenciaDTO>(asistencia);

            return Ok(asistenciaDto);
        }

        [HttpGet("getAsistenciasBySala/{salaId}")]
        public async Task<IActionResult> GetAsistenciasBySala(int salaId)
        {
            var asistencias = await _asistenciaService.GetAsistenciaBySala(salaId);
            var asistenciaDto = asistencias.Select(asistencia => new AsistenciaDeepDTO
            {
                Asistio = asistencia.Asistio,
                Id = asistencia.Id,
                NombreInfractor = asistencia.Infractor.Nombre
            });
            return Ok(asistenciaDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsistencia(CreateAsistenciaDTO dto)
        {
            try
            {
                var asistencia = _mapper.Map<Asistencia>(dto);
                await _asistenciaService.Add(asistencia);
                var asistenciaDto = _mapper.Map<AsistenciaDTO>(asistencia);
                //await _emailService.SendConfirmationEmail(null);

                return Ok(asistenciaDto);
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
        
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsistencia(UpdateAsistenciaDTO dto)
        {
            try
            {
                var sala = _mapper.Map<Asistencia>(dto);
                await _asistenciaService.Update(sala);
                return Ok();
            }
            catch{
                return BadRequest("Error durante la actualizacion de la asistencia, intente nuevamente");
            }
        }

        [HttpGet("hasRegisteredInfractores/{salaId}")]
        public async Task<IActionResult> HasRegisteredInfractores(int salaId)
        {
            return Ok(await _asistenciaService.HasRegisteredInfractores(salaId));
        }
    }
}
