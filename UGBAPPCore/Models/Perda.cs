namespace APPTCCUGB.Models
{
    public class Perda
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Qtde { get; set; }

        public Perda()
        {
            Id = 0;
            Nome = string.Empty;
            Qtde = 0;
        }
    }
}
