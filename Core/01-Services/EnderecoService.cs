
using Core._01_Services.Interfaces;
using Core._03_Entidades;
using Core.Entidades;
using TrabalhoFinal._02_Repository;

namespace TrabalhoFinal._01_Services;

public class EnderecoService: IEnderecoservice
{
    public EnderecoRepository repository { get; set; }
    public EnderecoService(string _config)
    {
        repository = new EnderecoRepository(_config);
    }
    public void Adicionar(Endereco endereco)
    {
        repository.Adicionar(endereco);
    }

    public void Remover(int id)
    {
        repository.Remover(id);
    }

    public List<Endereco> Listar()
    {
        return repository.Listar();
    }
    public List<Endereco> ListarEnderecoAluno(int usuarioId)
    {
        return repository.ListarCarrinhoDoUsuario(usuarioId);
    }
    public Endereco BuscarTimePorId(int id)
    {
        return repository.BuscarPorId(id);
    }
    public void Editar(Endereco editPessoa)
    {
        repository.Editar(editPessoa);
    }
}