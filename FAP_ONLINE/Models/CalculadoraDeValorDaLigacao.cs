using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAP_ONLINE.Models
{
    public class CalculadoraDeValorDaLigacao
    {

        public decimal CalculoSemPlano(int tempo, decimal valorPorMinutos)
        {
            return tempo * valorPorMinutos;
        }

        public decimal CalculoComPlano(int tempo, decimal valorPorMinutos, int minutosGratuitos)
        {
            if (tempo <= minutosGratuitos)
            {
                return 0m;
            }

            int tempoExcedente = tempo - minutosGratuitos;
            decimal valorComAcrescimo = valorPorMinutos * 1.10m;
            return tempoExcedente * valorComAcrescimo;
        }
    }
}