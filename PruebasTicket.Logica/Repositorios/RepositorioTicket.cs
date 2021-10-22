using Microsoft.EntityFrameworkCore;
using PruebasTicket.Logica.Contratos;
using PruebasTicket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasTicket.Logica.Repositorios
{
    public class RepositorioTicket : ITicketRepositorio
    {

        private PruebasTicketContext _context;
        private DbSet<Ticket> _dbSet;

        public RepositorioTicket(PruebasTicketContext context)
        {
            _context = context;
            this._dbSet = _context.Set<Ticket>();
        }


        public async Task<bool> Actualizar(Ticket entity)
        {

            _dbSet.Attach(entity);
            _context.Entry(entity).Property(x => x.FechaActualizacion).IsModified = true;
            _context.Entry(entity).Property(x => x.Usuario).IsModified = true;
            _context.Entry(entity).Property(x => x.EstatusTicketId).IsModified = true;

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<Ticket> Agregar(Ticket entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Eliminar(int id)
        {
            var entity = await _dbSet.SingleOrDefaultAsync(u => u.Id == id);
            _dbSet.Remove(entity);
            return (await _context.SaveChangesAsync() > 0 ? true : false);
        }

        public async Task<Ticket> ObtenerAsync(int id)
        {
            return await _dbSet.Include(EstatusTicket => EstatusTicket.EstatusTicket).SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> CountAsync(int records, int page)
        {
            decimal totalRecors = await _dbSet.CountAsync();
            int totalPages = Convert.ToInt32(Math.Ceiling(totalRecors / records));

            return totalPages;
        }

        public async Task<IEnumerable<Ticket>> ObtenerTodosAsync(int records, int page, int totalPages)
        {

            return await _dbSet.Skip((page - 1) * records).Take(records).Include(EstatusTicket => EstatusTicket.EstatusTicket).ToListAsync();

        }
    }
}
