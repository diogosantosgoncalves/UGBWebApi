namespace UGBWebApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Administrador { get; set; }

        public Usuario()
        {
            Id = 0;
            Nome = string.Empty;
            Senha = string.Empty;
            Administrador = false;
        }
    }
}
