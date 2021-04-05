using System;
using System.Collections.Generic;
using System.Text;

namespace TypeCasting
{
    public class Pessoa
    {
        public string Nome;
    }

    class PessoaFisica : Pessoa
    {
        public string Cpf;
    }

    class PessoaJuridica : Pessoa 
    {
        public string Cnpj; 
    }

    public static class RelatorioPessoas
    {
        public static void Imprimir(Pessoa pessoa)
        {
            Console.WriteLine(pessoa.Nome);

            // O operador IS do C# permite testar em tempo de execução (runtime)
            //se um determinado objeto é de um determinado tipo ou de uma classe base (superclasse ou ancestral),
            //ou ainda, se implementa determinada interface
            if (pessoa is PessoaFisica)
            {
                // Operador AS do C# permite converter em tempo de execução (runtime)
                //um determinado tipo de objeto mais primitivo (genérico)
                //para um tipo mais específico, a fim de se obterem informações mais completas sobre o mesmo
                Console.WriteLine((pessoa as PessoaFisica).Cpf);
            }

            if (pessoa is PessoaJuridica)
            {
                Console.WriteLine((pessoa as PessoaJuridica).Cnpj);
            }
        }
    }
}
