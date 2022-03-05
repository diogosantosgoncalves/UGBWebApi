namespace APPTCCUGB.Models
{ 
    public class Parada
    {
        public int Id { get; set; }
        public string Observacao { get; set; }
        public decimal Tempo { get; set; }

        public Parada()
        {
            Id = 0;
            Observacao = string.Empty;
            Tempo = 0;
        }
    }
}
