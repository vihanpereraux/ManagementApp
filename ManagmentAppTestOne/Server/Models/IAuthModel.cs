using ManagmentAppTestOne.Shared.Entities;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Models
{
    public interface IAuthModel
    {
        public Task<UserEntity> LoginUser(AuthEntity authUser);
    }
}
