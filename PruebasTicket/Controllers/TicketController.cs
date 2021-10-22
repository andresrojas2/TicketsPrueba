using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebasTicket.Dtos;
using PruebasTicket.Logica.Contratos;
using PruebasTicket.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketRepositorio _ticketRepositorio;
        private readonly IMapper _mapper;
        private readonly int records = 5;

        public TicketController(ITicketRepositorio ticketRepositorio, IMapper mapper)
        {
            _ticketRepositorio = ticketRepositorio;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get([FromQuery] int? page)
        {
            try
            {

                int _page = page ?? 1;

                int totalPages = await _ticketRepositorio.CountAsync(records, _page);

                var ticekts = await _ticketRepositorio.ObtenerTodosAsync(records, _page, totalPages);
                var ticektsDto = _mapper.Map<List<TicketDto>>(ticekts);

                return Ok(new
                {
                    pages = totalPages,
                    records = ticektsDto,
                    currentPages = _page
                });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ticket>> Post(TicketDto ticketDto)
        {
            try
            {

                ticketDto.FechaCreacion = DateTime.Now;
                ticketDto.FechaActualizacion = null;

                var ticket = _mapper.Map<Ticket>(ticketDto);

                var nuevoTicket = await _ticketRepositorio.Agregar(ticket);
                if (nuevoTicket == null)
                {
                    return BadRequest();
                }

                var nuevaOrdenDto = _mapper.Map<TicketDto>(nuevoTicket);
                return CreatedAtAction(nameof(Post), new { id = nuevaOrdenDto.Id }, nuevaOrdenDto);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var resultado = await _ticketRepositorio.Eliminar(id);
                if (!resultado)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch (Exception excepcion)
            {
                return BadRequest();
            }
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TicketDto>> Get(int id)
        {
            var ticket = await _ticketRepositorio.ObtenerAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return _mapper.Map<TicketDto>(ticket);
        }

        // PUT: api/Productos/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TicketDto>> Put(int id, [FromBody] TicketDto ticketDto)
        {


            ticketDto.FechaActualizacion = DateTime.Now;

            if (ticketDto == null)
                return NotFound();

            var ticket = _mapper.Map<Ticket>(ticketDto);
            ticket.Id = id;
            var resultado = await _ticketRepositorio.Actualizar(ticket);

            if (!resultado)
                return BadRequest();


            return ticketDto;

        }
    }
}
