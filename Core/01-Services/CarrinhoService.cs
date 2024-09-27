﻿using Core._03_Entidades.DTO;
using Core.Entidades;
using FrontEnd.models;
using TrabalhoFinal._02_Repository;

namespace TrabalhoFinal._01_Services;

public class CarrinhoService
{
    public CarrinhoRepository repository { get; set; }
    public CarrinhoService(string _config)
    {
        repository = new CarrinhoRepository(_config);
    }
    public void Adicionar(Carrinho carrinho)
    {
        repository.Adicionar(carrinho);
    }

    public void Remover(int id)
    {
        repository.Remover(id);
    }

    public List<Readcarrinho> Listar(int id)
    {
        return repository.Listar(id);
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
