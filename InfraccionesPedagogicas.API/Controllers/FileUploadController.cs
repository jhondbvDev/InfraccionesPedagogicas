using InfraccionesPedagogicas.Application.Interfaces.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InfraccionesPedagogicas.API.Controllers
{
    [EnableCors("InfraccionesCorsPolicy")]
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

            return Ok(result);
            
        }


    }
}
