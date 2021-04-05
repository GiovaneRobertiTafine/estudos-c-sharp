using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Colecoes
{
    class Cliente
    {
        public int Codigo;
        public string Nome;
        public string CPF;
        public override string ToString()
        {
            return Nome + " - " + CPF;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var c1 = new Cliente() { Codigo = 1, Nome = "Giovane", CPF = "123" };
            var c2 = new Cliente() { Codigo = 2, Nome = "Roberti", CPF = "124" };
            var c3 = new Cliente() { Codigo = 3, Nome = "Tafine", CPF = "133" };


            Console.WriteLine("Vetor");
            // Vetores
            // limitado o numero de alocação de memoria
            int[] numVetor = new int[8];
            numVetor[0] = 1;
            numVetor[1] = 2;
            numVetor[2] = 3;
            numVetor[3] = 4;
            numVetor[4] = 5;
            numVetor[5] = 6;
            numVetor[6] = 7;
            numVetor[7] = 8;

            var qry = from n in numVetor where n % 2 == 0 select n;
            foreach (int x in qry)
                Console.WriteLine($"{x} - Vetor");

            // --------------------------------------------------------------------------------------------------------

            Console.WriteLine("\n ArrayLista");
            // ArrayList
            // Coleçao simples não tipada
            // Implement IEnumerable
            // Armazena Objetos (Object)
            // Nao Consegue tipar objetos ao armazenar, logo é preciso type casting para retirar
            var arrayList = new ArrayList();
            arrayList.Add("Giovane");
            arrayList.Add(78);
            arrayList.Add(new System.Text.StringBuilder());

            foreach (var item in arrayList)
                Console.WriteLine($"{item} - ArrayList");

            // A capacidade é o espaço total utilizado ou não que o .net aloca,
            // Ele aloca de 4 em 4 espaços, ex tenho 5 alocaçoes preenchidas tera a capacidade de 8
            Console.WriteLine($"{arrayList.Capacity} - ArrayList Capacity");
            Console.WriteLine($"{arrayList.Count} - ArrayList Count");

            // Para acessa alguma propriedade é preciso fazer o type casting
            (arrayList[2] as System.Text.StringBuilder).Append("Teste");


            // --------------------------------------------------------------------------------------------------------

            Console.WriteLine("\n List");
            // List<T>
            // Coleções tipadas com uso de Generics
            // Implement IEnumerable
            // Armazena qualquer tipo objeto, porem com informacao estatica de tipo

            IList<Cliente> lista = new List<Cliente>() { c1, c2, c3 };
            //lista.Add(c1);
            //lista.Add(c2);
            //lista.Add(c3);
            Console.WriteLine($"{lista[0]} - List index");
            foreach (var item in lista)
            {
                Console.WriteLine($"{item} - List");
                Console.WriteLine($"Código - {item.Codigo}");
            }
            // FirstOrDefault espera um predicate
            // Como ele recebe um tipo e devolve um outro tipo, sendo boolean, ele é descrito como Func
            Console.WriteLine(lista.FirstOrDefault(c => c.CPF == "123"));

            // --------------------------------------------------------------------------------------------------------

            Console.WriteLine("\n HashTable");
            // HashTable
            // "Tabelas" simples não tipadas
            // Baseado no conceito de chave/valor
            // Armazena objetos (Object), tanto para key quanto para value
            // Não consegue tipar objetos ao armazenar, logo é necessário type casting para remover
            // O HashTable esta para Dictionary, como o ArrayList esta para List

            // Contrucao, parametro (key, value)
            var hashTable = new Hashtable()
            {
                { 1, "Giovane" },
                { "2", new System.Data.DataSet() },
                { 3, "Roberti Tafine" }
            };
            // Podendo verificar com metodos proprios key e value
            if (hashTable.ContainsKey("2"))
            // Ao consultar por index em HashTable, estara procurando por aquela chave
                Console.WriteLine($"{hashTable["2"]} - HashTable index key");

            // Podendo retornar uma coleçao sobre a keys ou values
            foreach (var obj in hashTable.Keys)
            {
                Console.WriteLine($"{obj} - HashTable colecao keys");
            }

            var hashTableClientes = new Hashtable()
            {
                {'1', c1 },
                {'2', c2 },
                {'3', c3 }
            };

            // Para recuperar as propriedades do objeto inserido precisa fazer o type casting
            Console.WriteLine((hashTableClientes['1'] as Cliente));
            Console.WriteLine((hashTableClientes['2'] as Cliente).Nome);

            foreach (var obj in hashTableClientes.Values)
            {
                Console.WriteLine($"{obj} - HashTable colecao values");
            }

            // --------------------------------------------------------------------------------------------------------

            Console.WriteLine("\n Dictionary");
            // Dictionary<T>
            // Basicamente uma combinacao de List<T> com HashTable
            // Colecoes tipadas com o uso de Generics
            // Armazena qualquer tipo de objeto, com informcao estatica de tipo tanto para Key quanto para Value
            IDictionary<string, Cliente> dictionary = new Dictionary<string, Cliente>()
            {
                {"1", c1 },
                {"2", c2 },
                {"3", c3 }
            };

            // Podendo retornar uma coleçao sobre a keys ou values
            foreach (Cliente p in dictionary.Values)
                Console.WriteLine($"{p} - Dictionary colecao values");

            // O Struct generico KeyValuePair é utilizado para tipar um objeto com chave e value
            // Diferentemente de uma coleção, ele não serve para lista e sim para objeto unico
            foreach (KeyValuePair<string, Cliente> kpv in dictionary)
                Console.WriteLine($"{kpv.Key} - {kpv.Value} - KeyValuePair");

            // Podendo verificar com metodos proprios key e value
            if (dictionary.ContainsKey("1"))
            {
                Console.WriteLine(dictionary["1"]);
            }

            // Podendo por delegação fazer uma operacao
            //como pelo metodo Sum, que espera uma Func, que ja esta esperando receber os parametros dos tipo breviamente colocados
            Console.WriteLine($"{dictionary.Sum(d => int.Parse(d.Value.CPF))} - Delegate Dictionary");

            // --------------------------------------------------------------------------------------------------------

            Console.WriteLine("\n Stack");
            // Stack || Stack<T> 
            // Coleções para empilhar objetos
            // Segue o modelo LIFO - Last In First Out
            // Push - Adiciona elemento
            // Pop - Le e retira elemento
            // Peek - Le mas não retira elemento
            var pilha = new Stack();
            pilha.Push(c1);
            pilha.Push(c2);
            pilha.Push(c3);

            Console.WriteLine($"{pilha.Count} - Stack sem Generico Count");
            var obj1 = pilha.Pop();
            Console.WriteLine($"{(obj1 as Cliente).Nome} - Stack sem Generico item");
            var obj2 = pilha.Pop();
            Console.WriteLine($"{(obj2 as Cliente).Nome} - Stack sem Generico item");
            var obj3 = pilha.Peek();
            Console.WriteLine($"{(obj3 as Cliente).Nome} - Stack sem Generico item");


            var pilhaGenerica = new Stack<Cliente>();
            pilhaGenerica.Push(c1);
            pilhaGenerica.Push(c2);
            pilhaGenerica.Push(c3);

            Console.WriteLine($"{pilhaGenerica.Count} - Stack com Generico Count");
            var obj4 = pilhaGenerica.Pop();
            Console.WriteLine($"{obj4.Nome} - Stack com Generico item");
            var obj5 = pilhaGenerica.Pop();
            Console.WriteLine($"{obj5.Nome} - Stack com Generico item");
            var obj6 = pilhaGenerica.Peek();
            Console.WriteLine($"{obj6.Nome} - Stack com Generico item");

            while (pilhaGenerica.Count > 0)
            {
                Console.WriteLine($"{pilhaGenerica.Pop()} - Stack com Generico while");
            }

            foreach (var item in pilha)
            {
                Console.WriteLine($"{(item as Cliente)} - Stack sem Generico foreach");
            }

            // --------------------------------------------------------------------------------------------------------

            Console.WriteLine("\n Queue");
            // Queue || Queue<T> 
            // Segue o modelo FIFO - First In Last Out
            // Enqueue - Adiciona elemento
            // Dequeue - Le e retira elemento
            // Peek - Le mas não retira elemento
            var fila = new Queue();
            var filaGenerica = new Queue<Cliente>();

            fila.Enqueue(c1);
            fila.Enqueue(c2);
            fila.Enqueue(c3);

            filaGenerica.Enqueue(c1);
            filaGenerica.Enqueue(c2);
            filaGenerica.Enqueue(c3);

            Console.WriteLine("Cliente aguardando na fila sem Generico:");
            foreach (var c in fila)
            {
                Console.WriteLine(c);
            }

            while (filaGenerica.Count > 0)
            {
                Console.WriteLine("Pressione uma tecla para chamar o Cliente Fila Generica");
                Console.ReadKey();
                Console.WriteLine($"Chamando: {filaGenerica.Dequeue().Nome}");
            }

        }
    }
}
