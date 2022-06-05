using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestesDynamoDB.Repositories
{
    public interface IRepository
    {
        Task<bool> SalvarRegistros<T>(List<T> listaRegistros);
        AsyncSearch<T> CarregarRegistros<T>(string nomeChave, string valorChave);
    }
}
