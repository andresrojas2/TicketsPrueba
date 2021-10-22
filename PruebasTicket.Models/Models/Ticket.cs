using System;
using System.Collections.Generic;

#nullable disable

namespace PruebasTicket.Models.Models
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int? EstadoId { get; set; }
    }
}
