using AutoMapper;
using InfraccionesPedagogicas.Application.DTOs;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InfraccionesPedagogicas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var sala = await _asistenciaService.GetById(id);
            var salaDTO = _mapper.Map<AsistenciaDTO>(sala);
            return Ok(salaDTO);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsistencia(CreateAsistenciaDTO dto)
        {
            var sala = _mapper.Map<Asistencia>(dto);
            await _asistenciaService.Add(sala);

            await _emailService.SendConfirmationEmail(null);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsistencia(UpdateAsistenciaDTO dto)
        {
            var sala = _mapper.Map<Asistencia>(dto);
            await _asistenciaService.Update(sala);
            return Ok();
        }
    }
}
