using System;
using System.Collections.Generic;

namespace APPTCCUGB.Models
{
    public class Producao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal IndiceDisponibilidade { get; set; }
        public decimal IndicePerfomance { get; set; }
        public decimal IndiceQualidade { get; set; }
        public decimal Resultado { get; set; }
        public Produto Produto { get; set; }
        public Setor Setor { get; set; }
        public Turno Turno { get; set; }
        public Usuario Usuario { get; set; }
        public List<Parada> ListParadas { get; set; }
        public List<Perda> ListPerdas { get; set; }
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
            Produto = new Produto();
            Setor = new Setor();
            Turno = new Turno();
            Usuario = new Usuario();
            ListParadas = new List<Parada>();
            ListPerdas = new List<Perda>();
            QtdeProduzida = 0;
            Fechado = false;
        }
    }
}
