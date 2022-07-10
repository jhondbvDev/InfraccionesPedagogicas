using AutoMapper;
using InfraccionesPedagogicas.Application.DTOs;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace InfraccionesPedagogicas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfractorController : Controller
    {
        private readonly IInfractorService _infractorService;
        private readonly IMapper _mapper;
        public InfractorController(IInfractorService infractorService, IMapper mapper )
        {
            _infractorService = infractorService;
            _mapper=mapper;
        }

        [HttpGet("getInfractor/{infractorId}")]
        public async Task<IActionResult> GetInfractor(string infractorId)
        {
            var infractor = await _infractorService.GetById(infractorId);
            if(infractor == null)
            {
                return NotFound("No existe ningun registro con este documento");
            }
            var infractorDto = _mapper.Map<InfractorDTO>(infractor);
            return Ok(infractorDto);
        }

    }
}
