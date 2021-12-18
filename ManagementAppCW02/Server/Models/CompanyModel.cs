using ManagementAppCW02.Server.Controllers;
using ManagementAppCW02.Server.Data;
using ManagementAppCW02.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagementAppCW02.Server.Models
{
    public class CompanyModel
    {
        private readonly ILogger<CompanyModel> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        List<CompanyEntity> intList = new List<CompanyEntity>();

        public CompanyModel(ILogger<CompanyModel> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ActionResult<List<CompanyEntity>>> GetAllCompanies()
        {
            // Fetching all the Companies to a list
            intList = await _applicationDbContext.Companies.ToListAsync();
            return intList;
        }
    }
}
