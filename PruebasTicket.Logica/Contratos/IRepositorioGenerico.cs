using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasTicket.Logica.Contratos
{
    public interface IRepositorioGenerico<T> where T : class
    {

        Task<IEnumerable<T>> ObtenerTodosAsync(int records, int page, int totalPages);
        Task<T> ObtenerAsync(int id);
        Task<T> Agregar(T entity);
        Task<bool> Actualizar(T entity);
        Task<bool> Eliminar(int id);

    }
}
