using System;
using System.Collections.Generic;
using System.Text;

namespace TestesDynamoDB.Export
{
    public class DataExport
    {
        internal StringBuilder _builder = new StringBuilder();

        public void Empty(int size = 0, char paddingChar = ' ')
        {
            Write(string.Empty, size, paddingChar);
        }

        public void Break()
        {
            Write(Environment.NewLine);
        }

        public void Write(string text, int size = 0, char paddingChar = ' ')
        {
            if (text == null)
                text = string.Empty;

            if (size > 0)
            {
                if (text.Length > size)
                    text = text.Substring(0, size - 1);
                else if (text.Length < size)
                    text = text.PadLeft(size, paddingChar);
            }

            _builder.Append(text);
        }

        public void Write(int number, int size = 0, char paddingChar = '0')
        {
            string value = number.ToString();
            Write(value, size, paddingChar);
        }

        public void Write(decimal number, int size = 0, char paddingChar = '0')
        {
            string value = number.ToString();
            Write(value, size, paddingChar);
        }

        public void Write(DateTime date, int size = 0, char paddingChar = ' ')
        {
            string value = date.ToString("yyyymmdd");
            Write(date, size, paddingChar);
        }

        public string Export()
        {
            return _builder.ToString();
        }
    }

    public class DataExport<T> : DataExport, IDataExport<T>
    {
        internal virtual void ProcessarItem(T item) { }

        public virtual string Processar(T item)
        {
            ProcessarItem(item);
            return _builder.ToString();
        }

        public virtual string Processar(List<T> listaRegistros)
        {
            foreach(T item in listaRegistros)
            {
                ProcessarItem(item);
                Break();
            }

            return _builder.ToString();
        }
    }
}
