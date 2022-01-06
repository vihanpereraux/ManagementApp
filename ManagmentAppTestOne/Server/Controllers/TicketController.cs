using ManagmentAppTestOne.Server.Models;
using ManagmentAppTestOne.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController: ControllerBase
    {
        private readonly ILogger<TicketController> _logger;
        private readonly ITicketModel _ticketModel;

        public TicketController(ILogger<TicketController> logger, ITicketModel ticketModel)
        {
            _logger = logger;
            _ticketModel = ticketModel;
        }

        [HttpGet]
        public async Task<ActionResult> GetTickets()
        {
            return Ok(await _ticketModel.GetTickets());
        }

        [HttpGet("{projectId:guid}")]
        public async Task<ActionResult> GetTickets(Guid projectId)
        {
            return Ok(await _ticketModel.GetTickets(projectId));
        }

        [HttpGet("{ticketName}")]
        public async Task<ActionResult<TicketEntity>> GetTicketByName(string ticketName) 
        {
            return Ok(await _ticketModel.GetTicketByName(ticketName));
        }

        [HttpPost]
        public async Task<ActionResult<TicketEntity>> Post(TicketEntity ticket)
        {
            var result = await _ticketModel.Post(ticket);
            if( result != null) 
            {
                return Ok(new CreatedAtRouteResult("GetTicket", new { TicketTitle = ticket.TicketTitle }, ticket));
            }
            else
            {
                return BadRequest();
            }
            /*return new CreatedAtRouteResult("GetTicket", new { TicketTitle = ticket.TicketTitle }, ticket);*/
        }

        [HttpPut]
        public async Task<ActionResult> Put(TicketEntity ticket)
        {
            await _ticketModel.Put(ticket);
            return new CreatedAtRouteResult("GetTicket", new { TicketTitle = ticket.TicketTitle }, ticket);
        }

        [HttpDelete("{ticketName}")]
        public async Task<ActionResult> Delete(string ticketName)
        {
            var deleted = await _ticketModel.Delete(ticketName);
            return new CreatedAtRouteResult("GetProject", new { ticketTitle = deleted.TicketTitle }, deleted);
        }
    }
}
