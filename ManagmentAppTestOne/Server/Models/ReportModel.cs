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
    public class ReportModel : IReportModel
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly ILogger<ReportModel> _logger;

        public ReportModel(ILogger<ReportModel> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<TicketEntity>> GetTickets() 
        {
            return await _applicationDbContext.Tickets.ToListAsync();
        }

        public async Task<IEnumerable<TicketEntity>> GetUserTickets(Guid userId) 
        {
            return await _applicationDbContext.Tickets.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
