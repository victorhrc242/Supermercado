using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Carrinho
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }
        public override string ToString()
        {
            return $"id:{Id} -nome:{UsuarioId} -Preço:{ProdutoId}";
        }

 
    }
}
