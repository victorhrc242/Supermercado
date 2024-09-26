using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.models
{
    public  class Readcarrinho
    {

      
            public int Id { get; set; }
            public int IdUsuario { get; set; }
            public string usuario { get; set; } // Adicione o nome do usuário
            public int IdProduto { get; set; }
            public string produto { get; set; } // Adicione o nome do produto
            public decimal PrecoProduto { get; set; } // Adicione o preço do produto
        



        public override string ToString()
        {
            return $"Usuário: {usuario}, Produto: {produto}";
        }
    }
}
