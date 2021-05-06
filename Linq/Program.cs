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

            Console.WriteLine("query1 -------------------------");
            foreach (var arq in query1)
            {
                Console.WriteLine($"{arq}");

            }

            // Para apresentar somente o nome do arquivo, sem o caminho
            //e mais a informacao da extensao, pode-se fazer uma projecao.
            // O recurso dos tipos anonimos, permite fazer uma projeção do resultado
            //de uma consulta LINQ sem necessidade de se criar um novo tipo manualmente

            var query2 = from arquivo in Directory.GetFiles(@"C:\Windows")
                         select new
                         {
                             NomeArquivo = Path.GetFileName(arquivo),
                             Extensao = Path.GetExtension(arquivo)
                         };

            Console.WriteLine("query2 -------------------------");
            foreach (var arq in query2)
                Console.WriteLine($"{arq}");

            // Clásulas let, orderby, ascending e descending

            // Let permite introduzir uma variavel para armazenar resultados
            //de expressoes intermediarias numa expressao de consulta
            // Deste modo, o resultado armazenado na variavel pode ser reutilizado na consulta

            // Orderby, classifica os resultados em ordem ascendente, definido pelo uso
            //opcional da clausula ascending, ou descendente, definido pelo uso obrigatorio
            //da clausula descending

            // A clausula orderby pode ser usada para classificar o resultado da consulta
            //a seguir em ordem crescente de extensão (opcional o uso do ascending)
            //e decrescente de nome de arquivo (obrigatório o uso do descending)
            // A clausula let pode se usada para evitar a repiticao das operacoes de extracao
            //do nome de arquivo e da extensao dos nomes completos dos arquivos

            var query3 = from arquivos in Directory.GetFiles(@"C:/Windows")
                         let nomeArquivo = Path.GetFileName(arquivos)
                         let extensao = Path.GetExtension(arquivos).ToUpper()
                         orderby extensao, nomeArquivo descending
                         select new
                         {
                             NomeArquivo = nomeArquivo,
                             Extensao = extensao
                         };

            Console.WriteLine("query3 -------------------------");
            foreach (var arq in query3)
                Console.WriteLine(arq);

        }
    }
}
