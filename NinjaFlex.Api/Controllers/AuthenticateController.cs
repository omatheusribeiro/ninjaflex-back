using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NinjaFlex.Application.Interfaces;
using NinjaFlex.Application.ViewModels;
using System.Threading.Tasks;

namespace NinjaFlex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticateController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AutenticacaoLogin([FromBody] AuthenticateViewModel authenticateViewModel)
        {
            ResponseViewModel response = new ResponseViewModel();

            if (authenticateViewModel == null)
                return NotFound(new ResponseViewModel { Message = "Não foi possível encontrar o usuário!", Success = false });

            response = await _userService.AuthenticateUser(authenticateViewModel.BarCode);

            return Ok(response);
        }
    }
}
