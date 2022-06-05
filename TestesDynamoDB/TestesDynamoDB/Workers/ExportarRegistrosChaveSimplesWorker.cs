using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestesDynamoDB.Repositories;

namespace TestesDynamoDB.Workers
{
    class ExportarRegistrosChaveSimplesWorker : BackgroundService
    {
        private readonly IPessoaRepository _repository;

        public ExportarRegistrosChaveSimplesWorker(
            IPessoaRepository repository)
        {
            _repository = repository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            DateTime dataFiltro = new DateTime(2022, 1, 1);
            var stream = await _repository.CarregarRegistrosChaveSimplesAsync(dataFiltro);

            
;        }
    }
}
