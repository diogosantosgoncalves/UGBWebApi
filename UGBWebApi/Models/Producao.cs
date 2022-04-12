using System;
using System.Collections.Generic;

namespace UGBWebApi.Models
{
    public class Producao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal IndiceDisponibilidade { get; set; }
        public decimal IndicePerfomance { get; set; }
        public decimal IndiceQualidade { get; set; }
        public decimal Resultado { get; set; }
        public decimal QtdeProduzida { get; set; }
        public bool Fechado { get; set; }

        public Producao()
        {
            Id = 0;
            Data = new DateTime();
            IndiceDisponibilidade = 0;
            IndicePerfomance = 0;
            IndiceQualidade = 0;
            Resultado = 0;
            QtdeProduzida = 0;
            Fechado = false;
        }
    }
}
