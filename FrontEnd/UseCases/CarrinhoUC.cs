using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.UseCases
{
   
    public class CarrinhoUC
    {
        private readonly HttpClient _cliente;
        public CarrinhoUC(HttpClient cliente)
        {
            _cliente= cliente;
        }
        public void adicionarcarrinho(Carrinho carrinho)
        {
            HttpResponseMessage response = _cliente.PostAsJsonAsync("Carrinho/adicionar-carrinho", carrinho).Result;
        }

        public List<Carrinho> ListarProdutos()
        {

            return _cliente.GetFromJsonAsync<List<Carrinho>>("Carrinho/listar-carrinho").Result;

        }

    }
}
