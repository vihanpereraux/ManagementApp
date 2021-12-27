using ManagmentAppTestOne.Server.Data;
using ManagmentAppTestOne.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Models
{
    public class UserModel:IUserModel
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly ILogger<UserModel> _logger;

        public UserModel(ILogger<UserModel> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<UserEntity>> GetUsers()
        {
            return await _applicationDbContext.Users.ToListAsync();
        }

        public async Task<UserEntity> GetUserById(Guid userId)
        {
            return await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<UserEntity> Post(UserEntity userModel)
        {
            var result = _applicationDbContext.Users.Add(userModel);
            await _applicationDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<UserEntity> Put(UserEntity userModel)
        {
            _applicationDbContext.Entry(userModel).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return userModel;
        }

        /*private async Task<CompanyEntity> GetCompanyByName(string companyName)
        {
            return await _applicationDbContext.Companies.FirstOrDefaultAsync(company => company.CompanyName == companyName);
        }*/

        public async Task<UserEntity> Delete(Guid userId)
        {
            var result = await GetUserById(userId);
            if (result != null)
            {
                _applicationDbContext.Users.Remove(result);
                await _applicationDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }
    }
}
