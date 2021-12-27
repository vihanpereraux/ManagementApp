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

        public async Task<UserEntity> GetUserById(string userName)
        {
            return await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<UserEntity> Post(UserEntity userModel)
        {
            var cheduser = await GetUserById(userModel.UserName);
            if(cheduser == null) 
            {
                var result = _applicationDbContext.Users.Add(userModel);
                await _applicationDbContext.SaveChangesAsync();
                return result.Entity;
            }
            else 
            {
                return null;
            }
            
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

        public async Task<UserEntity> Delete(string userName)
        {
            var result = await GetUserById(userName);
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
