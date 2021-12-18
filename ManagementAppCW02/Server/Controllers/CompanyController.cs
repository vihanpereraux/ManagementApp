using ManagementAppCW02.Server.Data;
using ManagementAppCW02.Server.Models;
using ManagementAppCW02.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ManagementAppCW02.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController:ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        // Should be server model
        private readonly CompanyModel _companyModel;

        public CompanyController(ILogger<CompanyController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyEntity>>> Get() 
        {
            // Fetching all the Companies to a list
            //return await _companyModel.GetAllCompanies();
            return await _applicationDbContext.Companies.ToListAsync();
        }

        [HttpGet("{companyName}", Name = "GetCompany")]
        public async Task<ActionResult<CompanyEntity>> Get(string companyName) 
        {
            // A Logic applies in the parameteres (checking both properties belong to db's table and client side request)
            return await _applicationDbContext.Companies.FirstOrDefaultAsync(x => x.companyName == companyName);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyEntity>> Post(CompanyEntity companyModel) 
        {
            //_applicationDbContext.Add(companyModel); --> Used in the YT Tutorial @ 10:33
            _applicationDbContext.Companies.Add(companyModel);
            await _applicationDbContext.SaveChangesAsync();

            // No idea about this statement
            return new CreatedAtRouteResult("GetCompany", new { companyName = companyModel.companyName }, companyModel);
        }

        [HttpPut]
        public async Task<ActionResult> Put(CompanyEntity companyModel) 
        {
            _applicationDbContext.Entry(companyModel).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return NoContent();
        }

        private async Task<CompanyEntity> GetCompanyByName(string companyName)
        {
            return await _applicationDbContext.Companies
                .FirstOrDefaultAsync(company => company.companyName == companyName);
        }

        [HttpDelete("{companyName}")]
        public async Task<ActionResult> Delete(string companyName) 
        {
            var result = await GetCompanyByName(companyName);
            if (result != null)
            {
                _applicationDbContext.Companies.Remove(result);
                await _applicationDbContext.SaveChangesAsync();
                return NoContent();
            }
            return null;

            /* var company = new CompanyModel( companyName = companyName ); */

        }
    }
}
