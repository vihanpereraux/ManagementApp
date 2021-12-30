using ManagmentAppTestOne.Server.Data;
using ManagmentAppTestOne.Shared.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        public readonly ApplicationDbContext _applicationDbContext;
  
        public AuthController(ILogger<AuthController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<UserEntity>> LoginUser(AuthEntity authUser)
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
                return BadRequest();
            }
        }

        /*[HttpGet("getcurrentuser")]
        public async Task<ActionResult<AuthEntity>> GetCurrentUser() 
        { 
            AuthEntity currentUser = new AuthEntity();

            if (AuthEntity.Identity.IsAuthenticated) 
            {
                currentUser.UserEmail = AuthEntity.FindFirstValue(ClaimTypes.Name);
            }
            return await Task.FromResult(currentUser);
        }*/

        [HttpGet("logoutuser")]
        public async Task<ActionResult<string>> LogoutUser() 
        {
            await HttpContext.SignOutAsync();
            return "Success";
        }


        
    }
}
