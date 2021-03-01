using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegacao
{
    class Program
    {
        static void Main(string[] args)
        {
            new Delegate();
            new Action();
            new Predicate();
            new Func();

            Console.ReadLine();
        }

        public static readonly List<Cliente> Clientes = new List<Cliente>()
        {
            new Cliente() { Nome = "Giovane", Id = "1", Idade = 25 },
            new Cliente() { Nome = "Roberti", Id = "2", Idade = 40 },
            new Cliente() { Nome = "Tafine", Id = "3", Idade = 30 }
        };


        public class Delegate
        {
            // Precisa ser static somente na classe Program
            public static void PagarBoleto(double valor)
            {
                Console.WriteLine($"Pago no boleto valor de {valor} com delegate e método nomeado");
            }

            // Método para ser passado como parâmentro, no modelo do event ser injetado
            public static void PagarBoletoInjetado(double valor)
            {
                Console.WriteLine($"Pago no boleto valor de {valor} com delegate e event injetado passando como parâmetro método e valor");
            }

            public Delegate()
            {
                // Intânciado com o valor setado
                var pedido = new Pedido() { valor = 2000 };

                // Podendo setar o valor dessa forma também
                //pedido.valor = 300;

                // Realizando delegate por métodos anônimos
                pedido.Pagar += delegate (double valor)
                {
                    Console.WriteLine($"Pago no boleto valor de {valor} com delegate e método anônimo");
                };

                // Realizando delegate por métodos nomeados
                pedido.Pagar += PagarBoleto;

                // Realizando delegate por lambda
                pedido.Pagar += v => Console.WriteLine($"Pago no boleto valor de {v} com delegate e lambda");

                pedido.Fechar(2000);


                // Realizando o delegate com event injetado no próprio método chamado, passando como parâmetro a função a ser realizada
                pedido.FecharInjetado(v => Console.WriteLine($"Pago no boleto valor de {v} com delegate e event injetado passando como parâmetro método"));
                // Realizand o mesmo procedimento acima, mas passando o valor como parâmetro, sem precisar passsar para uma variavel da classe
                pedido.FecharInjetadoParam(PagarBoletoInjetado, 2000);
            }
        }

        // --------------------------------------------------------------------------------------------------------
        // Delegate Genericos, é uma função ou método que recebe um parâmetro sem retornar nada
        public class Action
        {
            // Método com o propósito de função para uma Action
            public static void MostrarLista(Cliente cliente)
            {
                Console.WriteLine($"{cliente.Nome} Listagem sem decorar uma Action");
            }

            // Método com o propósito de função para uma Action
            public static void MostrarListaAction(Cliente cliente)
            {
                Console.WriteLine($"{cliente.Nome} Listagem decorada a uma Action");
            }

            // Declarando uma Action, que serve com um delegate generico, onde eu posso passa um tipo
            // Aponto para um método, que receberá um parâmetro e não irá retornar nada;

            Action<Cliente> MostrarAction = new Action<Cliente>(MostrarListaAction);
            // Declarando uma Action com Lambda
            Action<Cliente> MostrarActionLamb = new Action<Cliente>(c => Console.WriteLine($"{c.Nome} Listagem decorada a uma Action com Lambda"));


            // Iniciando uma lista para dar inicio ao processo ao delegate generico Action
            //List<Cliente> Clientes = new List<Cliente>()
            //{
            //    new Cliente{ Nome = "Giovane", Id = "1" },
            //    new Cliente{ Nome = "Roberti", Id = "2" },
            //    new Cliente{ Nome = "Tafine", Id = "3" }
            //};


            public Action()
            {
                // Efetuando uma listagem da lista, ForEach espera como parâmentro uma Action, é uma função ou método que recebe um parâmetro
                // sem retornar nada
                Clientes.ForEach(MostrarLista);

                // Efetuando a listagem, inserindo um como parâmetro uma Action que aponta para um método
                Clientes.ForEach(MostrarAction);

                // Efetuando a listagem, inserindo um como parâmetro uma Action com lambda
                Clientes.ForEach(MostrarActionLamb);

            }

        }

        // --------------------------------------------------------------------------------------------------------
        // Predicate que é uma função ou método que recebe um parâmetro, e com base de critérios devolve true ou false
        public class Predicate
        {
            // Lista que vai servir para aplicar um Predicate sem decorar
            IList<string> Nome = new List<string>()
            {
                "Giovane", "Roberti", "Tafine"
            };

            // Lista que vai servir para aplicar um Predicate
            //List<Cliente> Clientes = new List<Cliente>()
            //{
            //    new Cliente() { Nome = "Giovane", Id = "1", Idade = 25 },
            //    new Cliente() { Nome = "Roberti", Id = "2", Idade = 40 },
            //    new Cliente() { Nome = "Tafine", Id = "3", Idade = 30 }
            //};

            // Variavel para termo de criterio 
            public static string st = "o";

            // Declarando um Predicate, que serve como um ponteiro para um método
            Predicate<Cliente> predicate = new Predicate<Cliente>(ContainsPredicate);

            // Declarando um Predicate, que serve como um ponteiro para um método
            Predicate<Cliente> predicateAnonimo = new Predicate<Cliente>(delegate (Cliente c)
            {
                return c.Idade > 30;
            });

            // Declarando um Predicate, com Lambda
            Predicate<Cliente> predicateLambda = new Predicate<Cliente>((Cliente c) => c.Idade > 30);

            // Função que vai servir como método para um Predicate sem decorar
            public static bool Contains(string arg)
            {
                return arg.Contains(st);
            }

            // Função que vai servir como método para um Predicate
            public static bool ContainsPredicate(Cliente c)
            {
                return c.Idade > 30;
            }

            public Predicate()
            {
                // Forma tradicional para verificar um Predicate
                foreach (var n in Nome)
                {
                    if (Contains(n))
                        Console.WriteLine($"{n} Sem decorar Predicate");
                }

                // Uma Forma de verificar para verificar um Predicate
                // O método FindAll pode esperar um Predicate
                // Poderia ser um foreach como sem decorar um Predicate
                var list = Clientes.FindAll(ContainsPredicate);
                foreach (var cliente in list)
                    Console.WriteLine($"{cliente.Nome} Decorando Predicate por um método nomeado");

                // Forma para listar um método anônimo, poderia ser por FindAll
                foreach (var cliente in Clientes)
                {
                    if (predicateAnonimo(cliente))
                        Console.WriteLine($"{cliente.Nome} Decorando Predicate por um método anônimo");
                }

                // Forma para listar uma lambda, poderia ser por FindAll
                foreach (var cliente in Clientes)
                {
                    if (predicateLambda(cliente))
                        Console.WriteLine($"{cliente.Nome} Decorando Predicate por uma lambda");
                }
            }
        }

        // --------------------------------------------------------------------------------------------------------
        // Func que é uma função ou método genérico que recebe um parâmetro, e com base de critérios devolve um objeto do mesmo tipo genérico do parâmetro
        public class Func
        {
            // Declarando um Func, que serve como um ponteiro para um método
            Func<Cliente, Cliente> func = new Func<Cliente, Cliente>(Constain);

            // Declarando um Func, com Lambda
            // Retornando um bool, pois a função do Lambda é mais interessante desta forma 
            Func<Cliente, bool> funcLambda = new Func<Cliente, bool>((c) => c.Idade == 25);

            // Declarando um Func, com método anônimo
            Func<Cliente, Cliente> funcAnonimo = new Func<Cliente, Cliente>(delegate (Cliente c) {
                if (c.Idade == 25)
                    return c;
                return null;
            });

            public Func()
            {
                // Uma Forma de verificar para verificar um Func
                // O método Select pode esperar um Func
                // Poderia ser um foreach como sem decorar um Func
                foreach (var c in Clientes.Select(func))
                {
                    if (c != null)
                        Console.WriteLine($"{c.Nome} Decorando Func com método nomeado");
                }

                // Forma tradicional para verificar um Func
                foreach (var c in Clientes)
                {
                    if (Constain(c) != null)
                        Console.WriteLine($"{c.Nome} Sem decorar Func");
                }

                // O método Where pode ser utilizado com Predicate, pois ele utiliza critérios de true ou false
                // Mas retorna um tipo genérico
                foreach (var c in Clientes.Where(funcLambda))
                {
                    Console.WriteLine($"{c.Nome} Decorando Func com método Lambda");
                }

                // Uma forma de verificar um Func com método anônimo
                foreach (var c in Clientes.Select(funcAnonimo))
                {
                    if (c != null)
                        Console.WriteLine($"{c.Nome} Decorando Func com método anônimo");
                }
            }

            // Função que vai servir como método para um Func
            public static Cliente Constain(Cliente c)
            {
                if (c.Idade == 25)
                    return c;
                return null;
            }
        }

    }
}
