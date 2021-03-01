using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    interface IDBConnection
    {
        void Close();
        void Open();
    }

    interface ITransactional
    {
        void StartTransaction();
    }

    public abstract class DBConnection : IDBConnection
    {
        public string ConnectionString { get; set; }

        // É colocado virtual para modificar um método, propriedade, 
        //indexador ou evento declarado na classe base e permitir que eles sejam sobrescritos na classe derivada
        public virtual void Close()
        {
            Console.WriteLine("Fechando conexão...");
        }

        public virtual void Open()
        {
            Console.WriteLine("Abrindo conexão...");
            Console.WriteLine("Conectado a " + ConnectionString);
        }
    }

    // Exemplo de classe herdando uma classe abstrata que extende uma interface
    public class SqlConnection : DBConnection
    {
        // É colocado override para estender ou modificar um método  virtual/abstrato, 
        //propriedade, indexador ou evento da classe base na classe derivada
        public override void Open()
        {
            // Aqui colocado a chamada com a decoração da classe base para chamar o método do mesmo
            base.Open();
            // código específico para SQL
        }

        // Se não assinar o método que herda com override, ocultara o membro
        public override void Close()
        {
            Console.WriteLine("Classe que herda");
            base.Close();
        }

    }


    // Exemplo de classe extendendo um interface
    public class OracleConnection : IDBConnection
    {
        public string ConnectionString { get; set; }
        public void Close()
        {
            Console.WriteLine("Fechando conexão Oracle");
        }

        public void Open()
        {
            Console.WriteLine("Abrindo conexão Oracle");
            Console.WriteLine("Conectado a " + ConnectionString);
        }
    }
}
