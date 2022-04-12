using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UGBWebApi.Models
{
    public class ProdutoProducao
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public decimal Qtde { get; set; }
        public decimal QtdeEstimada { get; set; }
        public string Unidade { get; set; }

        public ProdutoProducao()
        {
            NomeProduto = string.Empty;
            Qtde = 0;
            QtdeEstimada = 0;
            Unidade = string.Empty;
        }
    }
}
