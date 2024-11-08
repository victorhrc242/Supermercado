using AutoMapper;
using Core._01_Services.Interfaces;
using Core._03_Entidades.DTO;
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
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
    /// <summary>
    /// adiciona o usuario
    /// </summary>
    /// <param name="usuarioDTO"></param>
    /// <returns> isso adicionara o usuario</returns>
    [HttpPost("adicionar-usuario")]
    public IActionResult AdicionarAluno(Usuario usuarioDTO)
    {
        try
        {
            _service.Adicionar(usuarioDTO);
            return Ok();
        }
        catch (Exception erro)
        {

            return BadRequest($"Ocorreu un erro ao adicionar aluno, o erro foi" +
                $"\n{erro.Message}");
        }

      
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
    public IActionResult EditarUsuario(Usuario p)
    {
        _service.Editar(p);
        return NoContent();
    }
    [HttpDelete("deletar-usuario")]
    public IActionResult DeletarUsuario(int id)
    {
        _service.Remover(id);
        return NoContent();
    }
}