using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGBAPPCore.Models
{
    public class ProdutoProducao
    {
        public int Id { get; set; }
        public int CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal Qtde { get; set; }
        public decimal QtdeEstimada { get; set; }
        public string Unidade { get; set; }
        public int CodigoProducao { get; set; }

        public ProdutoProducao()
        {
            CodigoProduto = 0;
            NomeProduto = string.Empty;
            Qtde = 0;
            QtdeEstimada = 0;
            Unidade = string.Empty;
            CodigoProducao = 0;
        }
    }
}
