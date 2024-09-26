using AutoMapper;
using Core._03_Entidades.DTO;
using Core.Entidades;
using FrontEnd.models;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Services;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CarrinhoController : ControllerBase
{
    private readonly CarrinhoService _service;
    private readonly IMapper _mapper;
    public CarrinhoController(IConfiguration config, IMapper mapper)
    {
        string _config = config.GetConnectionString("DefaultConnection");
        _service = new CarrinhoService(_config);
        _mapper = mapper;
    }
    [HttpPost("adicionar-carrinho")]
    public void AdicionarAluno(Carrinho carrinhoDTO)
    {
        Carrinho carrinho = _mapper.Map<Carrinho>(carrinhoDTO);
        _service.Adicionar(carrinho);
    }
    [HttpGet("listar-carrinho")]
    public List<CarrinhoDTO> ListarAluno()
    {
        List<CarrinhoDTO> listaDTO = _mapper.Map<List<CarrinhoDTO>>(_service.Listar());
        return listaDTO;
    }
    [HttpPut("editar-carrinho")]
    public void EditarCarrinho(Carrinho p)
    {
        _service.Editar(p);
    }
    [HttpDelete("deletar-carrinho")]
    public void DeletarCarrinho(int id)
    {
        _service.Remover(id);
    }
}
