using System;
using System.Data;

namespace Extensao
{
    // Método pelo construtor
    // Método comumente que poderia ser feito sem método de extensão
    // Herda a Classe DataSet e com isso adiciona um método
    // Ao instanciar essa nova classe voce tem acesso ao novo método e a classe pai
    // Este método não é uma boa prática se voce quer só inserir um método na classe pai
    public class MyExtensaoHeranca : DataSet
    {
        public string Write(string str)
        {
            return "Console" + str;
        }
    }

    // Método por delegação
    // Método que poderia ser feito para adicionar um método em uma classe
    //mas um custo grande por voce ter que ter atributo e um inicialização da classe no contructor
    public class MyExtensaoDelegacao
    {
        DataSet _dt;

        public MyExtensaoDelegacao(DataSet dt)
        {
            this._dt = dt;
        }

        public string Write(string str)
        {
            return "Console" + str;
        }
    }

    // Método de extensão
    // Utiliza injenção de dependencia
    //que é quando a partir do método voce faz uma referencia, com o this, informando que estara injetando aquele método
    // Percebe que só é possivel fazer isso com classe estática
    public static class MyExtensaoInjecao
    {
        public static string ToUrl(this String str)
        {
            return "https://" + str;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Métodos ou Classes de extensão
            // Permitem inserir um método em uma classe, sem uso de herança
            // Não é necessário acesso ao código-fonte
            // Método é acessivel como se fosse originalmente escrito na classe

            // Herança
            var dt = new MyExtensaoHeranca();
            
            // Delegação
            var ds = new DataSet();
            var dsDelegacao = new MyExtensaoDelegacao(ds);

            // Injeção
            string str = "string";


            Console.WriteLine(dt.Write("Teste"));
            Console.WriteLine(dsDelegacao.Write("Teste"));
            Console.WriteLine(str.ToUrl());
            Console.ReadKey();

        }
    }
}
