using Bogus;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestesDynamoDB.Bogus;
using TestesDynamoDB.Entities;

namespace TestesDynamoDB.Carga
{
    public class CargaPessoaChaveDupla : Carga<Pessoa>
    {
        static int quantidadeParticao = 5;

        internal override Faker<Pessoa> GetFaker()
        {
            var faker = new PessoaFaker();
            faker.RuleFor(x => x.DataCadastro, x => $"{_dataProcessamento.ToString("yyyyMMdd")}_{x.Random.Number(1, quantidadeParticao)}");
            return faker;
        }

        public override Task Processar(DateTime dataProcessamento, int totalRegistros)
        {
            Log.Information("Gerando carga com chave dupla");
            return base.Processar(dataProcessamento, totalRegistros);
        }
    }
}
