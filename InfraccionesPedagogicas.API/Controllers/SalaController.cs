using AutoMapper;
using InfraccionesPedagogicas.Application.DTOs;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InfraccionesPedagogicas.API.Controllers
{
    [EnableCors("InfraccionesCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalaController : Controller
    {
        private readonly ISalaService _salaService;
        private readonly IMapper _mapper;
        public SalaController(ISalaService salaService, IMapper mapper)
        {
            _salaService = salaService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetSalas()
        {
            var salas = await _salaService.GetAll();
            var salasDto = _mapper.Map<List<SalaDTO>>(salas);
            return Ok(salasDto);
        }

        [HttpGet("Deep")]
        public async Task<IActionResult> GetSalasDeep()
        {
            var salas = await _salaService.GetAllDeep();
            var salasDto = _mapper.Map<List<SalaDTO>>(salas);
            return Ok(salasDto);
        }

        [HttpGet("Deep/User/{userId}")]
        public async Task<IActionResult> GetSalasForUserDeep(string userId)
        {
            var salas = await _salaService.GetDeepForUser(userId);
            var salasDto = _mapper.Map<List<SalaDTO>>(salas);
            return Ok(salasDto);
        }

        [HttpGet("Deep/{salaId}")]
        public async Task<IActionResult> GetSalaDeep(int salaId)
        {
            var sala = await _salaService.GetDeep(salaId);
            var salasDto = _mapper.Map<SalaDTO>(sala);
            return Ok(salasDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSala(int id)
        {
            var sala = await _salaService.GetById(id);
            var salaDTO = _mapper.Map<SalaDTO>(sala);
            return Ok(salaDTO);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSala(CreateSalaDTO dto)
        {
            try
            {
                var sala = _mapper.Map<Sala>(dto);
                await _salaService.Add(sala);
                return Ok("Sala creada con exito");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSala(UpdateSalaDTO dto)
        {
            var sala = _mapper.Map<Sala>(dto);
            await _salaService.Update(sala);
            return Ok("Sala actualizada con exito");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSala(int id)
        {
            var result = await _salaService.Delete(id);
            return Ok(result);
        }
    }
}
