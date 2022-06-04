using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Serilog;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace TestesDynamoDB.Repositories
{
    public class Repository
    {
        internal readonly IAmazonDynamoDB _client;

        public Repository()
        {
            var config = new AmazonDynamoDBConfig()
            {
                ServiceURL = "http://192.168.88.22:8000"
            };

            _client = new AmazonDynamoDBClient(config);
        }

        public async Task<bool> SalvarRegistros<T>(List<T> listaRegistros)
        {
            string nomeTabela = listaRegistros?
                .FirstOrDefault()?
                .GetDynamoTable();

            List<TransactWriteItem> listaItens = new List<TransactWriteItem>(
                listaRegistros.Select(item => new TransactWriteItem()
                {
                    Put = new Put()
                    {
                        TableName = nomeTabela,
                        Item = item.ToDynamoAttribute()
                    }
                })
            );

            try
            {
                var transacaoResult = await _client.TransactWriteItemsAsync(new TransactWriteItemsRequest()
                {
                    TransactItems = listaItens
                });

                return transacaoResult != null && transacaoResult.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch(Exception ex)
            {
                Log.Fatal(ex.Message);
                throw;
            }
        }

        public AsyncSearch<T> CarregarRegistros<T>(string nomeChave, object valorChave)
        {
            var filtro = new QueryFilter();
            filtro.AddCondition(nomeChave, QueryOperator.Equal, valorChave);

            var queryConfig = new QueryOperationConfig()
            {
                Limit = 1000,
                Filter = filtro
            };

            DynamoDBContext context = new DynamoDBContext(_client);
            return context.FromQueryAsync<T>(queryConfig);
        }
    }
}
