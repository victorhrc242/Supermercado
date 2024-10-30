﻿using Core._01_Services.Interfaces;
using Core._02_Repository.Interfaces;
using Core._03_Entidades.DTO;
using Core.Entidades;
using FrontEnd.models;
using TrabalhoFinal._02_Repository;

namespace TrabalhoFinal._01_Services;

public class CarrinhoService:ICarrinhoservice
{
    public ICarrinhoreposytor1 repository { get; set; }
    public CarrinhoService(string _config)
    {
        //repository = new CarrinhoRepository(_config);
    }
    public void Adicionar(Carrinho carrinho)
    {
        repository.Adicionar(carrinho);
    }

    public void Remover(int id)
    {
        repository.Remover(id);
    }

    public List<Carrinho> Listar()
    {
        return repository.Listar();
    }

    public List<Readcarrinho> ListarCarrinhoDoUsuario(int usuarioId)
    {
        return repository.ListarCarrinhoDoUsuario(usuarioId);
    }
    public Carrinho BuscarTimePorId(int id)
    {
        return repository.BuscarPorId(id);
    }
    public void Editar(Carrinho editPessoa)
    {
        repository.Editar(editPessoa);
    }
}
