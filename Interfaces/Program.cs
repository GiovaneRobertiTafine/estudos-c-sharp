using System;
using System.Data.SqlTypes;
namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // Bloco para estudo de Interface com classe abstrata
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

            // ------------------------------------------------------------------------------

            // Bloco para estudo de implementacao de varias Interfaces
            Documento doc = new Documento() { Nome = "Artigo.docx" };
            Console.WriteLine("Arquivo:" + doc.Nome);
            doc.Ler();
            doc.Escrever();
            doc.Compactar();
            doc.Descompactar();
            Imagem img = new Imagem() { Nome = "Foto.jpg" };
            Console.WriteLine("Arquivo:" + img.Nome);
            img.Ler();
            img.Escrever();
            img.Compactar();
            img.Descompactar();
            
            // ------------------------------------------------------------------------------

            // Bloco para estudo de implementacao de IDisposable

            // No código a baixo é um exemplo para que chame o Close ou Dispose manualmento
            // Por exemplo se por acaso acontecer algo de errado dentro do escopo do try/
            //pode ser que esse objeto nao seja coletado pelo Garbage Collector e mantendo esse recurso ativo em memória
            // Por isso utilizado o finally com o Dispose ou Close
            var conDisposable = new SqlConnection();
            try
            {
                //...
            }
            finally
            {
                if (conDisposable != null)
                    conDisposable.Close();
            }

            // Utilizando o using automaticamente ele vai utlizar dispose ao finalizar
            //using (IDisposable obj = new Disposable())
            //{
            //    //...
            //}

            using (Disposable conexao = new Disposable())
            {
                conexao.Conectar();
            }

            // ------------------------------------------------------------------------------

            // Bloco para estudo de implementacao de IEnumerable

            var clientes = new ListaClientes();

            foreach (var c in clientes)
            {
                Console.WriteLine(c);
            }

            foreach (var i in clientes.GetClientes())
            {
                Console.WriteLine(i);
            }

            foreach (var i in clientes.GetEnumerable())
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();


        }
    }

    
}
