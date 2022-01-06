using ManagmentAppTestOne.Shared.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Models
{
    public interface IReportModel
    {
        public Task<IEnumerable<TicketEntity>> GetTickets();

        public Task<IEnumerable<TicketEntity>> GetUserTickets(Guid userId);

        public Task<IEnumerable<TicketEntity>> GetRelevantTickets(DateTime StartDate, DateTime EndDate);

    }
}
