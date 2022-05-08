namespace UGBWebApi.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal QtdeEstimativa { get; set; }
        public bool Administrador { get; set; }
        public string Unidade { get; set; }

        public Produto()
        {
            Id = 0;
            Nome = string.Empty;
            QtdeEstimativa = 1;
            Administrador = false;
            Unidade = string.Empty;
        }
    }
}
