using Core._03_Entidades;
using Core._03_Entidades.DTO;
using Core.Entidades;
using FrontEnd.models;
using FrontEnd.UseCases;

namespace FrontEnd;
public class Sistema
{
    private static Usuario UsuarioLogado { get; set; }
    private readonly UsuarioUC _usuarioUC;
    private readonly ProdutoUC _produtoUC;
    private readonly CarrinhoUC _carrinhoUC;
    private readonly EnderecoUC _EnderecoUC;
    public Sistema(HttpClient cliente)
    {
        _usuarioUC = new UsuarioUC(cliente);
        _produtoUC = new ProdutoUC(cliente);
        _carrinhoUC = new CarrinhoUC(cliente);
        _EnderecoUC= new EnderecoUC(cliente);
    }
    public void IniciarSistema()
    {
        int resposta = -1;
        while (resposta != 0)
        {
            if (UsuarioLogado == null)
            {
                resposta = ExibirLogin();

                if (resposta == 1)
                {
                    FazerLogin();
                }
                else if (resposta == 2)
                {
                    Usuario usuario = CriarUsuario();
                    _usuarioUC.CadastrarUsuario(usuario);
                    Console.WriteLine("Usuário cadastrado com sucesso");
                }
                else if (resposta == 3)
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
                ExibirMenuPrincipal();
            }
        }
    }
    public int ExibirLogin()
    {
        Console.WriteLine("--------- LOGIN ---------");
        Console.WriteLine("1 - Deseja Fazer Login");
        Console.WriteLine("2 - Deseja se Cadastrar");
        Console.WriteLine("3 - Listar Usuario Cadastrados");
        return int.Parse(Console.ReadLine());
    }
    public Usuario CriarUsuario()
    {
        Usuario usuario = new Usuario();
        Console.WriteLine("Digite seu nome: ");
        usuario.nome = Console.ReadLine();
        Console.WriteLine("Digite seu username: ");
        usuario.username = Console.ReadLine();
        Console.WriteLine("Digite seu senha: ");
        usuario.senha = Console.ReadLine();
        Console.WriteLine("Digite seu email: ");
        usuario.email = Console.ReadLine();
        return usuario;
    }
    public Produto CriarProduto()
    {
        Produto usuario = new Produto();
        Console.WriteLine("Digite seu nome: ");
        usuario.Nome = Console.ReadLine();
        Console.WriteLine("Digite seu preco: ");
        usuario.Preco = double.Parse(Console.ReadLine());
        return usuario;
    }
    public void FazerLogin()
    {
        Console.WriteLine("Digite seu username: ");
        string username = Console.ReadLine();
        Console.WriteLine("Digite sua senha: ");
        string senha = Console.ReadLine();
        usuariologinDTO usuDTO = new usuariologinDTO
        {
            Username = username,
            Senha = senha
        };
        Usuario usuario = _usuarioUC.FazerLogin(usuDTO);
        if (usuario == null )
        {
            Console.WriteLine("Usuário ou senha inválidos!!!");
        }
        UsuarioLogado = usuario;
    }
    public void ExibirMenuPrincipal()
    {
        Console.WriteLine("1 - Listar Produtos");
        Console.WriteLine("2 - Cadastrar Produto");
        Console.WriteLine("3 - Realizar uma compra");
        Console.WriteLine("Qual operação deseja realizar?");
        int resposta = int.Parse(Console.ReadLine());

        if (resposta == 1)
        {
            ListarProdutos();
        }
        else if (resposta == 2)
        {
            Produto produto = CriarProduto();
            _produtoUC.CiarPorduto(produto);
            Console.WriteLine("Usuário cadastrado com sucesso");
        }
        else if (resposta == 3)
        {
            int opcao = 1;
            while (opcao == 1)
            {
                //Listar Produto
                ListarProdutos();
                //Escolher Produto
                Console.WriteLine("Digite os produtos que deseja comprar:");
                int produtoId = int.Parse(Console.ReadLine());
                Carrinho c = new Carrinho();
                c.ProdutoId = produtoId;
                c.UsuarioId = UsuarioLogado.id;
                _carrinhoUC.adicionarcarrinho(c);

                Console.WriteLine("Escolha a opção: " +
                    "\n 1- Escolher mais produtos" +
                    "\n 2- Finalizar compra");
                opcao = int.Parse(Console.ReadLine());
            }
            List<Readcarrinho> carrinhosDTO = _carrinhoUC.ListarProdutos(UsuarioLogado.id);
            foreach (Readcarrinho car in carrinhosDTO)
            {
                Console.WriteLine(car.ToString());
            }
            RealizarEntrega();
       
        }
    }


    private void RealizarEntrega()
    {
        int idEndereco = 0;
        Console.WriteLine("Escolha uma opção: \n 1- Retirar na loja \n 2- Entregar a domicilio");
        int alternativa = int.Parse(Console.ReadLine());
        if (alternativa == 1)
        {
            Console.WriteLine("Retire a sua compra na loja em 7 dias.");
        }
        else if (alternativa == 2)
        {
            Console.WriteLine("Escolha as opção: \n 1- Listar Enderecos cadastrados \n 2 - Cadastrar endereço");
            int opcao = int.Parse(Console.ReadLine());
            if (opcao == 1)
            {
                List<Endereco> enderecos = _EnderecoUC.ListarEnderecos(UsuarioLogado.id);
                foreach (Endereco end in enderecos)
                {
                    Console.WriteLine(end.ToString());
                }
                Console.WriteLine("Digite qual endereco deseja entregar");
                idEndereco = int.Parse(Console.ReadLine());
                Console.WriteLine("vc deseja comprar os produtos 1=sim 2=não");
                int opcaos = int.Parse(Console.ReadLine());
                if (opcaos == 1)
                {
                    Venda venda = selecionarmetododepagamento();
                    idEndereco = venda.id;
                   List<Readcarrinho> r = _carrinhoUC.somarprodutos(UsuarioLogado.id);
                    foreach(Readcarrinho e in r)
                    {
                        Console.WriteLine(e.ToString());
                    }

                }
            }
            else
            {
                Endereco endereco = CriarEndereco();
                endereco = _EnderecoUC.adicionarcarrinho(endereco);
                idEndereco = endereco.Id;
                
            }

        }


    }


    public Venda selecionarmetododepagamento()
    {
        Venda venda= new Venda();
        Console.WriteLine("qual a forma de pagamento");
        venda.metodopagamento = Console.ReadLine();
        return venda;
    }




    private void ListarProdutos()
    {
        List<Produto> produtos = _produtoUC.ListarProdutos();
        foreach (Produto u in produtos)
        {
            Console.WriteLine(u.ToString());
        }
    }
    public Endereco CriarEndereco()
    {
        Endereco endereco = new Endereco();
        Console.WriteLine("Digite sua rua: ");
        endereco.Rua = Console.ReadLine();
        Console.WriteLine("Digite seu bairro: ");
        endereco.Bairro = Console.ReadLine();
        Console.WriteLine("Digite seu numero: ");
        endereco.Numero = int.Parse(Console.ReadLine());
        endereco.UsuarioId = UsuarioLogado.id;
        return endereco;
    }

}