using System;

namespace ProjetoBibliotecaClasse
{
    public class Cliente
    {
        public string Nome { get; set; }

        public void PrintName()
        {
            Console.WriteLine(this.Nome);
        }
    }
}
