using ManagmentAppTestOne.Server.Data;
using ManagmentAppTestOne.Server.Models;
using ManagmentAppTestOne.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController:ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyModel _companyModel;

        public CompanyController(ILogger<CompanyController> logger, ICompanyModel companyModel)
        {
            _logger = logger;
            _companyModel = companyModel;
        }

        [HttpGet]
        public async Task<ActionResult> GetCompanies() 
        {
            return Ok(await _companyModel.GetComapnies());
        }

        [HttpGet("{companyName}", Name = "GetCompany")]
        public async Task<ActionResult<CompanyEntity>> Get(string companyName)
        {
            return Ok(await _companyModel.GetCompanyByName(companyName));   
        }

        [HttpPost]
        public async Task<ActionResult<CompanyEntity>> Post(CompanyEntity companyModel)
        {
            await _companyModel.Post(companyModel);
            return new CreatedAtRouteResult("GetCompany", new { companyName = companyModel.CompanyName }, companyModel);
        }

        [HttpPut]
        public async Task<ActionResult> Put(CompanyEntity companyModel)
        {
            await _companyModel.Put(companyModel);
            return new CreatedAtRouteResult("GetCompany", new { companyName = companyModel.CompanyName }, companyModel);
        }

        [HttpDelete("{companyName}")]
        public async Task<ActionResult> Delete(string companyName)
        {
            var deleted = await _companyModel.Delete(companyName);
            return new CreatedAtRouteResult("GetCompany", new { companyName = deleted.CompanyName }, deleted);
        }

    }
}
