using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Application.Interfaces.Services
{
    public  interface IFileUploadService
    {
        public bool ProcessFile(IFormFile file);
    }
}
