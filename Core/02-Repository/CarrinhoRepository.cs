using Core._02_Repository.Interfaces;
using Core.Entidades;
using Dapper;
using Dapper.Contrib.Extensions;
using FrontEnd.models;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;

namespace TrabalhoFinal._02_Repository;

public class CarrinhoRepository:ICarrinhoreposytor1
{
    private readonly string ConnectionString;
    private readonly IProdutoReposytor _repositoryProduto;
    private readonly IusuarioReposytor _repositoryUsuario;
    public CarrinhoRepository(IConfiguration configuration,IusuarioReposytor usuariorepositor,IProdutoReposytor produtorepositorio)
    {
        ConnectionString = configuration.GetConnectionString("DefaultConnection");
        _repositoryProduto = produtorepositorio;
        _repositoryUsuario = usuariorepositor;
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