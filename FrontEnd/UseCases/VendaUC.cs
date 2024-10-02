using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.UseCases
{
    public class VendaUC
    {
        private readonly HttpClient _cliente;
        public VendaUC(HttpClient cliente)
        {
            _cliente = cliente;
        }
        public Venda comprarproduto(Venda venda)
        {
            HttpResponseMessage response = _cliente.PostAsJsonAsync("Endereco/adicionar-endereco", venda).Result;
            Venda vendacadastrada = response.Content.ReadFromJsonAsync<Venda>().Result;
            return vendacadastrada;
        }

        public List<Venda> listarvendasdousuario(int usuarioid)
        {
            return _cliente.GetFromJsonAsync<List<Venda>>("Endereco/listar-endereco-usuario?usuarioId=" + usuarioid).Result;
        }
    }
}
