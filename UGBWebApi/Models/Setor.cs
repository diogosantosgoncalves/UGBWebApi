namespace UGBWebApi.Models
{
    public class Setor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal HorasProducao { get; set; }


        public Setor()
        {
            Id = 0;
            Nome = string.Empty;
            HorasProducao = 0;
        }
    }
}
