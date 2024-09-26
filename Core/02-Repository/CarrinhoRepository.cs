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
    public List<CarrinhoDTO> Listar()
    {
        using var connection = new SQLiteConnection(ConnectionString);
        List<Carrinho> carrinhos = connection.GetAll<Carrinho>().ToList();
        List<CarrinhoDTO> carrinhosDTO =  new List<CarrinhoDTO>();
        foreach (Carrinho car in carrinhos)
        {
            CarrinhoDTO carrinhoDTO = new CarrinhoDTO();
            carrinhoDTO.produto = _produtoreposyitario.BuscarPorId(car.Id);
            carrinhoDTO.usuario= _usuariorepositor.BuscarPorId(car.Id);
        

        }
        return carrinhosDTO;
       
    }
    public Carrinho BuscarPorId(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Carrinho>(id);
    }
}
