﻿using AutoMapper;
using InfraccionesPedagogicas.Application.DTOs;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InfraccionesPedagogicas.API.Controllers
{
    [EnableCors("InfraccionesCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InfraccionesController : ControllerBase
    {
        private readonly IInfraccionService _infraccionesService;
        private readonly IMapper _mapper;

        public InfraccionesController(IInfraccionService infraccionesService, IMapper mapper)
        {
            _infraccionesService = infraccionesService;
            _mapper = mapper;
        }

        [HttpGet("{infractorId}")]
        public async Task<IActionResult> GetInfracciones(string infractorId)
        {
            var infracciones = await _infraccionesService.GetByInfractorId(infractorId);
            var infraccionesDto = _mapper.Map<List<InfraccionDTO>>(infracciones);
            return Ok(infraccionesDto);
        }
    }
}
