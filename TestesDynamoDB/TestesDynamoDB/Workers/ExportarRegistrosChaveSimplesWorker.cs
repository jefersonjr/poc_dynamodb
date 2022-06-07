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
    class ExportarRegistrosChaveSimplesWorker : BackgroundService
    {
        private readonly IPessoaRepository _repository;
        private readonly ILogger<ExportarRegistrosChaveSimplesWorker> _logger;

        public ExportarRegistrosChaveSimplesWorker(
            IPessoaRepository repository,
            ILogger<ExportarRegistrosChaveSimplesWorker> logger)
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
                DateTime dataFiltro = new DateTime(2022, 7, 1);
                var stream = await _repository.CarregarRegistrosChaveSimplesAsync(dataFiltro);
                _logger.LogInformation("Extração concluida em {0}", stopwatch.Elapsed);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogInformation("Processo concluido em {0}", stopwatch.Elapsed);
            }
;        }
    }
}
