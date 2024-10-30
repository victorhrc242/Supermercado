using Core._01_Services.Interfaces;
using Core._02_Repository;
using Core._02_Repository.Interfaces;
using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._02_Repository;

namespace Core._01_Services
{
    public class vendaservice:IVendaservice
    {
        public IVendaReposytor repository { get; set; }
        public vendaservice(string _config)
        {
            repository = new Vendarepositor(_config);
        }
        public void Adicionar(Venda usuario)
        {
            repository.Adicionar(usuario);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Venda> Listar()
        {
            return repository.Listar();
        }
        public Venda BuscarTimePorId(int id)
        {
            return repository.BuscarPorId(id);
        }
   
       
    }
}
