using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FrontEnd.UseCases
{
    public class UsuarioUC
    {
        private readonly HttpClient _cliente;
        public UsuarioUC(HttpClient cliente)
        {
            _cliente= cliente;
        }
        public List<Usuario> ListarUsuarios()
        {
         
           return  _cliente.GetFromJsonAsync<List<Usuario>>("Usuario/listar-usuario").Result;

        }
        public  void CadastrarUsuario(Usuario usuario)
        {
            //string apiURL = "https://localhost:7096/Usuario/adicionar-usuario";
            //using HttpClient cliente = new HttpClient();
            //string jsonRequest = JsonSerializer.Serialize(usuario);
            //HttpResponseMessage response = await cliente.PostAsJsonAsync(apiURL, jsonRequest);
            HttpResponseMessage response = _cliente.PostAsJsonAsync("Usuario/adicionar-usuario", usuario).Result;
        }
    }
}
