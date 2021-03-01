using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // poderia usar uma fábrica, como Factory Method, ou Abstract Factory...
            DBConnection con = new SqlConnection()
            {
                ConnectionString = "SQL Server"
            };
            con.Open();
            con.Close();

            // Instaciando classe utilizando interface diretamente
            IDBConnection conOracle = new OracleConnection()
            {
                ConnectionString = "Oracle"
            };
            conOracle.Open();
            conOracle.Close();

            // Poderia utilizar com outras classe que extende a mesma interface como exemplo abaixo
            // Com isso não havendo mudanças nas propriedades e métodos por que o contrato é o mesmo
            // Trabalhando com o conceito de desenvolver com abstração e não implementações
            IDBConnection conSql = new SqlConnection();
            // A instancia acima é colocada como tipo da Interface, sendo isso possivel pois a classe SqlConnection
            // ela herda da classe abstrata DBConnection, que extende a interface IDBConnection

            Console.ReadLine();
        }
    }
}
