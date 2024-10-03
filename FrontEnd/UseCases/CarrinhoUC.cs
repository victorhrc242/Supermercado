using Core.Entidades;
using FrontEnd.models;
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
            _cliente = cliente;
        }
        public void adicionarcarrinho(Carrinho carrinho)
        {
            HttpResponseMessage response = _cliente.PostAsJsonAsync("Carrinho/adicionar-carrinho", carrinho).Result;
        }

        public List<Readcarrinho> ListarProdutos(int usuarioid)
        {

            return _cliente.GetFromJsonAsync<List<Readcarrinho>>("Carrinho/listar-carrinho-do-usuario?usuarioId=" + usuarioid).Result;

        }
        public double Somar(int usuarioId)
        {
            List<Readcarrinho> produtos = ListarProdutos(usuarioId);
            double total = 0;
            if (produtos != null)
            {
                foreach (var produto in produtos)
                {
                    total += produto.produto.Preco; 
                }
            }

            return total;
        }
    }
}


