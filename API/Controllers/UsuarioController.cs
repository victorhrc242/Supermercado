using AutoMapper;
using Core._01_Services.Interfaces;
using Core._03_Entidades.DTO;
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Services;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioservice _service;
    private readonly IMapper _mapper;
    public UsuarioController(IConfiguration config, IMapper mapper,IUsuarioservice usuarioservice)
    {
        string _config = config.GetConnectionString("DefaultConnection");
        _service = usuarioservice;
        _mapper = mapper;
    }
    [HttpPost("adicionar-usuario")]
    public void AdicionarAluno(Usuario usuarioDTO)
    {
        _service.Adicionar(usuarioDTO);
    }
    [HttpPost("fazer-login")]
    public Usuario FazerLogin(usuariologinDTO usuarioLogin)
    {
        Usuario usuario = _service.FazerLogin(usuarioLogin);
        return usuario;
    }
    [HttpGet("listar-usuario")]
    public List<Usuario> ListarAluno()
    {
        return _service.Listar();
    }
    [HttpPut("editar-usuario")]
    public void EditarUsuario(Usuario p)
    {
        _service.Editar(p);
    }
    [HttpDelete("deletar-usuario")]
    public void DeletarUsuario(int id)
    {
        _service.Remover(id);
    }
}