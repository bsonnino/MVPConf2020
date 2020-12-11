using System.Collections.Generic;
using VisualizaClientes.Model;

namespace VisualizaClientes.Repositorio
{
    public interface IRepositorioClientes
    {
        bool Add(Cliente cliente);
        bool Remove(Cliente cliente);
        bool Commit();
        IEnumerable<Cliente> Clientes { get; }
    }
}
