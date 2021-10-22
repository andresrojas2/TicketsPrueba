using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebasTicket.Dtos
{
    public class TicketDto
    {
     

        public int Id { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Display(Name = "Fecha creación")]
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int? EstatusTicketId { get; set; }


        public string EstatusTicket { get; set; }


    }
}
