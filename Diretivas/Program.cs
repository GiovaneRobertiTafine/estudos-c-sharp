#define DEBUG
// Definindo diretiva DEBUG
// DEBUG é uma diretiva pré-definida pelo sistema
// Se por exemplo não declarasse ela, e colocasse o modo de execução para release, ela estaria indefinida 
#define TRACE
// Definindo diretiva TRACE
#undef TRACE
// Retirando diretiva TRACE
using System;
using TypeCasting;

namespace Diretivas
{
    class Program
    {
        static void Main(string[] args)
        {

            // Type Casting -----------------------------
            var p1 = new PessoaFisica()
            {
                Nome = "Giovane",
                Cpf = "12312312312"
            };
            var p2 = new PessoaJuridica()
            {
                Nome = "Roberti",
                Cnpj = "12345678901"
            };

            RelatorioPessoas.Imprimir(p1);
            RelatorioPessoas.Imprimir(p2);

            // Diretivas de Compilação -----------------------------
            /*
                Instruem o compilador o que deve ou não ser compilado (Compilação condicional)
                Pode-se usar diretivas pré-definidas pelo sistema (ex. Debug)
                Pode-se criar novas diretivas
                Compilar ignora o que não estiver de acordo com a diretiva
                #define, #if, #undef, #else
            */

            // Acima, no inicio do arquivo, da classe esta definido as diretivas

#if (DEBUG) 
    Console.WriteLine("Debugging is enabled");
#endif

#if (TRACE)
    Console.WriteLine("Tracing is enabled");  
#endif


        }
    }


}
