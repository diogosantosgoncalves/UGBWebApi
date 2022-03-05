namespace APPTCCUGB.Models
{
    public class Setores
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal HorasProducao { get; set; }

        public Setores()
        {
            Id = 0;
            Nome = string.Empty;
            HorasProducao = 0;
        }
    }
}
