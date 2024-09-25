using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public override string ToString()
        {
            return $"id:{Id} -nome:{Nome} -Preço:{Preco}";
        }
    }
}
