using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository.Interfaces
{
    public interface IVendaReposytor
    {
        void Adicionar(Venda venda);
        void Remover(int id);
        List<Venda> Listar();
        Venda BuscarPorId(int id);
    }
}
