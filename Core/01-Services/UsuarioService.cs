using Core._01_Services.Interfaces;
using Core._02_Repository.Interfaces;
using Core._03_Entidades.DTO;
using Core.Entidades;
using TrabalhoFinal._02_Repository;

namespace TrabalhoFinal._01_Services;

public class UsuarioService:IUsuarioservice
{
    private readonly IusuarioReposytor repository;
    public UsuarioService(IusuarioReposytor _usuarioreposytor)
    {
        repository = _usuarioreposytor;
    }
    public void Adicionar(Usuario usuario)
    {
        repository.Adicionar(usuario);
    }

    public void Remover(int id)
    {
        repository.Remover(id);
    }

    public List<Usuario> Listar()
    {
        return repository.Listar();
    }
    public Usuario BuscarTimePorId(int id)
    {
        return repository.BuscarPorId(id);
    }
    public void Editar(Usuario editPessoa)
    {
        repository.Editar(editPessoa);
    }
    public Usuario FazerLogin(usuariologinDTO usuarioLogin)
    {
        List<Usuario> listUsuario = Listar();
        foreach (Usuario usuario in listUsuario)
        {
            if (usuario.Username == usuarioLogin.Username
                && usuario.Senha == usuarioLogin.Senha)
            {
                return usuario;
            }
        }
        return null;
    }
}