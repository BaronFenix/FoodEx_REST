using FoodEx.Application.IServices;
using FoodEx.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodEx.Controllers
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

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                return (List<User>)await _userService.GetAllUsers();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("getCurrentUser")]
        public async Task<ActionResult<User>> GetAuthUserByLogin(string login)
        {
            User? currentUser = await _userService.GetUserByLogin(login);
            if (currentUser == null)
            {
                return BadRequest(new { errorText = "User not found" });
            }

            return Ok(currentUser);
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateUserData(User editedUser)
        {
            if(User == null)
            {
                return BadRequest( new { msg = "User is null" });
            }
            await _userService.EditUser(editedUser);
            return Ok();
        }


    }
}
