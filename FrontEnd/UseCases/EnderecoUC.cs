using Core._03_Entidades;
using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.UseCases
{
    public class EnderecoUC
    {
        private readonly HttpClient _cliente;
        public EnderecoUC(HttpClient cliente)
        {
            _cliente = cliente;
        }
        public Endereco adicionarcarrinho(Endereco endereco)
        {
            HttpResponseMessage response = _cliente.PostAsJsonAsync("Endereco/adicionar-endereco", endereco).Result;
            Endereco enderecoCadastrado = response.Content.ReadFromJsonAsync<Endereco>().Result;
            return enderecoCadastrado;
        }

        public List<Endereco> ListarEnderecos(int usuraioid)
        {

            return _cliente.GetFromJsonAsync<List<Endereco>>("Endereco/listar-endereco-usuario?usuarioId=" + usuraioid).Result;

        }
    }
}
