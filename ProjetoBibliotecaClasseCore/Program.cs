using ProjetoBibliotecaClasse;
using System;

namespace ProjetoBibliotecaClasseCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente c = new Cliente();
            c.Nome = "Cacilds";
            c.PrintName();
            Console.ReadLine();
        }
    }
}
