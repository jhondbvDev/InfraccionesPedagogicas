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
        public IActionResult ProcessInfracciones(IFormFile file)
        {
            var result = _fileUploadService.ProcessFile(file);
            return Ok(result);
            
        }


    }
}
