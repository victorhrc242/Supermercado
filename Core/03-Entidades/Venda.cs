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
        public  int  Enderecoid { get; set; }
        public string Metododepagamento { get; set; }
        public bool Valorfinal { get; set; }
    }
}
