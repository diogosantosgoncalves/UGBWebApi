using System;

namespace APPTCCUGB.Models
{ 
    public class Parada
    {
        public int Id { get; set; }
        public int CodigoProducao { get; set; }
        public string Observacao { get; set; }
        public decimal Tempo { get; set; }
        public TimeSpan HoraInicial { get; set; }
        public TimeSpan HoraFinal { get; set; }

        public Parada()
        {
            Id = 0;
            CodigoProducao = 0;
            Observacao = string.Empty;
            Tempo = 0;
        }
    }
}
