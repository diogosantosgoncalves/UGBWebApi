namespace UGBWebApi.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Caixa { get; set; }
        public decimal Qtde { get; set; }
        public decimal QtdeEstimativa { get; set; }
        public bool Administrador { get; set; }

        public Produto()
        {
            Id = 0;
            Nome = string.Empty;
            Caixa = 0;
            Qtde = 0;
            QtdeEstimativa = 1;
            Administrador = false;
        }
    }
}
