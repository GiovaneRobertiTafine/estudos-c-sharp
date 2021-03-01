using System;
using System.Collections.Generic;
using System.Text;

namespace Delegacao
{
    // Delegate
    // Classe para realizar um função por delegação sem decorar nenhum delegate
    public class Boleto
    {
        public void Pagar(double valor)
        {
            Console.WriteLine($"Pago no boleto valor de {valor} sem delegate");
        }
    }

    public delegate void PagarEvent(double valor);

    public class Pedido
    {
        public event PagarEvent Pagar; // ponteiro para um método

        // Instância como se fosse o ponteiro para delegar a outro objeto, realizando processo sem delegate
        private Boleto _boleto = new Boleto();

        // Variavel de classe para realizar um delegate injetado no próprio método que é chamado, método FecharInjetado
        // o valor passado para a função, vai ser colocado quando instânciado
        // Podendo tambem ser colocado como parametro no próprio método chamado como no método FecharInjetadoParam
        public double valor;

        public void Fechar(double valor)
        {
            // delegação...
            this.Pagar(valor);
            // delegação sem delegate
            this._boleto.Pagar(valor);
        }

        // Método para que se realize o delegate, recebendo a função como parâmentro, injetando o event quando chamado
        public void FecharInjetado(PagarEvent Pagar)
        {
            Pagar(valor);
        }

        // Método para que se realize o delegate recebendo a função e o valor como parâmentro, injetando o event quando chamado
        public void FecharInjetadoParam(PagarEvent Pagar, double valor)
        {
            Pagar(valor);
        }

    }

    // --------------------------------------------------------------------------------------------------------
    // Action
    // Classe que ira servir como suporte para a aplicação de delegate genéricos Action e delegate Predicate
    public class Cliente
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        public int Idade { get; set; }

    }
}
