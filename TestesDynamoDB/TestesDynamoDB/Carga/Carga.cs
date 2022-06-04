using Bogus;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestesDynamoDB.Repositories;

namespace TestesDynamoDB.Carga
{
    public class Carga<T> : ICarga where T : class
    {
        internal DateTime _dataProcessamento;
        internal int _quantidadeRegistros;
        
        internal virtual Faker<T> GetFaker()
        {
            throw new NotImplementedException();
        }

        public virtual async Task Processar(DateTime dataProcessamento, int totalRegistros)
        {
            this._dataProcessamento = dataProcessamento;
            this._quantidadeRegistros = totalRegistros;

            int lotes = (totalRegistros / 25);

            var dadosFake = GetFaker();
            var repository = new Repository();

            for (int i = 0; i <= lotes; i++)
            {
                Log.Information("Gravando lote: {0}", i);
                var dados = dadosFake.Generate(25);
                repository.SalvarRegistros<T>(dados);
            }
        }
    }
}
