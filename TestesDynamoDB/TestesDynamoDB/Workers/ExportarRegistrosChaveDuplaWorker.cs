using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestesDynamoDB.Repositories;

namespace TestesDynamoDB.Workers
{
    public class ExportarRegistrosChaveDuplaWorker : BackgroundService
    {
        private readonly IPessoaRepository _repository;
        private readonly ILogger<ExportarRegistrosChaveDuplaWorker> _logger;

        public ExportarRegistrosChaveDuplaWorker(
            IPessoaRepository repository,
            ILogger<ExportarRegistrosChaveDuplaWorker> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                DateTime dataFiltro = new DateTime(2022, 9, 1);
                var stream = await _repository.CarregarRegistrosChaveDuplaAsync(dataFiltro);
                _logger.LogInformation("Extração concluida em {0}", stopwatch.Elapsed);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogInformation("Processo concluido em {0}", stopwatch.Elapsed);
            }
        }
    }
}
