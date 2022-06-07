using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.Logging;
using Microsoft.IO;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestesDynamoDB.Entities;
using TestesDynamoDB.Export;

namespace TestesDynamoDB.Repositories
{
    public class PessoaRepository : Repository, IPessoaRepository
    {
        private readonly ILogger<PessoaRepository> _logger;

        public PessoaRepository(
            ILogger<PessoaRepository> logger)
        {
            _logger = logger;
        }

        private async Task<Stream> CarregarRegistros(string dataFiltro)
        {
            var memManager = new RecyclableMemoryStreamManager();
            var memoryStream = memManager.GetStream();
            var streamWriter = new StreamWriter(memoryStream);

            _logger.LogInformation("Carregando registros para data: {0}", dataFiltro);

            var consulta = CarregarRegistros<Pessoa>("data_cadastro", dataFiltro);
            long totalRegistros = 0;

            while (!consulta.IsDone)
            {
                _logger.LogDebug("Buscando registros pendentes");
                var listaRegistros = await consulta.GetNextSetAsync();

                if (listaRegistros.Count > 0)
                {
                    totalRegistros += listaRegistros.Count;

                    // Exportar registros
                    var pessoaExport = new PessoaExport();
                    var data = pessoaExport.Processar(listaRegistros);
                    streamWriter.Write(data);
                }

                _logger.LogDebug("Registros carregdos: {0} - Thread: {1}", totalRegistros, Thread.CurrentThread.ManagedThreadId);
            }

            _logger.LogInformation("Total de registros: {0:N0}", totalRegistros);
            await streamWriter.FlushAsync();

            return memoryStream;
        }

        public async Task<Stream> CarregarRegistrosChaveDuplaAsync(DateTime dataCadastro)
        {
            int totalParticoes = 5;
            List<Task<Stream>> taskList = new List<Task<Stream>>();

            for(int i = 1; i <= totalParticoes; i++)
            {
                string dataFiltro = $"{dataCadastro.ToString("yyyyMMdd")}_{i}";
                taskList.Add(CarregarRegistros(dataFiltro));
            }

            var taskArray = taskList.ToArray();
            await Task.WhenAll(taskList);

            var memManager = new RecyclableMemoryStreamManager();
            var memoryStream = memManager.GetStream();

            foreach(var task in taskList)
            {
                var stream = task.Result;
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(memoryStream);
            }

           // taskList.ForEach((task) => task.Result.CopyTo(memoryStream));

            return memoryStream;
        }

        public Task<Stream> CarregarRegistrosChaveSimplesAsync(DateTime dataCadastro)
        {
            string dataFiltro = dataCadastro.ToString("yyyyMMdd");
            return CarregarRegistros(dataFiltro);
        }
    }
}
