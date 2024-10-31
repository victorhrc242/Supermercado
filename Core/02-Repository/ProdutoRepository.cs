using Core._02_Repository.Interfaces;
using Core.Entidades;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data.SQLite;

namespace TrabalhoFinal._02_Repository;

public class ProdutoRepository:IProdutoReposytor
{
    private readonly string ConnectionString;
    public ProdutoRepository(IConfiguration configuration)
    {
        ConnectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public void Adicionar(Produto produto)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Insert<Produto>(produto);
    }
    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        Produto produto = BuscarPorId(id);
        connection.Delete<Produto>(produto);
    }
    public void Editar(Produto produto)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Update<Produto>(produto);
    }
    public List<Produto> Listar()
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.GetAll<Produto>().ToList();
    }
    public Produto BuscarPorId(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Produto>(id);
    }
}
