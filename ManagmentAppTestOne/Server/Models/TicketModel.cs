using ManagmentAppTestOne.Server.Data;
using ManagmentAppTestOne.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Models
{
    public class TicketModel : ITicketModel
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly ILogger<TicketModel> _logger;

        public TicketModel(ILogger<TicketModel> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<TicketEntity>> GetTickets() 
        {
            return await _applicationDbContext.Tickets.ToListAsync();
        }

        public async Task<IEnumerable<TicketEntity>> GetTickets(Guid projectId)
        {
            return await _applicationDbContext.Tickets.Where(x => x.ProjectId == projectId).ToListAsync();
        }

        public async Task<TicketEntity> GetTicketByName(string ticketName)
        {
            return await _applicationDbContext.Tickets.FirstOrDefaultAsync(x => x.TicketTitle == ticketName);
        }

        public async Task<TicketEntity> Post(TicketEntity ticket)
        {
            var result = _applicationDbContext.Tickets.Add(ticket);
            await _applicationDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TicketEntity> Put(TicketEntity ticket)
        {
            _applicationDbContext.Entry(ticket).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<TicketEntity> Delete(string ticketName)
        {
            var result = await GetTicketByName(ticketName);
            if (result != null)
            {
                _applicationDbContext.Tickets.Remove(result);
                await _applicationDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
