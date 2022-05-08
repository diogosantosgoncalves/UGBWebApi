using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPTCCUGB.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Unidade { get; set; }
        public decimal QtdeEstimativa { get; set; }

        public Produto()
        {
            Id = 0;
            Nome = string.Empty;
            Unidade = string.Empty;
            QtdeEstimativa = 1;
        }
    }
}
