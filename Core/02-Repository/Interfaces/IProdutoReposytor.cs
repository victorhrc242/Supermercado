using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository.Interfaces
{
    public interface IProdutoReposytor
    {
        void Adicionar(Produto produto);
        void Remover(int id);
        void Editar(Produto produto);
        List<Produto> Listar();
        Produto BuscarPorId(int id);
    }
}
