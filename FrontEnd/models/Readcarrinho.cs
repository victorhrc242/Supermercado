using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.models
{
    public   class  Readcarrinho
    {
        public int id { get; set; }
            public Usuario usuario { get; set; }
            public Produto produto { get; set; }

        public override string ToString()
        {
            return $"Usuario {usuario.nome} - Produto : {produto.Nome} - Preço: {produto.Preco}";
        }
    }
}

