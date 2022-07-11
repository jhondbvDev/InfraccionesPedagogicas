﻿using AutoMapper;
using InfraccionesPedagogicas.Application.DTOs;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InfraccionesPedagogicas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var sala = _mapper.Map<Sala>(dto);
            await _salaService.Add(sala);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSala(UpdateSalaDTO dto)
        {
            var sala = _mapper.Map<Sala>(dto);
            await _salaService.Update(sala);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSala(int id)
        {
            var result = await _salaService.Delete(id);
            return Ok(result);
        }
    }
}
