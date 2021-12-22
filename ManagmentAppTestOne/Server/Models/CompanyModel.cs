using ManagmentAppTestOne.Server.Data;
using ManagmentAppTestOne.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Models
{
    public class CompanyModel: ICompanyModel
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly ILogger<CompanyModel> _logger;

        public CompanyModel(ILogger<CompanyModel> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<CompanyEntity>> GetComapnies() 
        {
            return await _applicationDbContext.Companies.ToListAsync();
            /*var list = _applicationDbContext.Companies.Select(v => v.CompanyName).ToList();
            return (IEnumerable<CompanyEntity>)list;*/
        }

        public async Task<CompanyEntity> GetCompanyByName(string companyName)
        {
            return await _applicationDbContext.Companies.FirstOrDefaultAsync(x => x.CompanyName == companyName);
        }

        public async Task<CompanyEntity> Post(CompanyEntity company) 
        {
            var result = _applicationDbContext.Companies.Add(company);
            await _applicationDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<CompanyEntity> Put(CompanyEntity company) 
        {
            _applicationDbContext.Entry(company).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return company;
        }

        /*private async Task<CompanyEntity> GetCompanyByName(string companyName)
        {
            return await _applicationDbContext.Companies.FirstOrDefaultAsync(company => company.CompanyName == companyName);
        }*/

        public async Task<CompanyEntity> Delete(string companyName)
        {
            var result = await GetCompanyByName(companyName);
            if (result != null)
            {
                _applicationDbContext.Companies.Remove(result);
                await _applicationDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }


    }
}
