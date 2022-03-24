using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NinjaFlex.Application.Interfaces;
using NinjaFlex.Application.ViewModels;

namespace NinjaFlex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeUserController : Controller
    {
        private readonly ITypeUserService _typeUserService;

        public TypeUserController(ITypeUserService typeUserService)
        {
            _typeUserService = typeUserService;
        }

        [HttpPost("GetTypeUsers")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<TypeUserViewModel>>> GetTypeUsers([FromBody] TypeUserViewModel typeUser)
        {
            ResponseViewModel response = new ResponseViewModel();

            response = await _typeUserService.GetTypeUsers(typeUser);

            return Ok(response);

        }

        [HttpGet("GetTypeUserById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetTypeUserById(int id)
        {
            ResponseViewModel response = new ResponseViewModel();

            if (id == 0)
                return NotFound(new ResponseViewModel { Message = "Não foi possível encontrar o tipo do usuário!", Success = false });

            response = await _typeUserService.GetTypeUserById(id);

            return Ok(response);

        }

        [HttpPut("PutTypeUser")]
        [Authorize]
        public async Task<ActionResult<TypeUserViewModel>> PutTypeUser([FromBody] TypeUserViewModel typeUser)
        {
            ResponseViewModel response = new ResponseViewModel();

            if (typeUser == null)
                return NotFound(new ResponseViewModel { Message = "Não foi possível encontrar o tipo do usuário!", Success = false });

            response = await _typeUserService.PutTypeUser(typeUser);

            return Ok(response);
        }

        [HttpPost("PostTypeUser")]
        [Authorize]
        public async Task<ActionResult<TypeUserViewModel>> PostTypeUser([FromBody] TypeUserViewModel typeUser)
        {
            ResponseViewModel response = new ResponseViewModel();

            if (typeUser == null)
                return NotFound(new ResponseViewModel { Message = "Não foi possível encontrar o tipo do usuário!", Success = false });

            response = await _typeUserService.PostTypeUser(typeUser);

            return Ok(response);
        }
    }
}
