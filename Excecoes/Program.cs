using System;
using System.Collections;

namespace Excecoes
{
    class Program
    {
        static void Main(string[] args)
        {
            new Excecao();
            Console.ReadLine();
        }
    }

    class Excecao
    {
        string dividendo;
        string divisor;

        string login;
        string senha;

        Autenticacao autenticacao = new Autenticacao();
        public Excecao()
        {
            this.Divisao();
        }

        // Bloco de métodos para representar uma call Stack
        // ----------------------------------------------------------------------------
        public void Estagiario(string Tarefa)
        {
            Convert.ToDateTime(Tarefa);
        }
        public void Programador(string Tarefa)
        {
            try
            {
                Estagiario(Tarefa);
            }
            catch (Exception e)
            {
                Console.WriteLine("Programador capturou a exceção");
                // Instanciando um throw para conseguir propagar uma exceção
                // Pois ao verificar num bloco try catch, voce anula o erro para trata-lo
                // com throw voce consegue subir uma nova exceção podendo colocar informações do erro e novas informações
                // e com pela cadeia da stack, outras classe ou partes da mesma consegue captura-lo ao verificar com try cacth
                throw new Exception("Erro ao converter data");
            }
        }
        public void Arquiteto(string Tarefa)
        {
            Programador(Tarefa);
        }
        public void Coordenador(string Tarefa)
        {
            Arquiteto(Tarefa);
        }
        public void Gerente(string Tarefa)
        {
            try
            {
                Coordenador(Tarefa);
            }
            catch (Exception e)
            {
                Console.WriteLine("Gerente capturou o erro");
                Console.WriteLine($"Exceção: {e.Message}");
            }
        }


        // ----------------------------------------------------------------------------

        public void HandleException(Exception e)
        {
            var str = $"Message: {e.Message}\n" +
                $"StackTrace: {e.StackTrace}\n" +
                $"TargetSite: {e.TargetSite.Name}\n" +
                $"Source: {e.Source}\n" +
                $"Data: ";

            foreach (DictionaryEntry items in e.Data)
                str += $"{items.Key} : {items.Value}\n";

            Console.WriteLine(str);
        }

        public void Divisao()
        {
            try
            {
                Console.WriteLine("Favor digite o dividendo para divisão");
                this.dividendo = Console.ReadLine();
                Console.WriteLine("Favor digite o divisor para divisão");
                this.divisor = Console.ReadLine();
                // Convertendo posteriormente, pois convertendo antes, podera ocorrer erro de Format e com isso não atribui a variavel
                Console.WriteLine($"A divisão é {Convert.ToDecimal(dividendo) / Convert.ToDecimal(divisor)}");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Valor muito grande para divisor ou dividendo");
                e.Data.Add("Divisor", divisor);
                e.Data.Add("Dividendo", dividendo);
                HandleException(e);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Informe valores corretos para divisor ou dividendo");
                e.Data.Add("Divisor", divisor);
                e.Data.Add("Dividendo", dividendo);
                HandleException(e);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Não é possível dividir por zero");
                e.Data.Add("Divisor", divisor);
                e.Data.Add("Dividendo", dividendo);
                HandleException(e);
            }
            // A excecao aritmetica precisa ser uma da ultimas pois a OverflowException e DivideByZeroException, herdam de ArithmeticException
            // E com isso dara erro, pois essa classe é genérica
            catch (ArithmeticException e)
            {
                Console.WriteLine("Erro aritmético");
                e.Data.Add("Divisor", divisor);
                e.Data.Add("Dividendo", dividendo);
                HandleException(e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Dados inválidos para soma");
                e.Data.Add("Divisor", divisor);
                e.Data.Add("Dividendo", dividendo);
                HandleException(e);
                // throw;
            }
            finally
            {
                Console.WriteLine("Finalizando");
            }


            // Chamando a stack call para propagar com throw
            Gerente("99/99/9999");

            // Bloco de código para criar Custom Exceptions
            Console.WriteLine("Digite o login");
            login = Console.ReadLine();
            Console.WriteLine("Digite a senha");
            senha = Console.ReadLine();

            // Verificando a exceção
            try
            {
                autenticacao.Autenticar(login, senha);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
