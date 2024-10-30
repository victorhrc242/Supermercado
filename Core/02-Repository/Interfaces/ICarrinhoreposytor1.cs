using Core.Entidades;
using FrontEnd.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository.Interfaces
{
    public interface ICarrinhoreposytor1
    {
        void Adicionar(Carrinho carrinho);
        void Remover(int id);
        void Editar(Carrinho carrinho);
        List<Carrinho> Listar();
        List<Readcarrinho> ListarCarrinhoDoUsuario(int usuarioId);
        Carrinho BuscarPorId(int id);
    }
}
