namespace APPTCCUGB.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Qtde { get; set; }

        public Turno()
        {
            Id = 0;
            Nome = string.Empty;
            Qtde = string.Empty;
        }
    }
}
