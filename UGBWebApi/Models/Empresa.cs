using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UGBWebApi.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Empresa()
        {
            Id = 0;
            Nome = string.Empty;
        }
    }
}
