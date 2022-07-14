using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Core.Entities;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace InfraccionesPedagogicas.Application.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IInfractorService _infractorService;
        private readonly IInfraccionService _infraccionService;
        public FileUploadService(IInfraccionService infraccionService, IInfractorService infractorService)
        {
            _infraccionService = infraccionService;
            _infractorService = infractorService;
        }
        private bool ValidateFile(ExcelPackage file)
        {
            bool isValid = true;
            ExcelWorksheet worksheet = file.Workbook.Worksheets[0];
            string[] headers = { "NRO_COMPARENDO", "FECHA_COMPARENDO", "TIPO_COMPARENDO", "COD_INFRACCION", "ID_USUARIO", "NOMBRES", "APELLIDOS" };
            for (int i = 1; i < headers.Length+1; i++)
            {
                isValid = worksheet.Cells[1, i].Value.ToString().Trim() == headers[i-1];
                if (!isValid)
                    return isValid;
            }

            isValid = worksheet.Dimension.End.Row > 1;

            return isValid;
        }
        public bool ProcessFile(IFormFile file)
        {
            try
            {
                var listaInfractores = new List<Infractor>();
                var listaInfracciones = new List<Infraccion>();
                using var excelPorProcesar = file.OpenReadStream();
                using (var package = new ExcelPackage(excelPorProcesar))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    var isValidFile = ValidateFile(package);
                    if (!isValidFile)
                    {
                        return false;
                    }

                    for (int i = worksheet.Dimension.Start.Row + 1; i < worksheet.Dimension.End.Row; i++)
                    {
                        listaInfractores.Add(new Infractor
                        {
                            Id = worksheet.Cells[i, 5].Value.ToString(),
                            Nombre = worksheet.Cells[i, 6].Value.ToString(),
                            Apellido = worksheet.Cells[i, 7].Value.ToString(),
                        });

                        listaInfracciones.Add(new Infraccion
                        {
                            NumeroInfraccion = worksheet.Cells[i, 1].Value.ToString(),
                            Fecha = DateTime.ParseExact(worksheet.Cells[i, 2].Value.ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.AssumeLocal),
                            CodigoInfraccion = worksheet.Cells[i, 4].Value.ToString(),
                            InfractorId = worksheet.Cells[i, 5].Value.ToString()
                        });
                    }
                }

                if (listaInfractores.Count > 0)
                {
                    _infractorService.Bulk(listaInfractores).Wait();
                }

                if (listaInfracciones.Count > 0)
                {
                    _infraccionService.BulkAdd(listaInfracciones).Wait();
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
                //throw ex;
            }

        }

      
    }
}
