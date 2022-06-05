using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TestesDynamoDB.Repositories
{
    public interface IPessoaRepository : IRepository
    {
        Task<Stream> CarregarRegistrosChaveSimplesAsync(DateTime dataCadastro);
        Task<Stream> CarregarRegistrosChaveDuplaAsync(DateTime dataCadastro);
    }
}
