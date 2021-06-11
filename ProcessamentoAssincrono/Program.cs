using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessamentoAssincrono
{
    class Program
    {
        public static IEnumerable<int> getNumerosPrimos(int min, int count)
        {
            return Enumerable.Range(min, count)
                .Where(num => Enumerable.Range(2, (int)Math.Sqrt(num) - 1)
                .All(i => num % i > 0));
        }

        public static Task<IEnumerable<int>> getNumerosPrimosTask(int min, int count)
        {
            return Task.Run(() => Enumerable.Range(min, count)
                .Where(num => Enumerable.Range(2, (int)Math.Sqrt(num) - 1)
                .All(i => num % i > 0)));
        }

        static void Main(string[] args)
        {
            // Task, Async e Await
            // O .NET framework fornece a classe Threading.Tasks para permitir que você crie taks e as execute
            //de forma assíncrona. Uma task é um objeto que representa algum trabalho que deve ser executado.
            // A task pode dizer se o trabalho foi concluído e se a operação retorna um resultado, a tarefa fornece
            //o resultado.

            // .NET Framework tem classes associadas a threads no namespace System.Threading.
            // Um Thread é um pequeno conjunto de instruções executáveis.

            // A classe Thread é usada para criar e manipular um  thread  no Windows.
            // Uma  Task  representa alguma operação assíncrona e faz parte da  Biblioteca Paralela de Tarefas ,
            //um conjunto de APIs para executar tarefas de forma assíncrona e em paralelo.
            // A Task pode retornar um resultado. Não existe um mecanismo direto para retornar o resultado de uma Thread.
            // Podemos facilmente implementar o Assíncrono usando palavras - chave 'async' e 'await'.
            // Um novo Thread() não está lidando com thread do pool de threads, enquanto Task usa thread do pool de threads.
            // Uma Task é um conceito de nível mais alto do que Thread.

            // Classe Task é simplesmente a implementação da interface IAsyncResult
            // Que permite executar métodos assincronos e receba como retorno resultado sem precisar esperar processamento sincrono

            // Método básico sincrono

            //foreach (int num in getNumerosPrimos(1, 1000000))
            //    Console.WriteLine(num.ToString());
            //Console.WriteLine("Terminou");

            // Método com mais processamento sincrono

            for (int i = 0; i < 10; i++)
            {
                getNumerosPrimos(i * 1000 + 1, i * 10000)
                    .ToList()
                    .ForEach(x => Console.WriteLine($"{x} - indice {i}"));
            }
            Console.WriteLine("Terminou");

            //ImprimiNumerosAsync();
            Console.ReadLine();
        }

        public static async void ImprimiNumerosAsync()
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    var resultado = await getNumerosPrimosTask(i * 1000 + 1, i * 10000);
            //    resultado.ToList()
            //        .ForEach(x => Console.WriteLine($"{x} - indice {i}"));
            //    Console.WriteLine("Terminou");
            //}

        
        }
    }
}
