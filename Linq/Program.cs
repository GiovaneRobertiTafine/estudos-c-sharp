using System;
using System.IO;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Query onde sera listado todos os arquivos do diretorio
            // Sendo atribuido o caminho completo
            var query1 = from arquivo in Directory.GetFiles(@"c:\windows")
                         select arquivo;

            foreach (var arq in query1)
            {
                Console.Write($"\n{arq}");

            }


        }
    }
}
