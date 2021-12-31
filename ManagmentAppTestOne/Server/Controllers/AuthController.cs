using ManagmentAppTestOne.Server.Data;
using ManagmentAppTestOne.Server.Models;
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
        private readonly IAuthModel _authModel;

        public AuthController(ILogger<AuthController> logger, IAuthModel authModel)
        {
            _logger = logger;
            _authModel = authModel;
        }

        [HttpPost]
        public async Task<ActionResult<UserEntity>> LoginUser(AuthEntity authUser)
        {
            var result = await _authModel.LoginUser(authUser);
            if (result != null)
            {
                return result;
            }
            else
            {
                return BadRequest();
            }
        }  
    }
}
