using Core._03_Entidades.DTO;
using Core.Entidades;
using FrontEnd.models;
using FrontEnd.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd;
public class Sistema
{
    private static Usuario usuariologado { get; set; }
    private readonly UsuarioUC _usuarioUC;
    private readonly ProdutoUC _produtoUC;
    private readonly CarrinhoUC _carrinhoUC;
    public Sistema(HttpClient cliente)
    {
        _usuarioUC = new UsuarioUC(cliente);
        _produtoUC = new ProdutoUC(cliente);
        _carrinhoUC=new CarrinhoUC(cliente);
    }
    public void IniciarSistema()
    {
        int resposta = -1;
        while (resposta != 0)
        {
            if (usuariologado == null)
            {
                resposta = ExibirLogin();
                if (resposta == 1)
                {
                    fazerlogin();
                }
                if (resposta == 2)
                {
                    Usuario usuario = criarusuario();
                    _usuarioUC.CadastrarUsuario(usuario);
                    Console.WriteLine("usuario cadastrado com sucesso");
                }
                if (resposta == 3)
                {
                    List<Usuario> usuarios = _usuarioUC.ListarUsuarios();
                    foreach (Usuario u in usuarios)
                    {
                        Console.WriteLine(u.ToString());
                    }
                }
            }
            else
            {
                resposta = ExibirLoginMenuprincipal();
                if (resposta == 1)
                {
                    List<Produto> produtos = _produtoUC.ListarProdutos();
                    foreach (Produto p in produtos)
                    {
                        Console.WriteLine(p.ToString());
                    }
                }
                if (resposta == 2)
                {
                    Produto produto = criaproduto();
                    _produtoUC.CiarPorduto(produto);
                    Console.WriteLine("produto cadastrado com sucesso");
                }
                if (resposta == 3)
                {
                    List<Produto> carrinhos = _produtoUC.ListarProdutos();
                    foreach (Produto u in carrinhos)
                    {
                        Console.WriteLine(u.ToString());
                    }
                
                    Carrinho carrinho= comprarProduto();
                    _carrinhoUC.adicionarcarrinho(carrinho);
                    Console.WriteLine("produto comprado com sucesso");

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
        Usuario usuario = new Usuario();
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
    public void fazerlogin()
    {
        Console.WriteLine("Digite seu username");
        string usernames = Console.ReadLine();
        Console.WriteLine("Digite sua senha");
        string senhas = Console.ReadLine();
        usuariologinDTO usoDTO = new usuariologinDTO()
        {
            Username = usernames,
            Senha = senhas
        };
        Usuario usuario = _usuarioUC.fazerlogin(usoDTO);
        if (usuario == null)
        {
            Console.WriteLine("usuario ou senha invalidos!!!");
        }
        usuariologado = usuario;
        Console.WriteLine("usuario logado!");
    }


    public int ExibirLoginMenuprincipal()
    {
            Console.WriteLine("1- Listar Produtos");
            Console.WriteLine("2- Cadastrar Produto");
            Console.WriteLine("2- Realizar uma Compra");
            Console.WriteLine("qual operação deseja realizar");
        return int.Parse(Console.ReadLine());

    

    }
    public Produto criaproduto()
    {
        Produto produto = new Produto();
        Console.WriteLine("Digite o nome do produto");
        produto.Nome = Console.ReadLine();
        Console.WriteLine("Digite o preço");
        produto.Preco = int.Parse(Console.ReadLine());


        return produto;
    }

    public Carrinho comprarProduto()
    {
        Carrinho carrinho=new Carrinho();
        Console.WriteLine("escolha o produto");
        carrinho.ProdutoId=int.Parse(Console.ReadLine());
        List<Produto> carrinhos = _produtoUC.ListarProdutos();
        foreach (Produto u in carrinhos)
        {
            Console.WriteLine(u.ToString());
        }
        return carrinho;


    }
}
