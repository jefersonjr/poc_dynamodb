using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestesDynamoDB.Carga
{
    public interface ICarga
    {
        Task Processar(DateTime dataProcessamento, int totalRegistros);
    }
}
