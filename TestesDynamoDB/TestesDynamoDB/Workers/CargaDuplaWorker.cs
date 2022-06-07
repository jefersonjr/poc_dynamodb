using Bogus;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestesDynamoDB.Bogus;
using TestesDynamoDB.Carga;
using TestesDynamoDB.Entities;

namespace TestesDynamoDB.Workers
{
    public class CargaDuplaWorker : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            DateTime dataFiltro = new DateTime(2022, 9, 1);
            int totalRegistros = 1000000;

            await new CargaPessoaChaveDupla().Processar(dataFiltro, totalRegistros);
        }
    }
}
