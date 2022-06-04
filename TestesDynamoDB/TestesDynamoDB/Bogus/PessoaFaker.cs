using Bogus;
using System;
using System.Collections.Generic;
using System.Text;
using TestesDynamoDB.Entities;

namespace TestesDynamoDB.Bogus
{
    public class PessoaFaker : Faker<Pessoa>
    {
        static string numeros = "123456789";
        static string tipoPessoa = "FJ";
        static DateTime dataInicial = new DateTime(2022, 01, 01);
        static DateTime dataFinal = new DateTime(2022, 12, 31);

        public PessoaFaker()
        {
            RuleFor(x => x.DataCadastro, x => 
                x.Date.Between(dataInicial, dataFinal).ToString("yyyyMMdd")
            );
            RuleFor(x => x.Id, x => x.Random.Guid().ToString());
            RuleFor(x => x.RazaoSocial, x => x.Name.FullName());
            RuleFor(x => x.NomeFantasia, x => x.Name.FullName());
            RuleFor(x => x.CnpjCpf, x => x.Random.String2(11, numeros));
            RuleFor(x => x.IeRg, x => x.Random.String2(15, numeros));
            RuleFor(x => x.InscricaoMunicipal, x => x.Random.String2(10, numeros));
            RuleFor(x => x.Contato, x => x.Name.FirstName());
            RuleFor(x => x.Logradouro, x => x.Address.StreetName());
            RuleFor(x => x.Numero, x => x.Address.BuildingNumber());
            RuleFor(x => x.Complemento, x => x.Address.StreetSuffix());
            RuleFor(x => x.Bairro, x => x.Address.SecondaryAddress());
            RuleFor(x => x.Cidade, x => x.Address.City());
            RuleFor(x => x.CEP, x => x.Address.ZipCode());
            RuleFor(x => x.UF, x => x.Address.StateAbbr());
            RuleFor(x => x.Telefone, x => x.Phone.PhoneNumber());
            RuleFor(x => x.Celular, x => x.Phone.PhoneNumber());
            RuleFor(x => x.FAX, x => x.Phone.PhoneNumber());
            RuleFor(x => x.Email, x => x.Internet.Email());
            RuleFor(x => x.Observacao, x => x.Lorem.Text()); 
            RuleFor(x => x.Inativo, x => x.Random.Bool());
            RuleFor(x => x.TipoPessoa, x => x.Random.String2(1, tipoPessoa));
        }
    }
}
