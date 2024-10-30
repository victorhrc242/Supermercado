using Core._03_Entidades;
namespace Core._01_Services.Interfaces;
public interface IVendaservice
{
    void Adicionar(Venda usuario);
    void Remover(int id);
    List<Venda> Listar();
    Venda BuscarTimePorId(int id);
}
