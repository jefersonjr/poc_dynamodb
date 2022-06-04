using Bogus;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestesDynamoDB.Bogus;
using TestesDynamoDB.Entities;
using TestesDynamoDB.Repositories;

namespace TestesDynamoDB.Carga
{
    public class CargaPessoaChaveUnica : Carga<Pessoa>
    {
        internal override Faker<Pessoa> GetFaker()
        {
            var faker = new PessoaFaker();
            faker.RuleFor(x => x.DataCadastro, x => _dataProcessamento.ToString("yyyyMMdd"));
            return faker;
        }

        public override Task Processar(DateTime dataProcessamento, int totalRegistros)
        {
            Log.Information("Gerando carga simples");
            return base.Processar(dataProcessamento, totalRegistros);
        }
    }
}
