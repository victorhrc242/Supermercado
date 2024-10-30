using AutoMapper;
using Core._01_Services;
using Core._01_Services.Interfaces;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Services;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class vendaController : ControllerBase
    {
        private readonly IVendaservice _service;
        private readonly IMapper _mapper;
        public vendaController(IConfiguration config, IMapper mapper)
        {
            string _config = config.GetConnectionString("DefaultConnection");
        _service=new vendaservice(_config);
            _mapper = mapper;
        }
        [HttpPost("adicionar-usuario")]
        public void AdicionarAluno(Venda venda)
        {
            _service.Adicionar(venda);
        }
     
        [HttpGet("listar-usuario")]
        public List<Venda> ListarAluno()
        {
            return _service.Listar();
        }
        [HttpPut("editar-usuario")]
       
        [HttpDelete("deletar-usuario")]
        public void DeletarUsuario(int id)
        {
            _service.Remover(id);
        }

    }
}
