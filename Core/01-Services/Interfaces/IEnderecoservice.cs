using Core._03_Entidades;

namespace Core._01_Services.Interfaces;
public interface IEnderecoservice
{
    void Adicionar(Endereco endereco);
    void Remover(int id);
    List<Endereco> Listar();
    List<Endereco> ListarEnderecoAluno(int usuarioId);
    Endereco BuscarTimePorId(int id);
    void Editar(Endereco editPessoa);
}