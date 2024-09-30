using Core._03_Entidades;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository
{

    public class EnderecoRepositor
    {
        private readonly string ConnectionString;
        public EnderecoRepositor(string connectioString)
        {
            ConnectionString = connectioString;
        }
        public void Adicionar(Endereco endereco)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Endereco>(endereco);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Endereco endereco = BuscarPorId(id);
            connection.Delete<Endereco>(endereco);
        }
        public void Editar(Endereco endereco)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<Endereco>(endereco);
        }
        public List<Endereco> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Endereco>().ToList();
        }
        public Endereco BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Endereco>(id);
        }
    }
}
