using ManagementAppCW02.Server.Data;
using ManagementAppCW02.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagementAppCW02.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController:ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public CompanyController(ILogger<CompanyController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyModel>>> Get() 
        {
            // Fetching all the Companies to a list
            return await _applicationDbContext.Companies.ToListAsync();
        }

        [HttpGet("{companyName}", Name = "GetCompany")]
        public async Task<ActionResult<CompanyModel>> Get(string companyName) 
        {
            // A Logic applies in the parameteres (checking both properties belong to db's table and client side request)
            return await _applicationDbContext.Companies.FirstOrDefaultAsync(x => x.companyName == companyName);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyModel>> Post(CompanyModel companyModel) 
        {
            //_applicationDbContext.Add(companyModel); --> Used in the YT Tutorial @ 10:33
            _applicationDbContext.Companies.Add(companyModel);
            await _applicationDbContext.SaveChangesAsync();

            // No idea about this statement
            return new CreatedAtRouteResult("GetCompany", new { companyName = companyModel.companyName }, companyModel);
        }

        [HttpPut]
        public async Task<ActionResult> Put(CompanyModel companyModel) 
        {
            _applicationDbContext.Entry(companyModel).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string companyName) 
        {
            CompanyModel company = new CompanyModel( companyName = companyName );
            _applicationDbContext.Remove(company);
            await _applicationDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
