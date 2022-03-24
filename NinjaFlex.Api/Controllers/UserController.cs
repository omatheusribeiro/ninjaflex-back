using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NinjaFlex.Application.Interfaces;
using NinjaFlex.Application.ViewModels;

namespace NinjaFlex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("GetUsers")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers([FromBody] UserViewModel user)
        {
            ResponseViewModel response = new ResponseViewModel();

            response = await _userService.GetUsers(user);

            return Ok(response);

        }

        [HttpGet("GetUserById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById(int id)
        {
            ResponseViewModel response = new ResponseViewModel();

            if (id == 0)
                return NotFound(new ResponseViewModel { Message = "Não foi possível encontrar o usuário!", Success = false });

            response = await _userService.GetUserById(id);

            return Ok(response);

        }

        [HttpPut("PutUsuario")]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> PutUser([FromBody] UserViewModel user)
        {
            ResponseViewModel response = new ResponseViewModel();

            if (user == null)
                return NotFound(new ResponseViewModel { Message = "Não foi possível encontrar o usuário!", Success = false });

            response = await _userService.PutUser(user);

            return Ok(response);
        }

        [HttpPost("PostUsuario")]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> PostUser([FromBody] UserViewModel user)
        {
            ResponseViewModel response = new ResponseViewModel();

            if (user == null)
                return NotFound(new ResponseViewModel { Message = "Não foi possível encontrar o usuário!", Success = false });

            response = await _userService.PostUser(user);

            return Ok(response);
        }
    }
}
