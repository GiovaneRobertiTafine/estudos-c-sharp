using ProjetoBibliotecaClasse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBibliotecaClasseFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente c = new Cliente();
            c.Nome = "Oloco meu";
            c.PrintName();
            Console.ReadLine();
        }
    }
}
