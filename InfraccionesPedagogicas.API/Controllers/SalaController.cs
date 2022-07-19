using AutoMapper;
using InfraccionesPedagogicas.Application.DTOs;
using InfraccionesPedagogicas.Application.Interfaces;
using InfraccionesPedagogicas.Application.Pagination;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Application.Response;
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
        public async Task<IActionResult> GetSalasForUserDeep( [FromQuery]PaginationFilter pagination, string userId)
        {
            var salas = await _salaService.GetDeepForUser(pagination,userId);
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
            try
            {
                var result = await _salaService.Delete(id);
                return Ok(new Response<bool>(result,Application.Enums.ResponseStatus.Success,"Sala eliminada exitosamente."));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<bool>(false,Application.Enums.ResponseStatus.Error,ex.Message));
            }
            
        }
    }
}
