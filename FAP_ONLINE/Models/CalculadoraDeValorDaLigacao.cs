
using System;

namespace FAP_ONLINE.Models
{
    //Calcula o valor da ligações com e sem o plano fale mais
    public class CalculadoraDeValorDaLigacao
    {

        //Aumento de 10% no valor por minuto referente aos minutos excedentes do plano fale mais
        private const decimal AcrescimoExcedente = 1.10m;

        //Calcula o valor da ligação sem o plano, usando a tarifa normal pelo tempo total
        public decimal CalculoSemPlano(int tempo, decimal valorPorMinuto)
        {
            if (tempo < 0)
                throw new ArgumentException("O tempo não pode ser negativo.");

            if (valorPorMinuto < 0)
                throw new ArgumentException("O valor por minuto não pode ser negativo.");

            return tempo * valorPorMinuto;
        }


        //Calcula o valor da ligação com o plano, minutos do plano são gratuitos e só é cobrado o excedente com taxa de 10% sobre tarifa normal
        public decimal CalculoComPlano(int tempo, decimal valorPorMinuto, int minutosGratuitos)
        {
            if (tempo < 0)
                throw new ArgumentException("O tempo não pode ser negativo.");

            if (valorPorMinuto < 0)
                throw new ArgumentException("O valor por minuto não pode ser negativo.");

            if (tempo <= minutosGratuitos)
                return 0m; //Tempo dentro do plano, gratuito

            int tempoExcedente = tempo - minutosGratuitos;
            decimal valorComAcrescimo = valorPorMinuto * AcrescimoExcedente;
            return tempoExcedente * valorComAcrescimo;
        }
    }
}