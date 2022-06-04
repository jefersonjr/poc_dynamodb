using System;
using System.Collections.Generic;
using System.Text;
using TestesDynamoDB.Entities;

namespace TestesDynamoDB.Export
{
    public class PessoaExport : DataExport<Pessoa>
    {
        internal override void ProcessarItem(Pessoa pessoa)
        {
            Write(pessoa.DataCadastro, 8);
            Write(pessoa.RazaoSocial, 80);
            Write(pessoa.NomeFantasia, 80);
            Write(pessoa.CnpjCpf, 11, '0');
            Write(pessoa.InscricaoMunicipal, 10, '0');
            Write(pessoa.IeRg, 10, '0');
            Write(pessoa.Logradouro, 80, '0');
            Write(pessoa.Numero, 10);
            Write(pessoa.CEP, 8, '0');
            Write(pessoa.Bairro, 30);
        }
    }
}
