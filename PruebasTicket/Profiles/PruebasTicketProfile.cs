using AutoMapper;
using PruebasTicket.Dtos;
using PruebasTicket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasTicket.Profiles
{
    public class PruebasTicketProfile : Profile
    {

        public PruebasTicketProfile()
        {
            this.CreateMap<Ticket, TicketDto>()
                .ForMember(o => o.EstatusTicket, p => p.MapFrom(m => m.EstatusTicket.Descripcion))
                .ReverseMap()
                .ForMember(o => o.EstatusTicket, p => p.Ignore());


            this.CreateMap<EstatusTicket, EstatusTicket>()
               .ReverseMap();
        }

    }
}
