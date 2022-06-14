using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Application.Models;
using InfraccionesPedagogicas.Core.Entities;
using OfficeOpenXml;

namespace InfraccionesPedagogicas.BackgroundLoader
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;
        
        private readonly LoadPath _path;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider, LoadPath path)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _path = path;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Ejecucion de servicio de carga en segundo plano: {time}", DateTimeOffset.Now);

                await LoadInfracciones();

                await Task.Delay(3600000, stoppingToken);
            }
        }

        private async Task LoadInfracciones()
        {
            if (Directory.Exists(_path.InfraccionesDirectory))
            {
                var excelInfraccionesPath = Path.Combine(_path.InfraccionesDirectory, "comparendos pedagogicos.xlsx");
                var excelInfraccionesProcesadasPath = Path.Combine(_path.InfraccionesDirectory, "Procesados", $"comparendos_pedagogicos_{DateTime.Now.ToString("dd-MM-yyyy_HH.mm.ss")}.xlsx");

                if (File.Exists(excelInfraccionesPath))
                {
                    var listaInfractores = new List<Infractor>();
                    var listaInfracciones = new List<Infraccion>();

                    FileInfo excelPorProcesar = new FileInfo(excelInfraccionesPath);

                    using (var package = new ExcelPackage(excelPorProcesar))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

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
                                Fecha = DateTime.ParseExact(worksheet.Cells[i, 2].Value.ToString(), "dd/MM/yyyy", null),
                                CodigoInfraccion = worksheet.Cells[i, 4].Value.ToString(),
                                InfractorId = worksheet.Cells[i, 5].Value.ToString()
                            });
                        }
                    }

                    using(var scope = _serviceProvider.CreateScope())
                    {
                        IInfractorService infractorService = scope.ServiceProvider.GetRequiredService<IInfractorService>();
                        IInfraccionService infraccionService = scope.ServiceProvider.GetRequiredService<IInfraccionService>();

                        if (listaInfractores.Count > 0)
                        {
                            await infractorService.BulkDeleteOldRecords(listaInfractores);
                            await infractorService.BulkAdd(listaInfractores);
                        }

                        if (listaInfracciones.Count > 0)
                        {
                            await infraccionService.BulkAdd(listaInfracciones);
                        }
                    }

                    excelPorProcesar.MoveTo(excelInfraccionesProcesadasPath);
                }
            }
            else 
            {
                throw new Exception("El directorio para infracciones referenciado no existe, por favor creelo antes de iniciar la operacion");
            }
        }
    }
}