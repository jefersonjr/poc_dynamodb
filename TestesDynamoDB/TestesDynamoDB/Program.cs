using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestesDynamoDB.Carga;
using TestesDynamoDB.Entities;

namespace TestesDynamoDB
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .WriteTo.Console()
                            .CreateLogger();

            // Parâmetros para carga
            DateTime dataProcessamento = new DateTime(2022, 01, 01);
            int totalRegistros = 10000000;

            // Efetuar carga (chave simples) com 1mi registros
            //await new CargaPessoaChaveUnica().Processar(dataProcessamento, totalRegistros);

            // Efetuar carga (chave dupla) com 1mi registros
            await new CargaPessoaChaveDupla().Processar(dataProcessamento, totalRegistros);


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
    }
}
