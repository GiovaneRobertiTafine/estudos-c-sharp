using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

// Interface com classe abstrata 
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

// ------------------------------------------------------------------------------

// Implementado varias interfaces
namespace Interfaces
{
    public interface IComprimivel  //I...able
    {
        void Compactar();
        void Descompactar();
    }

    public interface IArmazenavel //I...able
    {
        void Ler();
        void Escrever();
    }

    public class Arquivo
    {
        public string Nome;
    }

    public class Compactador : IComprimivel
    {
        public void Compactar()
        {
            Console.WriteLine("Compactando arquivo...");
        }

        public void Descompactar()
        {
            Console.WriteLine("Descompactando arquivo...");
        }
    }

    // não repete código em cada classe que implementa interface
    public class Armazenador : IArmazenavel
    {

        public void Ler()
        {
            Console.WriteLine("Lendo arquivo...");
        }

        public void Escrever()
        {
            Console.WriteLine("Escrevendo arquivo...");
        }
    }

    // C# não suporta herança múltipla, mas pode implementar n interfaces
    // Implementação de interface por delegação
    // Quando extende uma interface em uma classe que tem uma função
    //especifica como comprimir arquivo e em uma outra classe, como em Imagem, herda essa classe, Compactador,
    //que extende a interface
    // A herança pode ocorrer por caixa preta, instanciando, ou herdando na declaração
    // Como nesse caso ja herda de Arquivo não é possivel na declaração
    public class Documento : Arquivo, IArmazenavel, IComprimivel
    {
        // herança de "caixa preta"
        private Armazenador _armazenador = new Armazenador();
        private Compactador _compactador = new Compactador();
        // implementação de n interfaces por delegação
        // simulando herança múltipla
        public void Ler()
        {
            // delegação
            this._armazenador.Ler();
        }
        public void Escrever()
        {
            this._armazenador.Escrever();
        }
        public void Compactar()
        {
            this._compactador.Compactar();
        }
        public void Descompactar()
        {
            this._compactador.Descompactar();
        }
    }

    // Nessa Classe é utilizada a herança caixa branca, herança na declaração
    // Como esta extendendo a IArmazenavel, precisa ter os metodos Ler e Escrever
    // Como esta herdando a Classe Compactador, a IComprimivel não alega erro, mas não é ncessário extender IComprimivel
    //pois Compactador ja implementa essa interface
    public class Imagem : Compactador, IArmazenavel, IComprimivel
    {
        public string Nome;
        public void Ler()
        {
            Console.WriteLine("Lendo arquivo...Imagem");
        }
        public void Escrever()
        {
            Console.WriteLine("Escrevendo arquivo...Imagem");
        }

        // Para sobrescrever o método herdado, precisaria tornar a classe Compactador abstrata, com metodos vitual ou abtract
        // Desta forma em baixo, os métodos desta classe oculta os metodos herdados
        //public void Compactar()
        //{
        //    Console.WriteLine("Compactando arquivo...Decla");
        //}

        //public void Descompactar()
        //{
        //    Console.WriteLine("Descompactando arquivo...Decla");
        //}
    }

}


// ------------------------------------------------------------------------------

// IDisposable

public class Disposable : IDisposable
{
    // Recurso figurativo, que não esta sendo gerenciado pela CLR
    public string Handle;

    // Propriedade utlizada para quando se valida a chamada do dispose
    //no código onde esta sendo utilizada esta classe
    private bool Disposing;

    public Disposable()
    {
        this.Handle = "Recurso Alocado";
        Console.WriteLine("Recurso Alocado");
        this.Disposing = false;
    }

    // Esee método do Dispose é para quando não se tem validacao para ver
    //se no código que está utlizando essa classe está chamando o dispose,
    //public void Dispose()
    //{
    //    Console.WriteLine("Dispose");
    //    this.Handle = "";
    //    Console.WriteLine("Recurso liberado com sucesso");
    //}

    // Esse método do Dispose é para quando se tem a validacao para ver
    //se no código que está utlizando essa classe etá chamando o dispose,
    //pois ao utilizar o using, automaticament ele vai executar o dispose
    public void Dispose()
    {
        if (!this.Disposing)
        {
            Handle = "";
            Console.WriteLine("Recurso liberado com sucesso");
            this.Disposing = true;
        }

    }

    public void Conectar()
    {
        Console.WriteLine("Conectado");
    }

}

// ------------------------------------------------------------------------------

// IEnumerable

class ListaClientes : IEnumerable
{
    private readonly IReadOnlyList<string> clientes;

    public ListaClientes()
    {

        this.clientes = new List<string> {
                "Giovane",
                "Roberti",
                "Tafine"
            };

    }

    // Retorna uma lista
    IEnumerator IEnumerable.GetEnumerator()
    {
        foreach (string c in this.clientes)
        {
            yield return c + " IEnumerable.GetEnumerator";
        }

    }

    public IEnumerator<string> GetEnumerator()
    {
        foreach (string c in this.clientes)
        {
            yield return c + " IEnumerator<string> GetEnumerator()";
        }
    }

    public IReadOnlyList<string> GetClientes()
    {
        return this.clientes;
    }

    public IEnumerable<string> GetEnumerable()
    {
        yield return this.clientes[0] + " GetEnumerable";
        yield return this.clientes[1] + " GetEnumerable";
        yield return this.clientes[2] + " GetEnumerable";
    }

}