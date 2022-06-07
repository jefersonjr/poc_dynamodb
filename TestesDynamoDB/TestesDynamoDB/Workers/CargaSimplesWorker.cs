using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestesDynamoDB.Carga;

namespace TestesDynamoDB.Workers
{
    class CargaSimplesWorker : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            DateTime dataFiltro = new DateTime(2022, 7, 1);
            int totalRegistros = 1000000;

            await new CargaPessoaChaveUnica().Processar(dataFiltro, totalRegistros);
        }
    }
}
