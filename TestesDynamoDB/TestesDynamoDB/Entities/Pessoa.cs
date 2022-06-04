using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestesDynamoDB.Entities
{
    [DynamoDBTable("pessoa")]
    public class Pessoa
    {
        [DynamoDBHashKey("data_cadastro")]
        public string DataCadastro { get; set; }

        [DynamoDBRangeKey("id")]
        public string Id { get; set; }

        [DynamoDBProperty("tipo_pessoa")]
        public string TipoPessoa { get; set; }

        [DynamoDBProperty("razao_social")]
        public string RazaoSocial { get; set; }

        [DynamoDBProperty("nome_fantasia")]
        public string NomeFantasia { get; set; }

        [DynamoDBProperty("cnpj_cpf")]
        public string CnpjCpf { get; set; }

        [DynamoDBProperty("ie_rg")]
        public string IeRg { get; set; }

        [DynamoDBProperty("im")]
        public string InscricaoMunicipal { get; set; }

        [DynamoDBProperty("contato")]
        public string Contato { get; set; }

        [DynamoDBProperty("logradouro")]
        public string Logradouro { get; set; }

        [DynamoDBProperty("numero")]
        public string Numero { get; set; }

        [DynamoDBProperty("complemento")]
        public string Complemento { get; set; }

        [DynamoDBProperty("bairro")]
        public string Bairro { get; set; }

        [DynamoDBProperty("cep")]
        public string CEP { get; set; }

        [DynamoDBProperty("uf")]
        public string UF { get; set; }

        [DynamoDBProperty("cidade")]
        public string Cidade{ get; set; }

        [DynamoDBProperty("telefone")]
        public string Telefone { get; set; }

        [DynamoDBProperty("celular")]
        public string Celular { get; set; }

        [DynamoDBProperty("fax")]
        public string FAX { get; set; }

        [DynamoDBProperty("email")]
        public string Email { get; set; }

        [DynamoDBProperty("observacao")]
        public string Observacao { get; set; }

        [DynamoDBProperty("inativo")]
        public bool Inativo { get; set; }
    }
}
