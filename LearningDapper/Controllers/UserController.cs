using LearningDapper.Core.Interfaces;
using LearningDapper.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningDapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("get-user")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            return Ok(user);
        }

        [HttpPost("create-user")]
        public IActionResult CreateUser(User user)
        {
            _userService.CreateUser(user);
            return Ok();
        }

        [HttpPut("update-user")]
        public IActionResult UpdateUser(User user, int id)
        {
            _userService.UpdateUser(user, id);
            return Ok();
        }

        [HttpDelete("delete-user")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}