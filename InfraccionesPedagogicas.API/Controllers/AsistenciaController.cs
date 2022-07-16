using AutoMapper;
using InfraccionesPedagogicas.Application.DTOs;
using InfraccionesPedagogicas.Application.Exceptions;
using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Org.BouncyCastle.Crypto;

namespace InfraccionesPedagogicas.API.Controllers
{
    [EnableCors("InfraccionesCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AsistenciaController : ControllerBase
    {
        private readonly IAsistenciaService _asistenciaService;
        private readonly ISalaService _salaService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        public AsistenciaController(IAsistenciaService asistenciaService, 
            ISalaService salaService,
            IEmailService emailService, 
            IMapper mapper)
        {
            _asistenciaService = asistenciaService;
            _emailService = emailService;
            _mapper = mapper;
            _salaService = salaService;
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
                NombreInfractor = asistencia.Infractor.Nombre + " " + asistencia.Infractor.Apellido
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

        [HttpGet("getAsistenciaExcelBySalaId/{salaId}")]
        public async Task<IActionResult> GetAsistenciaExcelBySalaId(int salaId)
        {
            var asistencias = await _asistenciaService.GetAsistenciaBySala(salaId);
            if (asistencias.Count() > 0)
            {
                var sala = _salaService.GetById(salaId);
                var list = asistencias.Select(a =>
                new
                {
                    Infractor = string.Format("{0} {1}", a.Infractor.Nombre, a.Infractor.Apellido),
                    Asistio = a.Asistio == true ? "Si" : "No"

                });

                var stream = new MemoryStream();

                using (var package = new ExcelPackage(stream))
                {
                    var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                    workSheet.Cells.LoadFromCollection(list, true);
                    package.Save();
                }
                HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
                stream.Position = 0;
                string excelName = $"Asistencias-{asistencias.First().Sala.Fecha.ToString()}.xlsx";

                //return File(stream, "application/octet-stream", excelName);
                var file = File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                return file;
            }
            else
            {
                throw new BusinessException("no hay datos de asistencia que exportar para esta sala.");
            }
        }
    }
}
