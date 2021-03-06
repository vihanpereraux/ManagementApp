using ManagmentAppTestOne.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Models
{
    public interface IUserModel
    {
        public Task<IEnumerable<UserEntity>> GetUsers();

        public Task<UserEntity> GetUserById(string userName);

        public Task<UserEntity> Post(UserEntity userModel);

        public Task<UserEntity> Put(UserEntity userModel);

        public Task<UserEntity> Delete(string userName);
    }
}
