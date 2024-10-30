using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services.Interfaces
{
    public interface IProdutoservice
    {
        
    void Adicionar(Produto usuario);
        void Remover(int id);
        List<Produto> Listar();
        Produto BuscarTimePorId(int id);
        void Editar(Produto editPessoa);
        
          
        
    }
}
