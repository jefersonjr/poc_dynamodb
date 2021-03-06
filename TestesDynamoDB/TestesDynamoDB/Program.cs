using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestesDynamoDB.Carga;
using TestesDynamoDB.Entities;
using TestesDynamoDB.Repositories;
using TestesDynamoDB.Workers;

namespace TestesDynamoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .WriteTo.Console()
                            .MinimumLevel.Debug()
                            .CreateLogger();

            var host = CreateHostBuilder(args);
            host.Start();

            while (true) ;

            // Parâmetros para carga
           // DateTime dataProcessamento = new DateTime(2022, 01, 01);
           // int totalRegistros = 10000000;

            // Efetuar carga (chave simples) com 1mi registros
            //await new CargaPessoaChaveUnica().Processar(dataProcessamento, totalRegistros);

            // Efetuar carga (chave dupla) com 1mi registros
            //await new CargaPessoaChaveDupla().Processar(dataProcessamento, totalRegistros);


            // TESTES
            /*var lista1 = new List<string>();
            var lista2 = new List<string>();
            var lista3 = new List<string>();
            var lista4 = new List<string>();
            Dictionary<int, List<string>> dicionario = new Dictionary<int, List<string>>();
            dicionario.Add(1, lista1);
            dicionario.Add(2, lista2);
            dicionario.Add(3, lista3);
            dicionario.Add(4, lista4);

            for(int i = 0; i <= totalRegistros; i++)
            {
                int random = new Random().Next(1, 5);
                dicionario[random].Add("VALOR");
            }*/
        }


        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(ConfigureServices)
                .UseSerilog();
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddSingleton<IPessoaRepository, PessoaRepository>();
            //services.AddHostedService<CargaDuplaWorker>();
            //services.AddHostedService<CargaSimplesWorker>();
            services.AddHostedService<ExportarRegistrosChaveDuplaWorker>();
            //services.AddHostedService<ExportarRegistrosChaveSimplesWorker>();
        }
    }
}
