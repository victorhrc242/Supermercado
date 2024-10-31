using Core._02_Repository.Interfaces;
using Core._03_Entidades;
using Core.Entidades;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System.Configuration.Internal;
using System.Data.SQLite;

namespace TrabalhoFinal._02_Repository;

public class EnderecoRepository:IEnderecoReposytor
{
    private readonly string ConnectionString;
    public EnderecoRepository(IConfiguration configuration)
    {
        ConnectionString= configuration.GetConnectionString("DefaultConnection");
    }
    public void Adicionar(Endereco endereco)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Insert<Endereco>(endereco);
    }
    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        Endereco endereco = BuscarPorId(id);
        connection.Delete<Endereco>(endereco);
    }
    public void Editar(Endereco endereco)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Update<Endereco>(endereco);
    }
    public List<Endereco> Listar()
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.GetAll<Endereco>().ToList();
    }
    public List<Endereco> ListarCarrinhoDoUsuario(int usuarioId)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        List<Endereco> list = connection.Query<Endereco>($"SELECT Id, UsuarioId, Rua,Bairro,Numero FROM Enderecos WHERE UsuarioId = {usuarioId}").ToList();
 
        return list;
    }
    public Endereco BuscarPorId(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Endereco>(id);
    }
}