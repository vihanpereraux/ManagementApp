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
    public class PredictionModel : IPredictionModel
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly ILogger<PredictionModel> _logger;

        public PredictionModel(ILogger<PredictionModel> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<float> GetRelevantAvg(Guid companyId)
        {
            //var projects = await _applicationDbContext.Projects.Where(x => x.CompanyId == companyId).ToListAsync();
            var company = await _applicationDbContext.Companies.FirstOrDefaultAsync(x => x.CompanyId == companyId);
            DateTime companyStartedDate = company.EstablishedDate;
            DateTime curruntDate = DateTime.Today;
            float numOfMonths = ((curruntDate.Year - companyStartedDate.Year) * 12) + curruntDate.Month - companyStartedDate.Month;
            //float projectsForOneMonth = projects.Count() / numOfMonths;
            return numOfMonths;
        }
    }
}
