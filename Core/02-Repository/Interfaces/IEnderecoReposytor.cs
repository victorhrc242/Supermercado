using Core._03_Entidades;

namespace Core._02_Repository.Interfaces;

public interface IEnderecoReposytor
{
    void Adicionar(Endereco endereco);
    void Remover(int id);
    void Editar(Endereco endereco);
    List<Endereco> Listar();
    List<Endereco> ListarCarrinhoDoUsuario(int usuarioId);
    Endereco BuscarPorId(int id);
}
