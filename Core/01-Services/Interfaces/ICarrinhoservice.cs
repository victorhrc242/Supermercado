using Core.Entidades;
using FrontEnd.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services.Interfaces
{
    public interface ICarrinhoservice
    {
        void Adicionar(Carrinho carrinho);
        void Remover(int id);
        List<Carrinho> Listar();
            List<Readcarrinho> ListarCarrinhoDoUsuario(int usuarioId);
            Carrinho BuscarTimePorId(int id);
        void Editar(Carrinho editPessoa);
    }
}
