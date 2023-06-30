using Microsoft.AspNetCore.Mvc;
using SkatingLogAPI.Infrastructure.Models;
using SkatingLogAPI.Services;

namespace SkatingLogAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ActionName("Register")]
        [Route("[action]")]
        public async Task<ActionResult<User>> Register([FromBody] UserRegistrationDto userForRegisterDto)
        {
            try
            {
                var user = await _userService.Register(userForRegisterDto);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
