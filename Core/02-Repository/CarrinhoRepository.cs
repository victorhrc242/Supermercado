using Core._03_Entidades.DTO;
using Core.Entidades;
using Dapper.Contrib.Extensions;
using FrontEnd.models;
using System.Data.SQLite;

namespace TrabalhoFinal._02_Repository;

public class CarrinhoRepository
{
    private readonly string ConnectionString;
    private readonly ProdutoRepository _produtoreposyitario;
    private readonly UsuarioRepository _usuariorepositor;
    public CarrinhoRepository(string connectioString)
    {
        ConnectionString = connectioString;
        _produtoreposyitario = new ProdutoRepository(connectioString);
        _usuariorepositor = new UsuarioRepository(connectioString);
        
    }
    public void Adicionar(Carrinho carrinho)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Insert<Carrinho>(carrinho);
    }
    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        Carrinho carrinho = BuscarPorId(id);
        connection.Delete<Carrinho>(carrinho);
    }
    public void Editar(Carrinho carrinho)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Update<Carrinho>(carrinho);
    }
    //template trabalho final
    public List<Readcarrinho> Listar(int usuarioLogadoId)
    {

        using var connection = new SQLiteConnection(ConnectionString);

        // Filtrar carrinhos pelo usuarioLogadoId
        List<Carrinho> carrinhos = connection.GetAll<Carrinho>()
                                             .Where(c => c.UsuarioId == usuarioLogadoId)
                                             .ToList();

        List<Readcarrinho> carrinhosDTO = new List<Readcarrinho>();

        foreach (Carrinho car in carrinhos)
        {
            Readcarrinho carrinhoDTO = new Readcarrinho();
            carrinhoDTO.produto = _produtoreposyitario.BuscarPorId(car.ProdutoId);
            carrinhoDTO.usuario = _usuariorepositor.BuscarPorId(car.UsuarioId);
            carrinhosDTO.Add(carrinhoDTO);
        }

        return carrinhosDTO;

    }
    public Carrinho BuscarPorId(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Carrinho>(id);
    }
}
