using ManagmentAppTestOne.Server.Data;
using ManagmentAppTestOne.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Models
{
    public class AuthModel : IAuthModel
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public readonly ILogger<AuthModel> _logger;

        public AuthModel(ILogger<AuthModel> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<UserEntity> LoginUser(AuthEntity authUser) 
        {
            UserEntity loggedInUser = await _applicationDbContext.Users.Where(
                u => u.UserEmail == authUser.UserEmail &&
                u.UserPassword == authUser.UserPassword &&
                u.UserName == authUser.UserName).
                FirstOrDefaultAsync();

            if (loggedInUser != null)
            {
                return loggedInUser;
            }
            else
            {
                return null;
            }
        }
    }
}
