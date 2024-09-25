using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.UseCases
{
    public class ProdutoUC
    {



        private readonly HttpClient _cliente;
        public ProdutoUC(HttpClient cliente)
        {
            _cliente = cliente; 
        }

        public void CiarPorduto(Produto produto)
        {
            HttpResponseMessage response = _cliente.PostAsJsonAsync("Produto/adicionar-produto", produto).Result;
        }



        public List<Produto> ListarProdutos()
        {

            return _cliente.GetFromJsonAsync<List<Produto>>("Produto/listar-produto").Result;
          
        }

    }
}
