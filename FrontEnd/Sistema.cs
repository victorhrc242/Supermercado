using FrontEnd.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd;
public class Sistema
{
    private readonly UsuarioUC _usuarioUC;
    public Sistema(HttpClient cliente)
    {
           _usuarioUC= new UsuarioUC(cliente);
    }
    public void IniciarSistema()
    {
        int resposta=-1;
        while (resposta!=0)
        {
            resposta = ExibirLogin();
            if (resposta == 2)
            {
                Usuario usuario = criarusuario();
                _usuarioUC.CadastrarUsuario(usuario);
                Console.WriteLine("usuario cadastrado com sucesso");
            }
            if (resposta == 3)
            {
                List<Usuario> usuarios=_usuarioUC.ListarUsuarios();
                foreach (Usuario u in usuarios)
                {
                    Console.WriteLine(u.ToString());
                }
            }
        }
    }
    public int ExibirLogin()
    {
        Console.WriteLine("--------- LOGIN ---------");
        Console.WriteLine("1 - Deseja Fazer Login");
        Console.WriteLine("2 - Deseja se Cadastrar");
        Console.WriteLine("3- Lista usuarios cadastrado");
        return int.Parse(Console.ReadLine());
    }
    public Usuario criarusuario()
    {
        Usuario usuario= new Usuario();
        Console.WriteLine("Digite seu nome");
        usuario.nome = Console.ReadLine();
        Console.WriteLine("Digite seu username");
        usuario.username = Console.ReadLine();
        Console.WriteLine("Digite sua senha");
        usuario.senha = Console.ReadLine();
        Console.WriteLine("Digite seu email");
        usuario.email = Console.ReadLine();
        return usuario;
    } 
}
