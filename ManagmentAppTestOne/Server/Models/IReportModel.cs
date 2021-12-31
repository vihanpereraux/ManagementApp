using ManagmentAppTestOne.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Models
{
    public interface IReportModel
    {
        public Task<IEnumerable<TicketEntity>> GetTickets();

        public Task<IEnumerable<TicketEntity>> GetUserTickets(Guid userId);
    }
}
