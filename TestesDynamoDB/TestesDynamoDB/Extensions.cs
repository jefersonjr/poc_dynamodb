using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TestesDynamoDB
{
    public static class Extensions
    {
        public static AttributeValue GetAtributo(this object obj)
        {
            return obj.GetType() switch
            {
                Type stringType when stringType == typeof(string) => new AttributeValue() { S = obj.ToString() },
                Type dateType when dateType == typeof(DateTime) => new AttributeValue() { S = obj.ToString() },
                Type nullType when nullType == null => new AttributeValue() { NULL = true },
                Type intType when intType == typeof(int) => new AttributeValue() { N = obj.ToString() },
                Type intType when intType == typeof(long) => new AttributeValue() { N = obj.ToString().Replace(",", ".") },
                Type intType when intType == typeof(decimal) => new AttributeValue() { N = obj.ToString().Replace(",", ".") },
                Type intType when intType == typeof(double) => new AttributeValue() { N = obj.ToString().Replace(",", ".") },
                Type boolType when boolType == typeof(bool) => new AttributeValue() { S = ((bool)obj) ? "S" : "N" },
                _ => throw new ArgumentException($"Tipo desconhecido. {obj.ToString()}")
            };
        }

        public static string GetDynamoTable(this object objeto)
        {
            var atributo = objeto.GetType()
                .GetCustomAttribute<DynamoDBTableAttribute>();

            return atributo?.TableName;
        }

        public static Dictionary<string, AttributeValue> ToDynamoAttribute(this object objeto)
        {
            var dados = objeto.GetType()
                .GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(DynamoDBPropertyAttribute), false).Count() > 0)
                .ToDictionary(
                    chave => chave.GetCustomAttribute<DynamoDBPropertyAttribute>().AttributeName,
                    valor => GetAtributo(valor.GetValue(objeto))
                );

            return dados;
        }
    }
}
