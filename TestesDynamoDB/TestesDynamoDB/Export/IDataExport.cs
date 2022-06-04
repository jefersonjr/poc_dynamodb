using System;
using System.Collections.Generic;
using System.Text;

namespace TestesDynamoDB.Export
{
    public interface IDataExport<T>
    {
        string Processar(T item);
    }
}
