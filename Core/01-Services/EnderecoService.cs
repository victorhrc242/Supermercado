using Core._02_Repository;
using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._02_Repository;

namespace Core._01_Services
{
    public class EnderecoService
    {
        public EnderecoRepositor repository { get; set; }
        public EnderecoService(string _config)
        {
            repository = new EnderecoRepositor(_config);
        }
        public void Adicionar(Endereco endereco)
        {
            repository.Adicionar(endereco);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Endereco> Listar(int usuarioid)
        {
            return repository.ListarCarrinhoDoUsuario(usuarioid);
        }
        public Endereco BuscarTimePorId(int id)
        {
            return repository.BuscarPorId(id);
        }
        public void Editar(Endereco editendereco)
        {
            repository.Editar(editendereco);
        }
    }
}
