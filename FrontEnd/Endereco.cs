﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._03_Entidades
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public int UsuarioId { get; set; }
        public override string ToString()
        {
            return $"id:{Id} -nome:{UsuarioId} -Preço:{Rua} -Bairro{Bairro} -Numero{Numero}";
        }
    }
}
