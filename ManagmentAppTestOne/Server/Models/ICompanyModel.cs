using ManagmentAppTestOne.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Models
{
    public interface ICompanyModel
    {
        public Task<IEnumerable<CompanyEntity>> GetComapnies();

        public Task<CompanyEntity> GetCompanyByName(string companyName);

        public Task<CompanyEntity> Post(CompanyEntity companyModel);

        public Task<CompanyEntity> Put(CompanyEntity companyModel);

        public Task<CompanyEntity> Delete(string companyName);
    }
}
