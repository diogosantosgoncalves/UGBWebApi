namespace UGBWebApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Usuario()
        {
            Id = 0;
            Nome = string.Empty;
        }
    }
}
