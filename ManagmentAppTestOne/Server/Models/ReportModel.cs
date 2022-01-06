using ManagmentAppTestOne.Server.Data;
using ManagmentAppTestOne.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
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

        public async Task<IEnumerable<TicketEntity>> GetRelevantTickets(DateTime StartDate, DateTime EndDate) 
        {
            var result = await (from x in _applicationDbContext.Tickets 
                                where(x.TicketStartedDate <= StartDate
                                && x.TicketStartedDate >= EndDate) 
                                select x).ToListAsync();
            return result;
        }







        /*public async Task<IEnumerable> GetCompletedTickets(Guid companyId) 
        {
            var tickets = await _applicationDbContext.Tickets.ToListAsync();
            var relevantProjects = await _applicationDbContext.Projects.Where(x => x.CompanyId == companyId).ToListAsync();

            ArrayList relevantTickets = new ArrayList();

            foreach ( var project in relevantProjects ) 
            {
                foreach( var ticket in tickets ) 
                {
                    if(project.ProjectId == ticket.ProjectId && ticket.TicketState == "Completed") 
                    {
                        relevantTickets.Add(ticket);
                    }
                }
            }
            return relevantTickets;
        }*/
    }
}
