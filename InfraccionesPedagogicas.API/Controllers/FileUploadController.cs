using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace InfraccionesPedagogicas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploadService _fileUploadService;
        public FileUploadController(IFileUploadService fileUploadService)
        {
            _fileUploadService= fileUploadService;  
        }

        [HttpPost]
        public async Task<IActionResult> ProcessInfracciones(IFormFile file)
        {
            var result = _fileUploadService.ProcessFile(file);
            //string message = result==true?"Carga completada exitosamente":"Ocurrio un error al cargar los archivos";

            return Ok(result);
            
        }


    }
}
