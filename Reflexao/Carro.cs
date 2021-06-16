using System;
using System.Collections.Generic;
using System.Text;

namespace Reflexao
{
    internal class Carro: ICarro
    {
        public string Cor;
        public int Velocidade { get; protected set; }

        public void Acelerar(int quantidade)
        {
            this.Velocidade += quantidade;
        }

        public bool EstaMovendo()
        {
            if (Velocidade == 0)
                return false;
            else
                return true;
        }

        public Carro()
        {
            Cor = "Vermelho";
            this.Velocidade = 0;
        }

        public Carro(string ACor, int AVelocidade)
        {
            Cor = ACor;
            this.Velocidade = AVelocidade;
        }

        public double CalcularKilometrosPorLitro(int kmInicial, int kmFinal, double litros)
        {
            return (kmFinal - kmInicial) / litros;
        }

    }

    internal class CarroSport: Carro
    {
        public CarroSport()
        {
            Cor = "Azul";
        }
    }
}
