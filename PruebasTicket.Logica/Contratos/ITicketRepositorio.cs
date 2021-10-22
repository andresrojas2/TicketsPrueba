using PruebasTicket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasTicket.Logica.Contratos
{
    public interface ITicketRepositorio : IRepositorioGenerico<Ticket>
    {
        Task<int> CountAsync(int records, int page);
    }
}
