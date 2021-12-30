using ManagmentAppTestOne.Server.Models;
using ManagmentAppTestOne.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ManagmentAppTestOne.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserModel _userModel;

        public UserController(ILogger<UserController> logger, IUserModel userModel)
        {
            _logger = logger;
            _userModel = userModel;
        }

        
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(await _userModel.GetUsers());
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<UserEntity>> Get(string userName)
        {
            return Ok(await _userModel.GetUserById(userName));
        }

        [HttpPost]
        public async Task<ActionResult<UserEntity>> Post(UserEntity userModel)
        {
            var result = await _userModel.Post(userModel);
            if(result != null) 
            {
                return Ok(result);
            }
            else 
            {
                return BadRequest(result);
            }
            
            //return new CreatedAtRouteResult("GetUser", new { userName = userModel.UserName }, userModel);
        }

        [HttpPut]
        public async Task<ActionResult> Put(UserEntity userModel)
        {
            await _userModel.Put(userModel);
            return new CreatedAtRouteResult("GetUser", new { userName = userModel.UserName }, userModel);
        }

        [HttpDelete("{userName}")]
        public async Task<ActionResult> Delete(string userName)
        {
            var deleted = await _userModel.Delete(userName);
            return Ok(deleted);
            //return new CreatedAtRouteResult("GetUser", new { userName = deleted.UserName }, deleted);
        }


    }
}
