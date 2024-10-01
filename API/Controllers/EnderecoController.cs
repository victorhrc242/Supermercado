using AutoMapper;
using Core._01_Services;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Services;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController:ControllerBase
    {
        private readonly EnderecoService _service;
        private readonly IMapper _mapper;
        public EnderecoController(IConfiguration config, IMapper mapper)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            _service = new EnderecoService(_config);
            _mapper = mapper;
        }
        [HttpPost("adicionar-Endereço")]
        public void AdicionarEndereco(Endereco Endereco)
        {
            Endereco ender = _mapper.Map<Endereco>(Endereco);
            _service.Adicionar(ender);
        }
        [HttpGet("listar-endereco")]
        public List<Endereco> ListarCarrinhoDoUsuario([FromQuery] int usuarioId)
        {
            return _service.Listar(usuarioId);
        }
        [HttpPut("editar-Endereco")]
        public void EditarEndereco(Endereco p)
        {
            _service.Editar(p);
        }
        [HttpDelete("deletar-Endereco")]
        public void DeletarEndereco(int id)
        {
            _service.Remover(id);
        }
    }
}
