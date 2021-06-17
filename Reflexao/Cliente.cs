using System;
using System.Collections.Generic;
using System.Text;

namespace Reflexao
{
    class Cliente
    {
        public string Nome { get; protected set; }

        public Cliente(string nome)
        {
            this.Nome = nome;
        }

        public void Imprimir(string sobrenome)
        {
            Console.WriteLine($"{Nome} {sobrenome}");
        }

        public void GetNome(string sobrenome = "Sobrenome")
        {
            Console.WriteLine($"{Nome} {sobrenome}");
        }
    }
}
