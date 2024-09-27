using Core.Entidades;
using Dapper;
using Dapper.Contrib.Extensions;
using FrontEnd.models;
using System.Data.SQLite;

namespace TrabalhoFinal._02_Repository;

public class CarrinhoRepository
{
    private readonly string ConnectionString;
    private readonly ProdutoRepository _repositoryProduto;
    private readonly UsuarioRepository _repositoryUsuario;
    public CarrinhoRepository(string connectioString)
    {
        ConnectionString = connectioString;
        _repositoryProduto = new ProdutoRepository(connectioString);
        _repositoryUsuario = new UsuarioRepository(connectioString);
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
    public List<Carrinho> Listar()
    {
        using var connection = new SQLiteConnection(ConnectionString);
        List<Carrinho> list = connection.GetAll<Carrinho>().ToList();
        //TransformarListaCarrinhoEmCarrinhoDTO();
        return list;
    }

    private List<Readcarrinho> TransformarListaCarrinhoEmCarrinhoDTO(List<Carrinho> list)
    {
        List<Readcarrinho> listDTO = new List<Readcarrinho>();

        foreach (Carrinho car in list)
        {
            Readcarrinho readCarrinho = new Readcarrinho();
            readCarrinho.produto = _repositoryProduto.BuscarPorId(car.ProdutoId);
            readCarrinho.usuario = _repositoryUsuario.BuscarPorId(car.UsuarioId);
            listDTO.Add(readCarrinho);
        }
        return listDTO;
    }

    public List<Readcarrinho> ListarCarrinhoDoUsuario(int usuarioId)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        List<Carrinho> list = connection.Query<Carrinho>($"SELECT Id, UsuarioId, ProdutoId FROM Carrinhos WHERE UsuarioId = {usuarioId}").ToList();
        List<Readcarrinho> listDTO = TransformarListaCarrinhoEmCarrinhoDTO(list);
        return listDTO;
    }
    public Carrinho BuscarPorId(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Carrinho>(id);
    }
}