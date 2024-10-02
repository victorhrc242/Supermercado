using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._03_Entidades
{
    public class Venda
    {
        public int id { get; set; }
        public int ebderecoid { get; set; }
        public string metodopagamento { get; set; }
        public bool valofinl { get; set; }
    }
}
