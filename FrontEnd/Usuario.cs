﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string username { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public override string ToString()
        {
            return $"id:{id} -nome:{nome} -email:{email}";
        }
    }
}
