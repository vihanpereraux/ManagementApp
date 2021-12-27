using ManagmentAppTestOne.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Models
{
    public interface ITicketModel
    {
        public Task<IEnumerable<TicketEntity>> GetTickets();

        public Task<IEnumerable<TicketEntity>> GetTickets(Guid projectId);

        public Task<TicketEntity> GetTicketByName(string ticketName);

        public Task<TicketEntity> Post(TicketEntity ticket);

        public Task<TicketEntity> Put(TicketEntity ticket);

        public Task<TicketEntity> Delete(string ticketName);

    }
}
