using System;
using System.Collections.Generic;

#nullable disable

namespace PruebasTicket.Models.Models
{
    public partial class EstatusTicket
    {
        public EstatusTicket()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
